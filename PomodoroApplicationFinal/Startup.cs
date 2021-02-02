using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using Owin;
using Pomodoro.Contracts;
using Pomodoro.Services;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(PomodoroApplicationFinal.Startup))]
namespace PomodoroApplicationFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterType<AssignmentService>().As<IAssignmentService>();
            builder.RegisterType<RewardService>().As<IRewardService>();
            builder.RegisterType<AchievementServices>().As<IAchievementService>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            ConfigureAuth(app);
            //CreateAdmin();
            
        }
    }
}
