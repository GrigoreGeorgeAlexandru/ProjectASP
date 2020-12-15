using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectASP.Startup))]
namespace ProjectASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
