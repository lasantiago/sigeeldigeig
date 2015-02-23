using System.Web.Http;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using api;

[assembly: OwinStartup(typeof(Startup))]

namespace api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
            ConfigureAuth(app);
        }
    }
}
