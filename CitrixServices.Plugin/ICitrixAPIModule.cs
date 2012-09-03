using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitrixServices.Plugin
{
    public interface ICitrixAPIModule
    {
        List<ICitrixAPIRoute> Routes();
        string Name { get; }
        string Version { get; }
    }
}
