using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LanceUmDesafio.Startup))]
namespace LanceUmDesafio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
