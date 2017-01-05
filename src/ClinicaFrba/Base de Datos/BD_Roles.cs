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
    class BD_Roles
    {

        public static void crear_rol(string nombre_rol, List<String> funcionalidades_descripcion)
        {
            try
            {
                string procedure = "KFC.pro_crear_rol";
                SqlParameter parametro1 = new SqlParameter("@descripcion", SqlDbType.Text);
                parametro1.Value = nombre_rol;
                SqlParameter parametroOutput = new SqlParameter("@id", SqlDbType.Int);
                parametroOutput.DbType = DbType.Int32;
                parametroOutput.Direction = ParameterDirection.Output;
                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametroOutput);
                SqlCommand procedureEjecutado = InteraccionDB.ejecutar_storedProcedureConRetorno(procedure, parametros);
                int id_rol_creado = 0;
                id_rol_creado = Convert.ToInt32(procedureEjecutado.Parameters["@id"].Value);
                if (id_rol_creado <= 0) throw new Exception("No se creo el Rol, el Procedure que Crea los Roles devolvio ID invalido. ");

                //Inserto Cada Funcionalidad
                foreach (var funcionalidad in funcionalidades_descripcion)
                {
                    insertar_funcionalidad(id_rol_creado, funcionalidad);
                }

                return;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }

        public static void insertar_funcionalidad(int id_rol, string descripcion_funcionalidad)
        {
            try
            {
                string procedure = "KFC.pro_crear_funcionalidad_de_rol";
                SqlParameter parametro1 = new SqlParameter("@func_desc", SqlDbType.Text);
                SqlParameter parametro2 = new SqlParameter("@rol_id", SqlDbType.Int);
                parametro1.Value = descripcion_funcionalidad;
                parametro2.Value = id_rol;
                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                var reader = InteraccionDB.ejecutar_storedProcedure(procedure, parametros);

                //Veo si trajo datos o no. No se porque siempre devuelve -1
                if (reader.RecordsAffected != -1) throw new Exception("No se pudo asignar la Funcionalidad al Rol:'" + id_rol + "'.");
                //MessageBox.Show("Insertada funcionalidad: " + descripcion_funcionalidad, "Crear o Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.None);

                return;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }

        public static void quitar_funcionalidad(int id_rol, string descripcion_funcionalidad)
        {
            try
            {
                string procedure = "KFC.pro_quitar_funcionalidad_de_rol";
                SqlParameter parametro1 = new SqlParameter("@func_desc", SqlDbType.Text);
                SqlParameter parametro2 = new SqlParameter("@rol_id", SqlDbType.Int);
                parametro1.Value = descripcion_funcionalidad;
                parametro2.Value = id_rol;
                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                var reader = InteraccionDB.ejecutar_storedProcedure(procedure, parametros);

                //Veo si trajo datos o no. No se porque siempre devuelve -1
                if (reader.RecordsAffected != -1) throw new Exception("No se pudo quitar la Funcionalidad al Rol:'" + id_rol + "'.");

                //MessageBox.Show("Quitada funcionalidad: " + descripcion_funcionalidad, "Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.None);

                return;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }


        public static void setear_habilitacion(int id_rol, bool estado)
        {
            try
            {
                string procedure = "KFC.pro_setear_rol_estado_habilitacion";
                SqlParameter parametro1 = new SqlParameter("@rol_id", SqlDbType.Int);
                SqlParameter parametro2 = new SqlParameter("@estado", SqlDbType.Int);
                parametro1.Value = id_rol;

                //Por ser Bit en SQL Server 1 significa true, 0 significa false
                if (estado == true)
                    parametro2.Value = 1;
                else
                    parametro2.Value = 0;
                

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);


                var reader = InteraccionDB.ejecutar_storedProcedure(procedure, parametros);

                //Veo si trajo datos o no
                //if (reader.RecordsAffected != 1) throw new Exception("No se pudo modificar Estado al Rol:'" + id_rol + "'. ");
                if (reader.RecordsAffected <= 0) throw new Exception("No se pudo modificar Estado al Rol:'" + id_rol + "'.");

                //MessageBox.Show("Modificado Estado Habilitacion de Rol a: " + estado, "Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.None);

                return;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }


        public static List<string> obtener_funcionalidades_rol(int id_rol)
        {
            try
            {
                string funcion = "SELECT * FROM  KFC.fun_obtener_funcion_rol(@id_rol)";
                SqlParameter parametro = new SqlParameter("@id_rol", SqlDbType.Int);
                parametro.Value = id_rol;
                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);
                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);
                List<string> funcionalidades = InteraccionDB.ObtenerStringsReader(reader, 1);

                return funcionalidades;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw new Exception("No Pudieron Obtenerse Funcionalidades. Error: " + e.Message);
            }
        }

        public static List<string> obtener_roles()
        {
            try
            {
                string funcion = "SELECT * FROM  KFC.fun_obtener_todas_los_roles()";
                var parametros = new List<SqlParameter>();
                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);
                List<string> roles = InteraccionDB.ObtenerStringsReader(reader, 1);

                return roles;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw new Exception("No Pudieron Obtenerse Todos los Roles. Error: " + e.Message);
            }
        }

        public static int obtenerID_rol(string nombre)
        {
            try
            {
                string funcion = "SELECT KFC.fun_retornar_id_rol(@rol_nombre)";
                SqlParameter parametro = new SqlParameter("@rol_nombre", SqlDbType.Text);
                parametro.Value = nombre.ToUpper();
                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

                int id = -1;
                try
                {
                    var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);
                    id = InteraccionDB.ObtenerIntReader(reader, 0);
                    if (id == -1) throw new Exception("No Se encuentra al ROL");
                }
                catch (Exception e)
                {
                    InteraccionDB.ImprimirExcepcion(e);
                    throw new Exception("No existe el Rol. Error: " + e.Message);
                }

                return id;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw new Exception("No Pudieron Obtenerse el Rol. Error: " + e.Message);
            }
        }

        public static bool obtener_estado_habilitado_rol(int id_rol)
        {
            try
            {
                string funcion = "SELECT KFC.fun_obtener_habilitacion_rol(@id_rol)";
                SqlParameter parametro = new SqlParameter("@id_rol", SqlDbType.Int);
                parametro.Value = id_rol;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

                bool estado_habilitacion;
                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);
                estado_habilitacion = InteraccionDB.ObtenerBoolReader(reader, 0);

                return estado_habilitacion;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw new Exception("No pudo ver si el Rol esta Habilitado o No. Error: " + e.Message);
            }
        }
    }
}
