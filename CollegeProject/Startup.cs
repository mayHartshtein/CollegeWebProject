using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CollegeProject.Startup))]
namespace CollegeProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
