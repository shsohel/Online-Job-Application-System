using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using JobMvcApi.Controllers;
using JobMvcApi.Models;
using JobMvcApi.Models.Repository;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace JobMvcApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           
           // config.EnableCors(new EnableCorsAttribute("http://localhost:4200", "*", "*"));
            // Web API configuration and services
            //  EnableCors(origins: "*", headers: "*", methods: "*");
            //      [EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
            config.EnableCors();
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
           // config.Filters.Add(new AuthorizeAttribute());

            var container = new UnityContainer();
            // container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<IRepository<PersonalDetail>, Repository<PersonalDetail>>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Address>, Repository<Address>>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }


    }
}
