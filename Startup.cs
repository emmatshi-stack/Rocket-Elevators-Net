using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rocket_elevator_ui.Startup))]
namespace rocket_elevator_ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
