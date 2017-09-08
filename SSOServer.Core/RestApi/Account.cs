using Microsoft.AspNetCore.Http.Authentication;
using Nancy;
using System;

namespace SSOServer.Core.RestApi
{
    public class Account:NancyModule
    {
        public Account():base("/account")
        { 
            Get("/login", p => {

                return View["Login.html"];
            });

            Post("/login", p => {

                string subjectId = null;

                if(Context.Request.Cookies.ContainsKey("id"))
                {
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
