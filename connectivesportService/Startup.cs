using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(connectivesportService.Startup))]

namespace connectivesportService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}