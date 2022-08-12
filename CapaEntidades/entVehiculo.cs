using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entVehiculo
    {
        public int idVehiculo { get; set; }
        public string matricula { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
        public int capacidad { get; set; }
        public string descripcion { get; set; }
        
        public bool bActivo { get; set; }
    }
}
