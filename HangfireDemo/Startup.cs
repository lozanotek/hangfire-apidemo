using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using HangfireDemo;

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace HangfireDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            app.ConfigureHangfire(NinjectWebCommon.Bootstrapper.Kernel);
        }
    }
}
