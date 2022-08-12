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
    public class negPasajero
    {
        datPasajero datPasajero = new datPasajero();
        public string CreaPasajero(entPasajero entPasajero)
        {

            return datPasajero.CreaPasajero(entPasajero);
        }
        public DataTable MuestraPasajero()
        {
            return datPasajero.MuestraPasajero();
        }

        public string EliminaPasajero(int idPasajero)
        {
            return datPasajero.EliminaPasajero(idPasajero);
        }

        public string ModificaPasajero(entPasajero entPasajero)
        {

            return datPasajero.ModificaPasajero(entPasajero);
        }
        public DataTable ConsultaPasajero(int idPasajero)
        {

            return datPasajero.ConsultaPasajero(idPasajero);
        }

    }
}
