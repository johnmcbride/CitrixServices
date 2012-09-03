using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http.Dispatcher;

namespace CitrixServices.Site.Resolvers
{
    public class PluginAssemblyResolver : IAssembliesResolver
    {
        public ICollection<Assembly> GetAssemblies()
        {
            List<Assembly> _pluginAssemblies = new List<Assembly>();

            string _binFolder = System.Web.HttpContext.Current.Server.MapPath("~/bin");
            string _pluginFolder = string.Format(@"{0}\{1}", _binFolder, @"plugins");

            foreach (string file in System.IO.Directory.GetFiles(_pluginFolder))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(file);
                if (fi.Extension.IndexOf("dll") > -1)
                {
                    Assembly a = Assembly.LoadFrom(file);
                    _pluginAssemblies.Add(a);
                }
            }
            return _pluginAssemblies;
        }
    }
}