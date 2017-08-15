using System;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace SSOServer.Providers.Mock
{
    public class InMemoryTestUsersProvider : ITestUsersProvider
    {
        public List<TestUser> GetTestUsers()
        {
            return new List<TestUser> {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password"
                }
            };
        }
    }
}
