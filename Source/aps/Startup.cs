using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MSA.Startup))]
namespace MSA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
