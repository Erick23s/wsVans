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
    public class negUsuario
    {
        datUsuario datUsuario = new datUsuario();
        public string CreaUsuario(entUsuario entUsuario)
        {

            return datUsuario.CreaUsuario(entUsuario);
        }
        public DataTable MuestraUsuario()
        {
            return datUsuario.MuestraUsuario();
        }

        public string EliminaUsuario(int idUsuario)
        {
            return datUsuario.EliminaUsuario(idUsuario);
        }

        public string ModificaUsuario(entUsuario entUsuario)
        {

            return datUsuario.ModificaUsuario(entUsuario);
        }
        public DataTable ConsultaUsuario(int idUsuario)
        {

            return datUsuario.ConsultaUsuario(idUsuario);
        }
    }
}
