using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Navicon.Startup))]
namespace Navicon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
