using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSOServer.Providers
{
    public interface IResourceProvider
    {
        List<ApiResource> GetApiResources();
        List<IdentityResource> GetIdentityResouces();
    }
}