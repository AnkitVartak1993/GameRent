using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GamesRent.Startup))]
namespace GamesRent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
