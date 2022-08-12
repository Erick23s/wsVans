using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entUsuario
    {
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public bool bActivo { get; set; }
        
    }
}
