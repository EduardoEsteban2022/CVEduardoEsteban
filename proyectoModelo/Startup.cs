using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proyectoModelo.Startup))]
namespace proyectoModelo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
