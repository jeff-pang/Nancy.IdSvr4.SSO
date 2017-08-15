using Nancy;
using Nancy.Security;

namespace AuthNX.Core.WebApi
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
