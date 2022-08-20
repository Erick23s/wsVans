using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entPasajero
    {
        public int idPasajero { get; set; }
        public string nombre { get; set; }
        public string  apellido { get; set; }
        public string telefono { get; set; }
        public int  idTipoPasajero { get; set; }
        public string TipoPasajero { get; set; }
        public bool bActivo { get; set; }

    }
}
