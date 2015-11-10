using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using CitizenSC.xDBWebAPI.Common.Settings;
using CitizenSC.xDBWebAPI.Domain;
using CitizenSC.xDBWebAPI.Repository;
using CitizenSC.xDBWebAPI.WebApi;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace CitizenSC.xDBWebAPI.Web
{
   public class WebApiApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
      {
         var container = new Container();
         container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

         container.RegisterSingleton<IApplicationSettings>(new xDBAppSettings());
         container.Register(typeof(IAnalyticsRepository<>), typeof(xDBAnalyticsRepository<>), Lifestyle.Transient);
         container.Register<IContactService, xDBContactService>(Lifestyle.Transient);
         container.Register<IInteractionService, xDBInteractionService>(Lifestyle.Transient);

         container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

         container.Verify();

         GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

         GlobalConfiguration.Configure(WebApiConfig.Register);
      }
   }
}
