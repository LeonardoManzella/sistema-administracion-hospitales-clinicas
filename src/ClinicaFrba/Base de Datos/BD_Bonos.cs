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
    class BD_Bonos
    {
        
        public static int obtener_precio_plan(int id_usuario)
        {
            try
            {
                string funcion = "SELECT KFC.fun_devolver_precio_bono(@afiliado_id)";
                SqlParameter parametro = new SqlParameter("@afiliado_id", SqlDbType.Int);
                parametro.Value = id_usuario;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);

                int precio = InteraccionDB.ObtenerIntReader(reader, 0);

                return precio;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }

        public static string obtener_nombre_plan(int id_usuario)
        {
            try
            {
                string funcion = "SELECT * FROM KFC.fun_obtener_planes_afiliado(@afiliado_id)";
                SqlParameter parametro = new SqlParameter("@afiliado_id", SqlDbType.Int);
                parametro.Value = id_usuario;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);

                List<string> Multiples_Planes = InteraccionDB.ObtenerStringsReader(reader, 4);

                //Obtengo solo el primer plan, si tuviera varios (no deberia pasar que tenga varios)
                string plan_Actual = Convert.ToString(Multiples_Planes.ToArray()[0]);
                return plan_Actual;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }

        public static void comprar_bono(int id_afiliado, int cantidad_bonos)
        {
            try
            {
                //Ejecuta tantas veces como Bonos Pedidos por el usuario
                for (int i = 0; i < cantidad_bonos; i++)
                {
                    string procedure = "KFC.pro_comprar_bono";
                    SqlParameter parametro1 = new SqlParameter("@afiliado_id", SqlDbType.Int);
                    parametro1.Value = id_afiliado;
                    SqlParameter parametro2 = new SqlParameter("@fecha_formato_string", SqlDbType.Text);
                    parametro2.Value = Configuracion_Global.fecha_actual;

                    var parametros = new List<SqlParameter>();
                    parametros.Add(parametro1);
                    parametros.Add(parametro2);

                    var reader = InteraccionDB.ejecutar_storedProcedure(procedure, parametros);

                    //Veo si trajo datos o no
                    if (reader.RecordsAffected <= 0) throw new Exception("No se pudo Comprar el Bono.");

                    //MessageBox.Show("Comprado Bono", "Comprar Bonos", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                return;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }

        public static List<string> getBonos(int afiliado_id)
        {
            try
            {
                string funcion = "SELECT * FROM  KFC.fun_obtener_bonos_afiliado(@afiliado_id)";
                SqlParameter parametro = new SqlParameter("@afiliado_id", SqlDbType.Int);
                parametro.Value = afiliado_id;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);

                List<string> bonos = InteraccionDB.ObtenerStringsReader(reader, 0);

                return bonos;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                if (e.Message.Contains("Resultado Vacio")) throw new Exception("No hay Bonos Disponibles para el Afiliado");

                throw e;
            }
        }

    }
}
