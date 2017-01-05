using ClinicaFrba.Clases;
using System;
using System.Data.SqlClient;

namespace ClinicaFrba.Base_de_Datos
{
    public sealed class Conexion
    {
        private static Conexion instance = null;
        private static readonly object padlock = new object();

        private SqlConnection conexion_interna;

        /// <summary>
        /// Metodo Interno para el Singleton.
        /// </summary>
        /// <returns></returns>
        public SqlConnection get()
        { return conexion_interna; }


        /// <summary>
        /// Constructor Interno
        /// </summary>
        private Conexion()
        {
            try
            {
                string usuario = Configuracion_Global.base_datos_usuario;
                string password = Configuracion_Global.base_datos_password;
                string catalogo = Configuracion_Global.base_datos_catalogo;
                string source = Configuracion_Global.base_datos_source;
                string conexion_string = "Password=" + password + ";Persist Security Info=True;User ID=" + usuario + ";Initial Catalog=" + catalogo + ";MultipleActiveResultSets=True;Data Source=" + source;

                conexion_interna = new SqlConnection(conexion_string);

                conexion_interna.Open();

                var sqlCommand = new SqlCommand("SELECT * FROM KFC.roles", conexion_interna);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                /* 
                //Para Pruebas, no Borrar
                while (reader.Read())
                {
                    string name = reader.GetString(1);
                    var i = 5;
                }
                */
            }
            catch (Exception e)
            {
                //Imprimir para DEBUG enserio
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.InnerException);
                System.Diagnostics.Debug.WriteLine(e.HelpLink);
                System.Diagnostics.Debug.Write(e.StackTrace);


                //Imprimir para Consola :/
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                Console.WriteLine(e.HelpLink);
                Console.Write(e.StackTrace);

                new Exception("Error al Conectar a la Base de Datos");
            }
        }

        /// <summary>
        /// Constructor Externo. Es un Singleton. Devuelve siempre la misma conexion.
        /// <para>Llamar SIN los parentesis ()</para>
        /// </summary>
        public static Conexion Instance
        {
            //En realidad es un Getter de la variable instance, de ahi el truco para unica conexion, lo guardamos en una variable estatica de clase
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Conexion();
                    }
                    return instance;
                }
            }
        }
    }
}
