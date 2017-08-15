using SSOServer.Providers;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace SSOServer.Core.IocRegistrations
{
    public class ProviderRegistry : Registry
    {
        private const string PROVIDER_ASM_NAME = "SSOServer.Providers.Mock";
        public ProviderRegistry()
        {
            Scan(x => {
                x.Assembly(AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(PROVIDER_ASM_NAME)));
                x.AddAllTypesOf<IClientProvider>();
                x.AddAllTypesOf<IResourceProvider>();
                x.AddAllTypesOf<ITestUsersProvider>();
            });
        }
    }
}
