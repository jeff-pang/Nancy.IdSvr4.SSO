using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSOServer.Providers
{
    public interface IClientProvider
    {
        List<Client> GetClients();
    }
}