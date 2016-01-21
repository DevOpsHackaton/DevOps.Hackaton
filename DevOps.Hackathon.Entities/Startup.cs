using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevOps.Hackathon.Entities.Startup))]
namespace DevOps.Hackathon.Entities
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
