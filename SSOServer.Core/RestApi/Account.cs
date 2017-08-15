using Microsoft.AspNetCore.Http.Authentication;
using Nancy;
using System;

namespace SSOServer.Core.WebApi
{
    public class Account:NancyModule
    {
        public Account()
        { 
            Get("/signin-oidc", p => {
                Context.GetAuthenticationManager();
                return View["Login.html"];
            });

            Post("/signin-oidc", p => {

                string subjectId = null;

                if(Context.Request.Cookies.ContainsKey(".AspNetCore.Session"))
                {
                    subjectId = Context.Request.Cookies[".AspNetCore.Session"];
                }

                var mgr = Context.GetAuthenticationManager();
                string scheme=mgr.GetIdentityServerAuthenticationScheme();

                var props = new AuthenticationProperties 
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20)
                };

                //// Instruct the OIDC client middleware to redirect the user agent to the identity provider.
                //// Note: the authenticationType parameter must match the value configured in Startup.cs
                //mgr.SignInAsync(subjectId, null, null);

                return HttpStatusCode.OK;
            });
        }
    }
}
