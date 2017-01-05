using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaFrba.Base_de_Datos
{
    public static class BD_LLegada
    {
        /*
        /// <summary>
        /// Obtiene los turnos para el dia de hoy del paciente
        /// </summary>
        /// <param name="afiliado_id"></param>
        /// <param name="especialidad_id"></param>
        /// <param name="profesional_id"></param>
        /// <returns></returns>
        public static List<Turno> get_turno_hoy_paciente(int afiliado_id, int especialidad_id, int profesional_id)
        {

            try
            {
                //Declaro un Objeto del tipo del retorno
                var lista_turnos = new List<ComboData>();

                //creo la tabla que va a traer los registros
                DataTable dt = new DataTable();

                SqlConnection conexion = Conexion.Instance.get();

                string sql = "kfc.get_turno_hoy_paciente @afiliado_id, @especialidad_id, @profesional_id, @fecha ";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                var parametro1 = new SqlParameter("@afiliado_id", SqlDbType.Int);
                var parametro2 = new SqlParameter("@especialidad_id", SqlDbType.Int);
                var parametro3 = new SqlParameter("@profesional_id", SqlDbType.Int);
                var parametro4 = new SqlParameter("@fecha", SqlDbType.DateTime);
                parametro1.Value = afiliado_id;
                parametro2.Value = especialidad_id;
                parametro3.Value = profesional_id;
                parametro4.Value = DateTime.Today;
                cmd.Parameters.Add(parametro1);
                cmd.Parameters.Add(parametro2);
                cmd.Parameters.Add(parametro3);
                cmd.Parameters.Add(parametro4);
                //Lleno la tabla
                da.Fill(dt);

                //La recorro para armar la lista
                foreach (DataRow pRow in dt.Rows)
                {
                    //...
                    lista_turnos.Add(esp);
                }

                return lista_turnos;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);
                throw e;
            }
        }
        */

        /// <summary>
        /// Obtiene los turnos para el dia de hoy del paciente
        /// </summary>
        /// <param name="afiliado_id"></param>
        /// <param name="especialidad_id"></param>
        /// <param name="profesional_id"></param>
        /// <returns></returns>
        public static List<ComboData> get_turno_hoy(int afiliado_id, int especialidad_id, int profesional_id)
        {

            try
            {
                //Declaro un Objeto del tipo del retorno
                var lista_turnos = new List<ComboData>();

                //creo la tabla que va a traer los registros
                DataTable dt = new DataTable();

                SqlConnection conexion = Conexion.Instance.get();

                string sql = "kfc.get_turno_hoy @afiliado_id, @especialidad_id, @profesional_id, @fecha ";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                var parametro1 = new SqlParameter("@afiliado_id", SqlDbType.Int);
                var parametro2 = new SqlParameter("@especialidad_id", SqlDbType.Int);
                var parametro3 = new SqlParameter("@profesional_id", SqlDbType.Int);
                var parametro4 = new SqlParameter("@fecha", SqlDbType.Time);
                parametro1.Value = afiliado_id;
                parametro2.Value = especialidad_id;
                parametro3.Value = profesional_id;
                parametro4.Value = DateTime.Parse(Configuracion_Global.fecha_actual);
                cmd.Parameters.Add(parametro1);
                cmd.Parameters.Add(parametro2);
                cmd.Parameters.Add(parametro3);
                cmd.Parameters.Add(parametro4);
                //Lleno la tabla
                da.Fill(dt);

                //La recorro para armar la lista
                foreach (DataRow pRow in dt.Rows)
                {
                    var esp = new ComboData(pRow["id"], pRow["descripcion"]);
                    lista_turnos.Add(esp);
                }

                return lista_turnos;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                throw e;
            }
        }
        
        /// <summary>
        /// registrar la llegada de un paciente al turno 
        /// </summary>
        /// <param name="id_afiliado"></param>
        /// <param name="id_turno"></param>
        /// <param name="id_bono"></param>
        /// <returns></returns>
        public static void registrar_llegada(int id_afiliado, int id_turno, int id_bono, TimeSpan hora)
        {
            try
            {
                string sql = "KFC.registrar_llegada";

                SqlParameter parametro1 = new SqlParameter("@id_afiliado", SqlDbType.Int);
                parametro1.Value = id_afiliado;
                SqlParameter parametro2 = new SqlParameter("@id_turno", SqlDbType.Int);
                parametro2.Value = id_turno;
                SqlParameter parametro3 = new SqlParameter("@id_bono", SqlDbType.Int);
                parametro3.Value = id_bono;
                SqlParameter parametro4 = new SqlParameter("@hora", SqlDbType.Time);
                parametro4.Value = hora;
                SqlParameter parametro5 = new SqlParameter("@fecha", SqlDbType.DateTime);
                parametro5.Value = DateTime.Parse(Configuracion_Global.fecha_actual);

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);
                parametros.Add(parametro5);

                InteraccionDB.ejecutar_storedProcedure(sql, parametros);
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                throw e;
            }
        }

        public static void registrar_atencion(int turnoID, string diagnostico, string sintomas, DateTime horaConfigurada)
        {
            try
            {
                string sql = "KFC.pro_registrar_atencion";

                SqlParameter parametro1 = new SqlParameter("@turno_id", SqlDbType.Int);
                parametro1.Value = turnoID;
                SqlParameter parametro2 = new SqlParameter("@diagnostico", SqlDbType.VarChar);
                parametro2.Value = diagnostico;
                SqlParameter parametro3 = new SqlParameter("@sintomas", SqlDbType.VarChar);
                parametro3.Value = sintomas;
                SqlParameter parametro4 = new SqlParameter("@fecha", SqlDbType.DateTime);
                parametro4.Value = horaConfigurada;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);

                InteraccionDB.ejecutar_storedProcedure(sql, parametros);
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                throw e;
            }
        }
    }
}
