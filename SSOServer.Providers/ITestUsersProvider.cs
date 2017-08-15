using IdentityServer4.Test;
using System.Collections.Generic;

namespace SSOServer.Providers
{
    public interface ITestUsersProvider
    {
        List<TestUser> GetTestUsers();
    }
}