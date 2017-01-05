using ClinicaFrba.Base_de_Datos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace ClinicaFrba.Clases
{
    /// <summary>
    /// Guarda Variables Globales del Archivo de Configuracion
    /// </summary>
    public class Configuracion_Global
    {
        public static string ruta_archivo_config = Path.GetFullPath(@"..\..\..\configuracion.xml");

        public static string base_datos_catalogo { get; set; }
        public static string base_datos_usuario { get; set; }
        public static string base_datos_password { get; set; }
        public static string base_datos_source { get; set; }
        public static string fecha_actual { get; set; }

        /// <summary>
        /// Cargar Datos desde el Archivo de Configuracion
        /// </summary>
        public static void cargar_archivo_configuracion()
        {
            try
            {
                if (!File.Exists(ruta_archivo_config)) throw new Exception("No existe Archivo Config en ruta: " + ruta_archivo_config + ". Por favor revise que este el archivo de configuracion");

                XmlTextReader lector = new XmlTextReader(ruta_archivo_config);

                //Leo del Archivo
                while (lector.Read())
                {
                    //Diferencio por Tipo de Etiqueta
                    switch (lector.NodeType)
                    {
                        //Etiqueta de Inicio
                        case XmlNodeType.Element:
                            string lector_nombre = lector.Name;
                            lector.Read();      //Avanzo hasta el Valor

                            if (lector_nombre.Equals("archivo_config"))
                            {
                                //Nada por ser el inicio
                                break;
                            }
                            else if (lector_nombre.Equals("base_datos_catalogo"))
                            {
                                base_datos_catalogo = lector.Value;
                            }
                            else if (lector_nombre.Equals("base_datos_usuario"))
                            {
                                base_datos_usuario = lector.Value;
                                
                            }
                            else if (lector_nombre.Equals("base_datos_password"))
                            {
                                base_datos_password = lector.Value;
                            }
                            else if (lector_nombre.Equals("base_datos_source"))
                            {
                                base_datos_source = lector.Value;
                            }
                            else if (lector_nombre.Equals("fecha_actual"))
                            {
                                fecha_actual = lector.Value;
                            }
                            else
                            {
                                MessageBox.Show("Hay Basura en Archivo Config!. Por favor no agreguen Tags XML innecesariamente.  Propiedad:    " + lector_nombre + "    con Valor:    " + lector.Value, "Configuracion", MessageBoxButtons.OK, MessageBoxIcon.None);
                                break;
                            }
                            //MessageBox.Show("Cargada Propiedad:    " + lector_nombre + "    con Valor:    " + lector.Value, "Configuracion", MessageBoxButtons.OK, MessageBoxIcon.None);
                            break;
                        //No me importan las demas Etiquetas
                    }
                }

            }
            catch (Exception ex)
            {
                InteraccionDB.ImprimirExcepcion(ex);
                MessageBox.Show("Error con Archivo Configuracion: " + ex.Message, "Configuracion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
