using ClinicaFrba.Base_de_Datos;
using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class CrearRol : Form
    {
        public CrearRol()
        {
            InitializeComponent();
        }

        private void CrearRol_Load(object sender, EventArgs e)
        {
            try
            {
                llenar_funcionalidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Cargar Ventana: " + ex.Message, "Crear Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llenar_funcionalidades()
        {
            checkBox_funcionalidades.Items.Clear();
            List<string> funcionalidades = InteraccionDB.obtener_todas_funcionalidades();

            foreach (string funcionalidad in funcionalidades)
            {
                checkBox_funcionalidades.Items.Add(funcionalidad, false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre_rol = textBox_nombre_rol.Text.Trim();
                if (String.IsNullOrEmpty(nombre_rol)) throw new Exception("Nombre de Rol Vacio");

                //Obtengo items elegidos y convierto a strings
                List<string> funcionalidades_elegidas = new List<string>();
                var objects = checkBox_funcionalidades.CheckedItems;
                if (objects.Count <= 0) throw new Exception("No hay Funcionalidades Elegidas");

                foreach (var item in objects)
                {
                    string fun = Convert.ToString(item);
                    funcionalidades_elegidas.Add(fun);
                    //MessageBox.Show(fun, "Crear Rol", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                BD_Roles.crear_rol(nombre_rol, funcionalidades_elegidas);

                MessageBox.Show("Rol Creado con Exito", "Crear Rol", MessageBoxButtons.OK, MessageBoxIcon.None);

                button_limpiar_Click(null,null);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                if (mensaje.ToUpper().Contains("DUPLIC") && mensaje.ToUpper().Contains("KFC.ROLES"))
                {
                    mensaje = "Rol Duplicado. Ya existe un Rol con ese nombre";
                }

                MessageBox.Show("Error al Crear Rol: "+ mensaje, "Crear Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_nombre_rol.Text = "";
            llenar_funcionalidades();
        }

        private void textBox_nombre_rol_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras(e);
        }
    }
}
