using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entRuta
    {
        public int idRuta { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime horaSalida { get; set; }
        public DateTime horaLlegada { get; set; }
        public bool bActivo { get; set; }
    }
}
