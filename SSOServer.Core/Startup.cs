using Nancy.Owin;
using SSOServer.Core.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Microsoft.Extensions.Logging;

namespace SSOServer.Core
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDistributedMemoryCache()
                .AddSession(opt => opt.CookieName = "id")
                .AddNancyAspnetCoreSession()
                .AddHttpAuthManager()
                .AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryIdentityResources(ProviderManager.Config.ResourceProvider.GetIdentityResouces())
                .AddTestUsers(ProviderManager.Config.TestUsersProvider.GetTestUsers())
                .AddInMemoryApiResources(ProviderManager.Config.ResourceProvider.GetApiResources())
                .AddInMemoryClients(ProviderManager.Config.ClientProvider.GetClients());
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory logger)
        {
            logger.AddSerilog();

            app
            .UseSession()
            .UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "Cookies"
            })
            .UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            {
                AuthenticationScheme = "oidc",
                SignInScheme = "Cookie",
                Authority = "http://localhost",
                RequireHttpsMetadata = false,
                ClientId = "nancy",
                SaveTokens = true
            })
            .UseIdentityServer()
            .UseOwin(x => {
                x.UseNancy();
            });
        }
    }
}
