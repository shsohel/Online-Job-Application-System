using JobMvcApi.Models;
using JobMvcApi.Models.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JobMvcApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);



            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
        //public static void Register(HttpConfiguration config)
        //{
        //    var container = new Container();
        //    container<IRepository<PersonalDetail>, Repository<PersonalDetail>>(new HierarchicalLifetimeManager());
        //    config.DependencyResolver = new UnityResolver(container);
        //    //  container.Equals(IRepository<PersonalDetail>, Repository<PersonalDetail>);

        //    // Other Web API configuration not shown.
        //}
    }
}
