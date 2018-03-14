using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test0314.Startup))]
namespace Test0314
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
