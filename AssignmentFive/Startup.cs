using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssignmentFive.Startup))]
namespace AssignmentFive
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
