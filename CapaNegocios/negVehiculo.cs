using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class negVehiculo
    {
        datVehiculo datVehiculo = new datVehiculo();
        public string CreaVehiculo(entVehiculo entVehiculo)
        {

            return datVehiculo.CreaVehiculo(entVehiculo);
        }
        public DataTable MuestraVehiculo()
        {
            return datVehiculo.MuestraVehiculo();
        }

        public string EliminaVehiculo(int idVehiculo)
        {
            return datVehiculo.EliminaVehiculo(idVehiculo);
        }

        public string ModificaVehiculo(entVehiculo entVehiculo)
        {

            return datVehiculo.ModificaVehiculo(entVehiculo);
        }
        public DataTable ConsultaVehiculo(int idVehiculo)
        {

            return datVehiculo.ConsultaVehiculo(idVehiculo);
        }
    }
}
