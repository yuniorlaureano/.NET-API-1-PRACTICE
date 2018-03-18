using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwitterMvc.Startup))]
namespace TwitterMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
