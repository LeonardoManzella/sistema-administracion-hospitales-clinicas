using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Base_de_Datos;

namespace ClinicaFrba.Negocio
{
     public static class Log_In
    {
        public static Usuario Ingresar_App(string usuario,string password, string rol_descripcion)
        {
            try
            {
                var valido = validar_datos_login(usuario, password, rol_descripcion);
                if (valido)
                    return BD_Log_In.validar_obtener_usuario(usuario, password, rol_descripcion);
                else
                    throw new  Exception("Ha ocurrido un problema, ni el usuario ni la contraseña ni el rol pueden estar en blanco");

            }
            catch(Exception e)
            {
                throw e; 
            }

        }
        private static bool validar_datos_login(string usuario, string password, string rol_descripcion)
        {
            return !(String.IsNullOrEmpty(usuario) && String.IsNullOrEmpty(password) && String.IsNullOrEmpty(rol_descripcion));
        }
    }
}
