using CitrixServices.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitrixServices.XenServer
{
    public class XenServerAPIRoute : ICitrixAPIRoute
    {
        public string Controller { get; set; }
        public string Name { get; set; }
        public string Route { get; set; }
    } 
}
