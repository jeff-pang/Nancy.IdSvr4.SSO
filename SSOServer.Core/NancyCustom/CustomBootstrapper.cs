using Nancy;
using Nancy.IO;
using Nancy.Extensions;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Serilog;
using System;
using System.Text;
using System.Linq;
using Nancy.Conventions;
using Nancy.Cryptography;
using System.Security.Cryptography;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.AspNetCore.Http;
using Nancy.AspNetCore.Session;

namespace SSOServer.Core.NancyCustom
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            var cryptographyConfiguration = new CryptographyConfiguration(
               new RSACryptoProvider(),
               new DefaultHmacProvider(new PassphraseKeyGenerator("UberSuperSecure", new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })));
            
            Nancy.Security.Csrf.Enable(pipelines);
            
            pipelines.OnError += (ctx, ex) => {
                
                string path = ctx.Request.Path;
                string dcp = ctx.Request.Query["data_collection_point"];
                string clientIp = ctx.Request.UserHostAddress;
                
                string nginxClientIp = ctx.Request.Headers["X-Real-IP"]?.FirstOrDefault();
                if (!string.IsNullOrEmpty(nginxClientIp))
                {
                    clientIp = nginxClientIp;
                }
                
                Log.Error("{ip}\t{dcp}\t{path}\t{message}", clientIp, dcp, path, ex.Message);

                try
                {
                    string body = RequestStream.FromStream(ctx.Request.Body).AsString();
                    var loginfo = new StringBuilder();
                    loginfo.AppendLine(ex.Message);

                    loginfo.AppendFormat("Content-Type: --- {0} ---\n", ctx.Request.Headers.ContentType?.ToString());
                    loginfo.AppendFormat("Request Body: {0}\n\t--- End of Request Body ---\n", body.Replace("\n", "\n\t"));
                    Log.Debug(ex, loginfo.ToString());
                }
                catch (Exception lex)
                {
                    Log.Error("{ip}\t{dcp}\t{path}\t{message}", clientIp, dcp, path, lex.Message);
                    Log.Debug(lex, lex.Message);
                }

                return null;
            };
        }        
    }
}
