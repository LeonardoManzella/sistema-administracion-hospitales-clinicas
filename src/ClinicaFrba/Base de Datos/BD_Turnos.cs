using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Base_de_Datos
{
    class BD_Turnos
    {




        /// <summary>
        /// Ojo devuelve Lista de Apellido Con Nombre Profesional
        /// </summary>
        /// <param name="descripcionEspecialidad"></param>
        /// <returns></returns>
        public static List<string> obtener_todos_profesionales_para_especialid(string descripcionEspecialidad)
        {
            try
            {
                string funcion = "SELECT  * FROM KFC.fun_obtener_profesionales_por_especialidad(@desc_esp)";
                SqlParameter parametro = new SqlParameter("@desc_esp", SqlDbType.Text);
                parametro.Value = descripcionEspecialidad;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);

                List<string> profesionales = InteraccionDB.ObtenerStringsReader(reader, 1);

                return profesionales;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }

        public static List<string> obtener_turnos_cancelables(Usuario usuario)
        {
            try
            {
                int idAfiliado = BD_Afiliados.obtenerID_afiliado(usuario.nombre, usuario.apellido, usuario.id);

                string funcion = "SELECT  * FROM KFC.fun_obtener_turnos_cancelables(@afil_id, @fecha_formato_string )";
                SqlParameter parametro1 = new SqlParameter("@afil_id", SqlDbType.Int);
                parametro1.Value = idAfiliado;
                SqlParameter parametro2 = new SqlParameter("@fecha_formato_string", SqlDbType.Text);
                parametro2.Value = Configuracion_Global.fecha_actual;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);

                if (!reader.HasRows) throw new Exception("No se han encontrado Turnos Cancelables");

                List<string> turnos = new List<string>();

                while (reader.Read())
                {
                    string profesional = reader.GetString(0);
                    string fecha = reader.GetString(1);
                    string hora = reader.GetTimeSpan(2).ToString();
                    string especialidad = reader.GetString(3);

                    string turno = profesional + " - " + especialidad + " - " + fecha + " - " + hora;
                    turnos.Add(turno);

                }

                if (turnos.Count == 0)
                    throw new Exception("No se Encontraron los turnos Cancelables");

                return turnos;

            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                throw e;
            }

        }

        public static DataTable obtener_turnos_con_llegada(string afiliado_nombre, string afiliado_apellido, string documento, int profID)
        {
            try
            { 
                string funcion = "SELECT * FROM KFC.fun_obtener_turnos_con_llegada(@afil_nombre, @afil_apellido, @documento, @prof_id)";
                SqlParameter parametro1 = new SqlParameter("@afil_nombre", SqlDbType.Text);
                parametro1.Value = afiliado_nombre.ToUpper();
                SqlParameter parametro2 = new SqlParameter("@afil_apellido", SqlDbType.Text);
                parametro2.Value = afiliado_apellido.ToUpper();
                SqlParameter parametro3 = new SqlParameter("@documento", SqlDbType.Text);
                parametro3.Value = documento;
                SqlParameter parametro4 = new SqlParameter("@prof_id", SqlDbType.Int);
                parametro4.Value = profID;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);

                var tabla_datos = InteraccionDB.ejecutar_funcion_table(funcion, parametros);

                return tabla_datos;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                throw e;
            }
}

        public static void cancelar_turnos_pro(DateTime fechaDesde, DateTime fechaHasta, string motivo, int id)
        {
            try
            {
                string procedure = "KFC.pro_cancelar_turno_profesional";
                int prof_id = BD_Profesional.obtenerID_profesional(id);
                SqlParameter parametro1 = new SqlParameter("@fechaDesde", SqlDbType.Date);
                parametro1.Value = fechaDesde;
                SqlParameter parametro2 = new SqlParameter("@fechaHasta", SqlDbType.Date);
                parametro2.Value = fechaHasta;
                SqlParameter parametro3 = new SqlParameter("@prof_id", SqlDbType.Int);
                parametro3.Value = prof_id;
                SqlParameter parametro4 = new SqlParameter("@motivo", SqlDbType.VarChar);
                parametro4.Value = motivo;
                SqlParameter parametro5 = new SqlParameter("@fecha_formato_string", SqlDbType.Text);
                parametro5.Value = Configuracion_Global.fecha_actual;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);
                parametros.Add(parametro5);

                var reader = InteraccionDB.ejecutar_storedProcedure(procedure, parametros);

                if (reader.RecordsAffected <= 0) throw new Exception("No existen turnos en este rango de fechas");

                return;

            }
            catch (Exception ex)
            {
                InteraccionDB.ImprimirExcepcion(ex);
                throw ex;
            }
        }

        public static void cancelar_turno(string nombreProfesional, string apellidoProfesional, string especialidad, DateTime fecha, string hora, string motivo, string tipo)
        {
            try
            {

                string procedure = "KFC.pro_cancelar_turno";
                SqlParameter parametro1 = new SqlParameter("@fecha", SqlDbType.Date);
                parametro1.Value = fecha;
                SqlParameter parametro2 = new SqlParameter("@hora", SqlDbType.Text);
                parametro2.Value = hora;
                SqlParameter parametro3 = new SqlParameter("@espe_desc", SqlDbType.Text);
                parametro3.Value = especialidad;
                SqlParameter parametro4 = new SqlParameter("@prof_nombre", SqlDbType.Text);
                parametro4.Value = nombreProfesional;
                SqlParameter parametro5 = new SqlParameter("@prof_apellido", SqlDbType.Text);
                parametro5.Value = apellidoProfesional;
                SqlParameter parametro6 = new SqlParameter("@motivo", SqlDbType.Text);
                parametro6.Value = motivo;
                SqlParameter parametro7 = new SqlParameter("@tipo", SqlDbType.Text);
                parametro7.Value = tipo;
                SqlParameter parametro8 = new SqlParameter("@fecha_formato_string", SqlDbType.Text);
                parametro8.Value = Configuracion_Global.fecha_actual;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);
                parametros.Add(parametro5);
                parametros.Add(parametro6);
                parametros.Add(parametro7);
                parametros.Add(parametro8);

                var reader = InteraccionDB.ejecutar_storedProcedure(procedure, parametros);

                if (reader.RecordsAffected <= 0) throw new Exception("No se pudo cancelar el turno");

                return;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                throw e;
            }
        }

        public static DataTable obtener_turnos_disponibles(string nombre, string apellido, string descripcion_especialidad, string fecha_texto)
        {
            try
            {
                string funcion = "SELECT  * FROM KFC.fun_obtener_turnos_profesional(@prof_nombre, @prof_apellido, @desc_esp,  @fecha)";
                SqlParameter parametro1 = new SqlParameter("@prof_nombre", SqlDbType.Text);
                parametro1.Value = nombre;
                SqlParameter parametro2 = new SqlParameter("@prof_apellido", SqlDbType.Text);
                parametro2.Value = apellido;
                SqlParameter parametro3 = new SqlParameter("@desc_esp", SqlDbType.Text);
                parametro3.Value = descripcion_especialidad;
                SqlParameter parametro4 = new SqlParameter("@fecha", SqlDbType.Text);
                parametro4.Value = fecha_texto;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);

                var turnos = InteraccionDB.ejecutar_funcion_table(funcion, parametros);

                return turnos;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }

        /// <summary>
        /// Devuelve Excepcion si falla, Caso contrario se ejecuto correctamente
        /// </summary>
        /// <param name="apellidoConNombre"></param>
        /// <param name="fecha"></param>
        /// <param name="descripcionEspecialidad"></param>
        /// <param name="id_afiliado"></param>
        public static void asignar_turno(string prof_nombre, string prof_apellido, DateTime fecha, string horario, string descripcionEspecialidad, int id_afiliado)
        {
            try
            {
                string procedure = "KFC.pro_asignar_turno";
                SqlParameter parametro1 = new SqlParameter("@fecha", SqlDbType.Date);
                parametro1.Value = fecha;
                SqlParameter parametro2 = new SqlParameter("@hora", SqlDbType.Text);
                parametro2.Value = horario;
                SqlParameter parametro3 = new SqlParameter("@espe_desc", SqlDbType.Text);
                parametro3.Value = descripcionEspecialidad;
                SqlParameter parametro4 = new SqlParameter("@prof_nombre", SqlDbType.Text);
                parametro4.Value = prof_nombre;
                SqlParameter parametro5 = new SqlParameter("@prof_apellido", SqlDbType.Text);
                parametro5.Value = prof_apellido;
                SqlParameter parametro6 = new SqlParameter("@afil_id", SqlDbType.Int);
                parametro6.Value = id_afiliado;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);
                parametros.Add(parametro5);
                parametros.Add(parametro6);

                var reader = InteraccionDB.ejecutar_storedProcedure(procedure, parametros);

                //Veo si trajo datos o no
                if (reader.RecordsAffected <= 0) throw new Exception("No se pudo Pedir el Turno");

                return;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }

        /// <summary>
        /// Obtiene los Turnos a partir de filtros Like de nombre y apellido (afiliado y profesional) y descripcion especialidad.
        /// </summary>
        /// <returns></returns>
        public static DataTable obtener_turnos_filtros(string afil_nombre, string afil_apellido, string prof_nombre, string prof_apellido, string descripcion_especialidad)
        {
            try
            {

                string funcion = "SELECT * FROM KFC.fun_obtener_turnos_sin_diagnostico_profesional(@afil_nombre, @afil_apellido, @prof_nombre, @prof_apellido, @prof_especialidad)";
                SqlParameter parametro1 = new SqlParameter("@afil_nombre", SqlDbType.Text);
                parametro1.Value = afil_nombre.ToUpper();
                SqlParameter parametro2 = new SqlParameter("@afil_apellido", SqlDbType.Text);
                parametro2.Value = afil_apellido.ToUpper();
                SqlParameter parametro3 = new SqlParameter("@prof_nombre", SqlDbType.Text);
                parametro3.Value = prof_nombre.ToUpper();
                SqlParameter parametro4 = new SqlParameter("@prof_apellido", SqlDbType.Text);
                parametro4.Value = prof_apellido.ToUpper();
                SqlParameter parametro5 = new SqlParameter("@prof_especialidad", SqlDbType.Text);
                parametro5.Value = descripcion_especialidad.ToUpper();


                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);
                parametros.Add(parametro5);

                var tabla_datos = InteraccionDB.ejecutar_funcion_table(funcion, parametros);

                return tabla_datos;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }
    }
}
