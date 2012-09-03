using CitrixServices.Plugin;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitrixServices.XenServer
{
    [Export(typeof(ICitrixAPIModule))]
    public class XenServerAPIModule : ICitrixAPIModule
    {
        public List<ICitrixAPIRoute> Routes()
        {
            return new List<ICitrixAPIRoute>
            {
                new XenServerAPIRoute{ Controller="Servers", Name="XenServers API Route", Route="XenServer/Servers"},
                new XenServerAPIRoute{ Controller="VirtualMachines", Name="Virtual Machine API Route", Route="XenServer/vms"}
            };
        }
        public string Name
        {
            get
            {
                return "XenServer API Module";
            }
        }
        public string Version 
        {
            get
            {
                return "0.0.1";
            }
        }
    }
}
