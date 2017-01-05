using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    public class Usuario
    {
        public Int32 id { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int? plan_id { get; set; }
        public List<string> permisos { get; set; }
        public int rol_seleccionado_id { get; set; }
        public string rol_seleccionado_descripcion { get; set; }
        public string nick_usuario { get; set; }
        public string password { get; set; }

    }
}