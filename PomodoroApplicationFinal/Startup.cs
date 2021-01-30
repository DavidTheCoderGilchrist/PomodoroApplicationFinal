using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PomodoroApplicationFinal.Startup))]
namespace PomodoroApplicationFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
