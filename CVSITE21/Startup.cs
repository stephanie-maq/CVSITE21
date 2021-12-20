using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CVSITE21.Startup))]
namespace CVSITE21
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
