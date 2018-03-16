using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AvaliaSim.Startup))]
namespace AvaliaSim
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
