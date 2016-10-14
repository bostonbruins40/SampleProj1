using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleProj1.Startup))]
namespace SampleProj1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
