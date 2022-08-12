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
    public class negTipoPasajero
    {
        datTipoPasajero datTipoPasajero = new datTipoPasajero();
        public string CreaTipoPasajero(entTipoPasajero entTipoPasajero)
        {

            return datTipoPasajero.CreaTipoPasajero(entTipoPasajero);
        }
        public DataTable MuestraTipoPasajero()
        {
            return datTipoPasajero.MuestraTipoPasajero();
        }

        public string EliminaTipoPasajero(int idTipoPasajero)
        {
            return datTipoPasajero.EliminaTipoPasajero(idTipoPasajero);
        }

        public string ModificaTipoPasajero(entTipoPasajero entTipoPasajero)
        {

            return datTipoPasajero.ModificaTipoPasajero(entTipoPasajero);
        }
        public DataTable ConsultaTipoPasajero(int idTipoPasajero)
        {

            return datTipoPasajero.ConsultaTipoPasajero(idTipoPasajero);
        }
    }
}
