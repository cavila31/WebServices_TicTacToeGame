using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECCI_Gato.Startup))]
namespace ECCI_Gato
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
