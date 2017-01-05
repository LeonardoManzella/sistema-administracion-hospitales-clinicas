using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Clases;
using ClinicaFrba.Base_de_Datos;
using System.Data;
using System.Windows.Forms;

namespace ClinicaFrba.Base_de_Datos
{
    class BD_Log_In
    {

        public static Usuario validar_obtener_usuario(string usuario, string password, string rol_descripcion)
        {
            try
            {
                /*
                string funcion = "SELECT KFC.fun_validar_usuario(@user, @contrasenia, @rol_desc)";
                SqlParameter parametro1 = new SqlParameter("@user", SqlDbType.Text);
                parametro1.Value = usuario.ToUpper();
                SqlParameter parametro2 = new SqlParameter("@contrasenia", SqlDbType.Text);
                parametro2.Value = password.ToUpper();
                SqlParameter parametro3 = new SqlParameter("@rol_desc", SqlDbType.Text);
                parametro3.Value = rol_descripcion.ToUpper();

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);
                */

                
                
                string procedure = "KFC.pro_validar_usuario";
                SqlParameter parametro1 = new SqlParameter("@usuario", SqlDbType.Text);
                parametro1.Value = usuario.ToUpper();
                SqlParameter parametro2 = new SqlParameter("@contrasenia", SqlDbType.Text);
                parametro2.Value = password.ToUpper();
                SqlParameter parametro3 = new SqlParameter("@rol_desc", SqlDbType.Text);
                parametro3.Value = rol_descripcion.ToUpper();
                SqlParameter parametroOutput = new SqlParameter("@id", SqlDbType.Int);
                parametroOutput.DbType = DbType.Int32;
                parametroOutput.Direction = ParameterDirection.Output;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametroOutput);

                int id = -1;
                //Encapsulo Obtener ID usuario paara ver si fallo contrasenia y aumentar intentos fallidos
                try
                {
                    SqlCommand procedureEjecutado = InteraccionDB.ejecutar_storedProcedureConRetorno(procedure, parametros);
                    id = Convert.ToInt32(procedureEjecutado.Parameters["@id"].Value);
                    if (id <= 0) throw new Exception("Usuario Inexistente, Esta mal la Contraseña o no esta Habilitado el Usuario");
                }
                catch (Exception e)
                {
                    InteraccionDB.ImprimirExcepcion(e);

                    if (e.Message.Contains("Esta Mal la Contrasenia")) intentos_aumentar_fallidos_logIn(usuario);
                    throw new Exception(e.Message);
                    //throw new Exception("Usuario Inexistente,   Esta mal la Contraseña,   el Rol no pertenece al Usuario   o No esta Habilitado el Usuario");
                }

                //Encapsulo reiniciar intentos, si falla solo es un warning no debe parar todo.
                try
                {
                    intentos_reiniciar(usuario);
                }
                catch (Exception e)
                {
                    InteraccionDB.ImprimirExcepcion(e);
                    MessageBox.Show("WARNING: No pudo Reiniciarse Intentos Usuario. Es raro.  " + e.Message, "Log_In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Usuario user = cargar_datos(id, rol_descripcion);

                return user;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                throw new Exception("Error al Validar Datos Logueo.  " + e.Message);
            }
        }

        private static Usuario cargar_datos(int usuario_id, string rol_descripcion)
        {
            try
            {

                var usuario = new Usuario();
                usuario.id = usuario_id;
                usuario.rol_seleccionado_descripcion = rol_descripcion;

                string funcion = "SELECT * FROM KFC.fun_obtener_funcionalidades_usuario(@usuario_id, @rol_descripcion)";
                SqlParameter parametro1 = new SqlParameter("@usuario_id", SqlDbType.Int);
                parametro1.Value = usuario_id;
                SqlParameter parametro2 = new SqlParameter("@rol_descripcion", SqlDbType.Text);
                parametro2.Value = rol_descripcion;


                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);
                usuario.permisos = InteraccionDB.ObtenerStringsReader(reader, 0);

                //Otros valores falta ver que hacemos con eso. No es necesario Obtenerlos de la Base.
                funcion = "SELECT * FROM KFC.fun_obtener_datos_usuario(@usuario_id)";
                parametro1 = new SqlParameter("@usuario_id", SqlDbType.Int);
                parametro1.Value = usuario_id;
                parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                reader = InteraccionDB.ejecutar_funcion(funcion, parametros);
                var lista = InteraccionDB.ObtenerStringDeColumnasReader(reader, 2);
                usuario.nombre = lista.ToArray()[0];
                usuario.apellido = lista.ToArray()[1];
                return usuario;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }

        private static void intentos_reiniciar(string usuario)
        {
            try
            {
                string procedure = "KFC.pro_reiniciar_intentos";
                SqlParameter parametro = new SqlParameter("@usu_nick", SqlDbType.Text);
                parametro.Value = usuario;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);


                var reader = InteraccionDB.ejecutar_storedProcedure(procedure, parametros);

                //Veo si trajo datos o no
                if (reader.RecordsAffected <= 0)
                    throw new Exception("No se pudo Reiniciar intentos a usuario: ");
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                throw e;
            }
        }

        private static void intentos_aumentar_fallidos_logIn(string usuario)
        {
            try
            {
                string procedure = "KFC.pro_aumentar_intentos";
                SqlParameter parametro = new SqlParameter("@usu_nick", SqlDbType.Text);
                parametro.Value = usuario;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);


                var reader = InteraccionDB.ejecutar_storedProcedure(procedure, parametros);

                //Veo si trajo datos o no.
                if (reader.RecordsAffected <= 0)
                    throw new Exception("No se pudo Aumentar intentos fallidos a usuario");
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                throw e;
            }
        }
    }
}
