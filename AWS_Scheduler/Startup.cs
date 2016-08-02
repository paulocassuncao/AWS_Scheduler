using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AWS_Scheduler.Startup))]
namespace AWS_Scheduler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
