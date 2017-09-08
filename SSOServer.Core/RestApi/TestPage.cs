using Nancy;
using Nancy.Security;

namespace SSOServer.Core.RestApi
{
    public class TestPage:NancyModule
    {
        public TestPage():base("test")
        {
            Get("/secured", p => {
                this.RequiresAuthentication();
                return "Hello";
            });

            Get("/unsecured", p => "Hello");
        }
    }
}
