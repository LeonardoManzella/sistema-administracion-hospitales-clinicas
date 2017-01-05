using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaFrba.Base_de_Datos
{
    class BD_Afiliados
    {

        public static DataTable cargarAfiliados(string nombre, string apellido) { return new DataTable(); }
        /// <summary>
        /// Obtiene el id de un afiliado a partir de su nombre y apellido y id de usuario.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public static int obtenerID_afiliado(string nombre, string apellido, int user_id)
        {
            try
            {
                string funcion = "SELECT KFC.fun_retornar_id_afildo_por_id(@nombre, @apellido,@us_id)";
                SqlParameter parametro1 = new SqlParameter("@nombre", SqlDbType.Text);
                parametro1.Value = nombre.ToUpper();
                SqlParameter parametro2 = new SqlParameter("@apellido", SqlDbType.Text);
                parametro2.Value = apellido.ToUpper();
                SqlParameter parametro3 = new SqlParameter("@us_id", SqlDbType.Int);
                parametro3.Value = user_id;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);

                int id = InteraccionDB.ObtenerIntReader(reader, 0);

                return id;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }

        /// <summary>
        /// Obtiene los afiliados a partir de filtros Like de nombre y apellido y documento.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="documento"></param>
        /// <returns></returns>
        public static DataTable obtener_afiliados_filtros(string nombre, string apellido, string documento, bool flag_buscar_titulares)
        {
            try
            {
                if (String.IsNullOrEmpty(documento)) documento = "0";


                string funcion = "SELECT * FROM KFC.obtener_afiliados_filtros(@nombre, @apellido, @documento, @flag_buscar_titulares)";
                SqlParameter parametro1 = new SqlParameter("@nombre", SqlDbType.Text);
                parametro1.Value = nombre.ToUpper();
                SqlParameter parametro2 = new SqlParameter("@apellido", SqlDbType.Text);
                parametro2.Value = apellido.ToUpper();
                SqlParameter parametro3 = new SqlParameter("@documento", SqlDbType.Decimal);
                parametro3.Value = Convert.ToDecimal(documento);
                SqlParameter parametro4 = new SqlParameter("@flag_buscar_titulares", SqlDbType.Bit);
                parametro4.Value = flag_buscar_titulares;

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


        /// <summary>
        /// Parametriza los datos y administra la conexion con la BD para el alta del afiliado
        /// </summary>
        /// <param name="afiliado"></param>
        /// <returns></returns>
        public static int alta_afiliado(Afiliado afiliado)
        {
            try
            {

                //TODO pasar todo esto a metodo con Variable Args para parameters y fijo primer parametro string sql
                SqlConnection conexion = Conexion.Instance.get();


                SqlCommand comando_sql = new SqlCommand("kfc.alta_afiliado  @nombre, @apellido, @tipo_doc, @nro_doc, @direccion, @telefono, @mail, @sexo, @fecha_nac, @estado, @plan, @afil_id_titular, @afil_id OUTPUT", conexion);

                var parametro1 = new SqlParameter("@nombre", SqlDbType.Text);
                var parametro2 = new SqlParameter("@apellido", SqlDbType.Text);
                var parametro3 = new SqlParameter("@tipo_doc", SqlDbType.Text);
                var parametro3_5 = new SqlParameter("@nro_doc", SqlDbType.Int);
                var parametro4 = new SqlParameter("@direccion", SqlDbType.Text);
                //var parametro5 = new SqlParameter("@telefono", SqlDbType.Int);
                var parametro6 = new SqlParameter("@mail", SqlDbType.Text);
                var parametro7 = new SqlParameter("@sexo", SqlDbType.Char);
                var parametro8 = new SqlParameter("@fecha_nac", SqlDbType.DateTime);
                var parametro9 = new SqlParameter("@estado", SqlDbType.Int);
                var parametro10 = new SqlParameter("@plan", SqlDbType.Int);
                var parametro11 = new SqlParameter("@afil_id_titular", SqlDbType.Int);
                var parametro0 = new SqlParameter("@afil_id", SqlDbType.Int);

                parametro1.Value = afiliado.nombre.ToUpper();
                parametro2.Value = afiliado.apellido.ToUpper();
                parametro3.Value = afiliado.tipo_doc.ToUpper();
                parametro3_5.Value = afiliado.nro_doc;
                parametro4.Value = afiliado.direccion.ToUpper();
                //parametro5.Value = afiliado.telefono ;
                parametro6.Value = afiliado.e_mail.ToUpper();
                parametro7.Value = afiliado.sexo;
                parametro8.Value = afiliado.fecha_nac;
                parametro9.Value = afiliado.estado_civil;
                parametro10.Value = afiliado.plan_id;
                parametro11.Value = afiliado.id_principal;
                parametro0.Direction = ParameterDirection.Output;//ReturnValue;

                comando_sql.Parameters.Add(parametro1);
                comando_sql.Parameters.Add(parametro2);
                comando_sql.Parameters.Add(parametro3);
                comando_sql.Parameters.Add(parametro3_5);
                comando_sql.Parameters.Add(parametro4);
                //comando_sql.Parameters.Add(parametro5);
                if (afiliado.telefono == null)
                {
                    comando_sql.Parameters.AddWithValue("@telefono", DBNull.Value);
                }
                else {
                    var parametro5 = new SqlParameter("@telefono", SqlDbType.Int);
                    parametro5.Value = afiliado.telefono;
                    comando_sql.Parameters.Add(parametro5);
                }
                comando_sql.Parameters.Add(parametro6);
                comando_sql.Parameters.Add(parametro7);
                comando_sql.Parameters.Add(parametro8);
                comando_sql.Parameters.Add(parametro9);
                comando_sql.Parameters.Add(parametro10);
                comando_sql.Parameters.Add(parametro11);
                comando_sql.Parameters.Add(parametro0);

                comando_sql.ExecuteReader();

                var id = (int)comando_sql.Parameters["@afil_id"].Value;
                if (id <= 0) throw new Exception("No se ha podido crear el nuevo afiliado en la base");

                return id;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }

        /// <summary>
        /// Parametriza los datos y administra la conexion con la BD para el alta del afiliado adjunto
        /// </summary>
        /// <param name="afiliado"></param>
        /// <returns></returns>
        public static int alta_afiliado_adjunto(Afiliado afiliado)
        {
            try
            {

                //TODO pasar todo esto a metodo con Variable Args para parameters y fijo primer parametro string sql
                SqlConnection conexion = Conexion.Instance.get();


                SqlCommand comando_sql = new SqlCommand("kfc.alta_afiliado_adjunto  @nombre, @apellido, @tipo_doc, @nro_doc, @direccion, @telefono, @mail, @sexo, @fecha_nac, @estado, @plan, @afil_id_titular, @conyuge, @afil_id OUTPUT", conexion);

                var parametro1 = new SqlParameter("@nombre", SqlDbType.Text);
                var parametro2 = new SqlParameter("@apellido", SqlDbType.Text);
                var parametro3 = new SqlParameter("@tipo_doc", SqlDbType.Text);
                var parametro3_5 = new SqlParameter("@nro_doc", SqlDbType.Int);
                var parametro4 = new SqlParameter("@direccion", SqlDbType.Text);
                //var parametro5 = new SqlParameter("@telefono", SqlDbType.Int);
                var parametro6 = new SqlParameter("@mail", SqlDbType.Text);
                var parametro7 = new SqlParameter("@sexo", SqlDbType.Char);
                var parametro8 = new SqlParameter("@fecha_nac", SqlDbType.DateTime);
                var parametro9 = new SqlParameter("@estado", SqlDbType.Int);
                var parametro10 = new SqlParameter("@plan", SqlDbType.Int);
                var parametro11 = new SqlParameter("@afil_id_titular", SqlDbType.Int);
                var parametro12 = new SqlParameter("@conyuge", SqlDbType.Int);
                var parametro0 = new SqlParameter("@afil_id", SqlDbType.Int);

                parametro1.Value = afiliado.nombre.ToUpper();
                parametro2.Value = afiliado.apellido.ToUpper();
                parametro3.Value = afiliado.tipo_doc.ToUpper();
                parametro3_5.Value = afiliado.nro_doc;
                parametro4.Value = afiliado.direccion.ToUpper();
                //parametro5.Value = afiliado.telefono;
                parametro6.Value = afiliado.e_mail.ToUpper();
                parametro7.Value = afiliado.sexo;
                parametro8.Value = afiliado.fecha_nac;
                parametro9.Value = afiliado.estado_civil;
                parametro10.Value = afiliado.plan_id;
                parametro11.Value = afiliado.id_principal;
                parametro0.Direction = ParameterDirection.Output;
                parametro12.Value = afiliado.id;

                comando_sql.Parameters.Add(parametro1);
                comando_sql.Parameters.Add(parametro2);
                comando_sql.Parameters.Add(parametro3);
                comando_sql.Parameters.Add(parametro3_5);
                comando_sql.Parameters.Add(parametro4);
                if (afiliado.telefono == null)
                {
                    comando_sql.Parameters.AddWithValue("@telefono", DBNull.Value);
                }
                else {
                    var parametro5 = new SqlParameter("@telefono", SqlDbType.Int);
                    parametro5.Value = afiliado.telefono;
                    comando_sql.Parameters.Add(parametro5);
                }
                comando_sql.Parameters.Add(parametro6);
                comando_sql.Parameters.Add(parametro7);
                comando_sql.Parameters.Add(parametro8);
                comando_sql.Parameters.Add(parametro9);
                comando_sql.Parameters.Add(parametro10);
                comando_sql.Parameters.Add(parametro11);
                comando_sql.Parameters.Add(parametro12);
                comando_sql.Parameters.Add(parametro0);

                comando_sql.ExecuteReader();

                var id = (int)comando_sql.Parameters["@afil_id"].Value;
                if (id <= 0) throw new Exception("No se ha podido crear el nuevo afiliado en la base");

                return id;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("duplic"))
                {
                    var texto = string.Format("El afiliado {0}, ya tiene un cónyuge declarado.", afiliado.id_principal);

                    e = new Exception(texto);
                }

                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }


        /// Parametriza los datos y administra la conexion con la BD para la modificación del afiliado
        /// </summary>
        /// <param name="afiliado"></param>
        /// <returns></returns>
        public static void modifica_afiliado(Afiliado afiliado)
        {
            try
            {
                //TODO pasar todo esto a metodo con Variable Args para parameters y fijo primer parametro string sql
                SqlConnection conexion = Conexion.Instance.get();

                SqlCommand comando_sql = new SqlCommand("kfc.modifica_afiliado @afiliado, @tipo_doc, @direccion, @telefono, @mail, @sexo, @estado, @plan, @fecha", conexion);
                var parametro0 = new SqlParameter("@afiliado", SqlDbType.Int);
                var parametro3 = new SqlParameter("@tipo_doc", SqlDbType.Text);
                var parametro4 = new SqlParameter("@direccion", SqlDbType.Text);
                //var parametro5 = new SqlParameter("@telefono", SqlDbType.Int);
                var parametro6 = new SqlParameter("@mail", SqlDbType.Text);
                var parametro7 = new SqlParameter("@sexo", SqlDbType.Char);
                var parametro9 = new SqlParameter("@estado", SqlDbType.Int);
                var parametro10 = new SqlParameter("@plan", SqlDbType.Int);
                var parametro12 = new SqlParameter("@fecha", SqlDbType.VarChar);

                parametro0.Value = afiliado.id;
                parametro3.Value = afiliado.tipo_doc.ToUpper();
                parametro4.Value = afiliado.direccion.ToUpper();
                //parametro5.Value = afiliado.telefono;
                parametro6.Value = afiliado.e_mail.ToUpper();
                parametro7.Value = afiliado.sexo;
                parametro9.Value = afiliado.estado_civil;
                parametro10.Value = afiliado.plan_id;
                parametro12.Value = Configuracion_Global.fecha_actual;

                comando_sql.Parameters.Add(parametro0);
                comando_sql.Parameters.Add(parametro3);
                comando_sql.Parameters.Add(parametro4);
                //comando_sql.Parameters.Add(parametro5);
                if (afiliado.telefono == null)
                {
                    comando_sql.Parameters.AddWithValue("@telefono", DBNull.Value);
                }
                else {
                    var parametro5 = new SqlParameter("@telefono", SqlDbType.Int);
                    parametro5.Value = afiliado.telefono;
                    comando_sql.Parameters.Add(parametro5);
                }
                comando_sql.Parameters.Add(parametro6);
                comando_sql.Parameters.Add(parametro7);
                comando_sql.Parameters.Add(parametro9);
                comando_sql.Parameters.Add(parametro10);
                comando_sql.Parameters.Add(parametro12);

                comando_sql.ExecuteReader();

            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }
        public static Afiliado get_afiliado(int afiliado_id)
        {
            try
            {
                //Declaro un Objeto del tipo del retorno
                var afiliado = new Afiliado();

                //creo la tabla que va a traer los registros
                DataTable dt = new DataTable();

                SqlConnection conexion = Conexion.Instance.get();
                SqlCommand cmd = new SqlCommand("kfc.get_afiliado @id_afiliado", conexion);

                var parametro1 = new SqlParameter("@id_afiliado", SqlDbType.Int);
                parametro1.Value = afiliado_id;
                cmd.Parameters.Add(parametro1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //Lleno la tabla
                da.Fill(dt);

                //La recorro para armar la lista
                foreach (DataRow pRow in dt.Rows)
                {
                    afiliado = new Afiliado();

                    afiliado.id = Int32.Parse(pRow["afil_id"].ToString());
                    afiliado.nombre = pRow["nombre"].ToString();
                    afiliado.apellido = pRow["apellido"].ToString();
                    afiliado.tipo_doc = pRow["tipo_doc"].ToString();
                    afiliado.nro_doc = Int32.Parse(pRow["numero_doc"].ToString());
                    afiliado.direccion = pRow["direccion"].ToString();
                    afiliado.telefono = string.IsNullOrEmpty(pRow["telefono"].ToString().Trim())? new Int32?() : Int32.Parse(pRow["telefono"].ToString());
                    afiliado.e_mail = pRow["mail"].ToString();
                    afiliado.sexo = pRow["sexo"].ToString()[0];
                    afiliado.fecha_nac = DateTime.Parse(pRow["fecha_nacimiento"].ToString());
                    afiliado.estado_civil = Int32.Parse(pRow["estado_id"].ToString());
                    afiliado.plan_id = Int32.Parse(pRow["plan_id"].ToString());
                    afiliado.usuario = Int32.Parse(pRow["us_id"].ToString());
                }

                return afiliado;

            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                throw e;
            }

        }

        /// <summary>
        /// Baja de afiliado si la baja ha sido exitosa,devuelve ok
        /// </summary>
        /// <param name="afil_id"></param>
        /// <returns></returns>
        public static bool baja_afiliado(int afil_id)
        {
            try
            {

                SqlConnection conexion = Conexion.Instance.get();

                SqlCommand comando_sql = new SqlCommand("kfc.baja_afiliado @afiliado, @fecha", conexion);
                var parametro0 = new SqlParameter("@afiliado", SqlDbType.Int);
                var parametro1 = new SqlParameter("@fecha", SqlDbType.VarChar);

                parametro0.Value = afil_id;
                parametro1.Value = Configuracion_Global.fecha_actual;

                comando_sql.Parameters.Add(parametro0);
                comando_sql.Parameters.Add(parametro1);

                comando_sql.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                return false;
            }
        }


    }
}
