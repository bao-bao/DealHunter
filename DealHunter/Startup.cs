using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DealHunter.Startup))]
namespace DealHunter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
