using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace APICalle
{
    public class configReader
    {
        public string test { get; set; }
        public string ruta { get; set; }
        
        public string rutapizza { get; set; }

        public configReader()
        {
            test = ConfigurationManager.AppSettings["test"];
            ruta = ConfigurationManager.AppSettings["ruta"];
            rutapizza = ConfigurationManager.AppSettings["rutapizza"];
        }

    }
}
