using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proiect_IAME.Startup))]
namespace Proiect_IAME
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
