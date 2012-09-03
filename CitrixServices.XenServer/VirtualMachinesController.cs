using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CitrixServices.XenServer
{
    public class VirtualMachinesController : ApiController
    {
        public string Get()
        {
            return "Return a list of Virtual Machines";
        }
    }
}
