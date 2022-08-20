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
        public int idVehiculo { get; set; }
        public string Pasajero { get; set; }
        public string Ruta { get; set; }
        public string Vehiculo { get; set; }

        public string Asiento { get; set; }
        //public DateTime horaReserva { get; set; }
        public string horaReserva { get; set; }
        public string horaModificacion { get; set; }
        public bool bActivo { get; set; }

    }

}
