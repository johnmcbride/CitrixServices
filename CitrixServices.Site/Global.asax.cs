using CitrixServices.Plugin;
using CitrixServices.Site.Resolvers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;

namespace CitrixServices.Site
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        //creating the MEF composition container
        CompositionContainer _container;

        //import all classes of type IApiModule (MEF)
        [ImportMany(typeof(ICitrixAPIModule))]
        List<ICitrixAPIModule> _modules;

        protected void Application_Start()
        {
            string _binFolder = Server.MapPath("~/bin");
            string _pluginFolder = string.Format(@"{0}\{1}", _binFolder, @"plugins");

            //check the plugin directory
            if (!System.IO.Directory.Exists(_pluginFolder))
            {
                System.IO.Directory.CreateDirectory(_pluginFolder);
            }
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //load the MEF controllers and add the configured routes
            var config = GlobalConfiguration.Configuration;
            config.Services.Replace(typeof(IAssembliesResolver), new PluginAssemblyResolver());
            

            //defining the catalog to be this currently executing assembly
            //var localCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var pluginCatalog = new DirectoryCatalog(_pluginFolder);
            //new'ing up the container and giving it the catalog
            _container = new CompositionContainer(pluginCatalog);
            //composing all available parts
            _container.ComposeParts(this);
            //looping through each module in the found modules of IApiModule
            foreach (ICitrixAPIModule _module in _modules)
            {
                //foreach module, call the routes method to get the routes defined within the module and
                //add it the routes for the application
                foreach (ICitrixAPIRoute route in _module.Routes())
                {
                    RouteTable.Routes.MapHttpRoute(route.Name, route.Route, defaults: new { controller = route.Controller });
                }
            }
        }
    }
}