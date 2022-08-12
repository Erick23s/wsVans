using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entReserva
    {
        public int idReserva { get; set; }
        public int idPasajero { get; set; }
        public int idRuta { get; set; }
        public int idvehiculo { get; set; }
        public int Asiento { get; set; }
        public DateTime horaReserva { get; set; }
        public bool bActivo { get; set; }

    }

}
