using System;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaFrba.Base_de_Datos
{
    public static class BD_Estadisticas
    {

        /// <summary>
        /// Obtiene las 5 Especialidades mas canceladas
        /// </summary>
        /// <param name="año"></param>
        /// <param name="inicio"></param>
        /// <param name="fin"></param>
        /// <returns></returns>
        public static DataTable get_top5_canc_esp(int año, int inicio, int fin, int cancelador)
        {
            try
            {

                string sql = "KFC.pro_top_5_cancelaciones_especialidad  @año, @plazo_init, @plazo_fin, @cancelador";

                SqlParameter parametro1 = new SqlParameter("@año", SqlDbType.Int);
                parametro1.Value = año;
                SqlParameter parametro2 = new SqlParameter("@plazo_init", SqlDbType.Int);
                parametro2.Value = inicio;
                SqlParameter parametro3 = new SqlParameter("@plazo_fin", SqlDbType.Int);
                parametro3.Value = fin;
                SqlParameter parametro4 = new SqlParameter("@cancelador", SqlDbType.Int);
                parametro4.Value = cancelador;

                SqlCommand cmd = new SqlCommand(sql, Conexion.Instance.get());

                cmd.Parameters.Add(parametro1);
                cmd.Parameters.Add(parametro2);
                cmd.Parameters.Add(parametro3);
                cmd.Parameters.Add(parametro4);

                DataTable dt = new DataTable();


                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //Lleno la tabla
                da.Fill(dt);

                return dt;

            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                return new DataTable();
            }
        }

        /// <summary>
        /// Top 5 profesionales mas consultados por plan
        /// </summary>
        /// <param name="plan_id"></param>
        /// <param name="año"></param>
        /// <param name="inicio"></param>
        /// <param name="fin"></param>
        /// <returns></returns>
        public static DataTable get_top5_prof_plan(int año, int inicio, int fin, int plan_id)
        {
            try
            {
                string sql = "KFC.pro_top_5_profesional_popular  @año, @plazo_init, @plazo_fin, @plan_id";

                SqlParameter parametro1 = new SqlParameter("@año", SqlDbType.Int);
                parametro1.Value = año;
                SqlParameter parametro2 = new SqlParameter("@plazo_init", SqlDbType.Int);
                parametro2.Value = inicio;
                SqlParameter parametro3 = new SqlParameter("@plazo_fin", SqlDbType.Int);
                parametro3.Value = fin;
                SqlParameter parametro4 = new SqlParameter("@plan_id", SqlDbType.Int);
                parametro4.Value = plan_id;
                
                SqlCommand cmd = new SqlCommand(sql, Conexion.Instance.get());
                cmd.Parameters.Add(parametro1);
                cmd.Parameters.Add(parametro2);
                cmd.Parameters.Add(parametro3);
                cmd.Parameters.Add(parametro4);
                
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //Lleno la tabla
                da.Fill(dt);

                return dt;

            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                return new DataTable();
            }
        }

        /// <summary>
        /// Top 5 profesionales que menos horas trabajaron filtrando por plan y Especialidad
        /// </summary>
        /// <param name="año"></param>
        /// <param name="inicio"></param>
        /// <param name="fin"></param>
        /// <param name="id_plan"></param>
        /// <param name="id_esp"></param>
        /// <returns></returns>
        public static DataTable get_top5_prof_vagos(int año, int inicio, int fin, int id_plan, int id_esp)
        {
            try
            {
                string sql = "KFC.pro_top_5_prof_menos_trabajo @año, @plazo_init, @plazo_fin, @plan_id, @esp_id";

                SqlParameter parametro1 = new SqlParameter("@año", SqlDbType.Int);
                parametro1.Value = año;
                SqlParameter parametro2 = new SqlParameter("@plazo_init", SqlDbType.Int);
                parametro2.Value = inicio;
                SqlParameter parametro3 = new SqlParameter("@plazo_fin", SqlDbType.Int);
                parametro3.Value = fin;
                SqlParameter parametro4 = new SqlParameter("@plan_id", SqlDbType.Int);
                parametro4.Value = id_plan;
                SqlParameter parametro5 = new SqlParameter("@esp_id", SqlDbType.Int);
                parametro5.Value = id_esp;

                SqlCommand cmd = new SqlCommand(sql, Conexion.Instance.get());
                cmd.Parameters.Add(parametro1);
                cmd.Parameters.Add(parametro2);
                cmd.Parameters.Add(parametro3);
                cmd.Parameters.Add(parametro4);
                cmd.Parameters.Add(parametro5);

                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //Lleno la tabla
                da.Fill(dt);

                return dt;

            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                return new DataTable();
            }
        }


        /// <summary>
        /// Top 5 afiliados con mayor cantidad de bonos comprados
        /// </summary>
        /// <param name="año"></param>
        /// <param name="inicio"></param>
        /// <param name="fin"></param>
        /// <returns></returns>
        public static DataTable get_top5_afil_compra_bonos(int año, int inicio, int fin)
        {
            try
            {
                string sql = "KFC.pro_top_5_compradores_bonos @año, @plazo_init, @plazo_fin";

                SqlParameter parametro1 = new SqlParameter("@año", SqlDbType.Int);
                parametro1.Value = año;
                SqlParameter parametro2 = new SqlParameter("@plazo_init", SqlDbType.Int);
                parametro2.Value = inicio;
                SqlParameter parametro3 = new SqlParameter("@plazo_fin", SqlDbType.Int);
                parametro3.Value = fin;

                SqlCommand cmd = new SqlCommand(sql, Conexion.Instance.get());
                cmd.Parameters.Add(parametro1);
                cmd.Parameters.Add(parametro2);
                cmd.Parameters.Add(parametro3);

                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //Lleno la tabla
                da.Fill(dt);

                return dt;

            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                return new DataTable();
            }
        }


        /// <summary>
        /// Top 5 especialidades de medicos con más bonos de consultas consumidos.
        /// </summary>
        /// <param name="año"></param>
        /// <param name="inicio"></param>
        /// <param name="fin"></param>
        /// <returns></returns>
        public static DataTable get_top5_esp_con_mas_bonos(int año, int inicio, int fin)
        {
            try
            {
                string sql = "KFC.pro_top_5_espec_Atenciones @año, @plazo_init, @plazo_fin";

                SqlParameter parametro1 = new SqlParameter("@año", SqlDbType.Int);
                parametro1.Value = año;
                SqlParameter parametro2 = new SqlParameter("@plazo_init", SqlDbType.Int);
                parametro2.Value = inicio;
                SqlParameter parametro3 = new SqlParameter("@plazo_fin", SqlDbType.Int);
                parametro3.Value = fin;


                SqlCommand cmd = new SqlCommand(sql, Conexion.Instance.get());
                cmd.Parameters.Add(parametro1);
                cmd.Parameters.Add(parametro2);
                cmd.Parameters.Add(parametro3);

                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //Lleno la tabla
                da.Fill(dt);

                return dt;

            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                return new DataTable();
            }
        }
    }
}
