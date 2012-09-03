using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitrixServices.Plugin
{
    public interface ICitrixAPIRoute
    {
        string Controller { get; set; }
        string Name { get; set; }
        string Route { get; set; }
    }
}
