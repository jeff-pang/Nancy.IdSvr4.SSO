using IdentityServer4.Models;
using System.Collections.Generic;

namespace SSOServer.Providers.Mock
{
    public class InMemoryResourceProvider : IResourceProvider
    {
        public List<ApiResource> GetApiResources()
        {
            return new List<ApiResource> {
                  new ApiResource("api1", "My API 1")
            };
        }

        public List<IdentityResource> GetIdentityResouces()
        {
            return new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile()
                };
        }
    }
}
