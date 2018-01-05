using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eFlorist.Startup))]
namespace eFlorist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
