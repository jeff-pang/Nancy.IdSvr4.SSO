using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace SSOServer.Providers.Mock
{
    public class InMemoryClientProvider : IClientProvider
    {
        public List<Client> GetClients()
        {
            return new List<Client> {
                new Client
                {
                    ClientId = "nancy",
                    ClientName = "Nancy Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    RequireConsent = false,
                    // where to redirect to after login
                    RedirectUris = { "http://localhost/signin-oidc" },
                    
                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "http://localhost/account/logout" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        }
    }
}
