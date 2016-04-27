using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ottelutietopalvelu.Startup))]
namespace Ottelutietopalvelu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
