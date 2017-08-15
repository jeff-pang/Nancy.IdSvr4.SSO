using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Nancy.AspNetCore.Http;

namespace Nancy.Owin
{
    public static class AuthManagerExtension
    {
        internal static class NancyHttpContextAccessor
        {
            internal static IHttpContextAccessor HttpCtxAcs { get; set; }
        }

        public static IServiceCollection AddHttpAuthManager(this IServiceCollection service)
        {
            NancyHttpContextAccessor.HttpCtxAcs = Factory.Create(service);
            
            return service;
        }
    }
}

namespace Nancy
{
    public static class AuthManagerExtension
    {
        public static AuthenticationManager GetAuthenticationManager(this NancyContext context, bool throwOnNull = false)
        {
            return Owin.AuthManagerExtension.NancyHttpContextAccessor.HttpCtxAcs.HttpContext.Authentication;
        }
    }
}
