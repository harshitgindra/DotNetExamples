using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNet.App_Start.Startup))]
namespace DotNet.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}