using SSOServer.Core.IocRegistrations;
using SSOServer.Providers;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSOServer.Core.Providers
{
    public class ProviderManager
    {
        private static ProviderManager _instance;
        public static ProviderManager Config
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProviderManager();
                }
                return _instance;
            }
        }

        public IClientProvider ClientProvider { get; private set; }
        public IResourceProvider ResourceProvider { get; private set; }
        public ITestUsersProvider TestUsersProvider { get; private set; }

        private ProviderManager()
        {
            var registry = new Registry();
            registry.IncludeRegistry<ProviderRegistry>();
            var map = new Container(registry);

            ClientProvider = map.GetInstance<IClientProvider>();
            ResourceProvider = map.GetInstance<IResourceProvider>();
            TestUsersProvider = map.GetInstance<ITestUsersProvider>();
        }
    }
}
