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

namespace ClinicaFrba.Compra_Bono
{
    public partial class CompraBonoAfiliado : Form
    {

        public Usuario usuario;
        private int id_afiliado_que_compra;

        public CompraBonoAfiliado()
        {
            InitializeComponent();
        }

        private void resetear_comprar()
        {
            this.textBox_Plan.Text = "";
            this.textBox_precio.Text = "";
            this.textBox_Cantidad.Text = "";
        }


        private void deshabilitar_comprar()
        {
            this.label_Id_Usuario.Text = "";
            this.textBox_Cantidad.Enabled = false;
            this.button_Comprar.Enabled = false;
        }


        private void habilitar_comprar()
        {
            this.label_Id_Usuario.Text = "ID Afiliado: " + id_afiliado_que_compra.ToString();
            this.textBox_Cantidad.Enabled = true;
            this.button_Comprar.Enabled = true;
        }

        private void CompraBono_Load(object sender, EventArgs e)
        {
            try
            {
                
                this.id_afiliado_que_compra = BD_Afiliados.obtenerID_afiliado(usuario.nombre, usuario.apellido, usuario.id); ;
                mostrar_plan();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrar_plan()
        {
            this.textBox_Plan.Text = BD_Bonos.obtener_nombre_plan(this.id_afiliado_que_compra);
            this.textBox_precio.Text = BD_Bonos.obtener_precio_plan(this.id_afiliado_que_compra).ToString();
        }



        private void button_Comprar_Click(object sender, EventArgs e)
        {
            try
            {

                if (String.IsNullOrEmpty(textBox_Cantidad.Text)) throw new Exception("No puede estar Vacio la Cantidad a Comprar");

                int cantidad = Convert.ToInt32(textBox_Cantidad.Text);

                if (cantidad <= 0) throw new Exception("No puede Ser negativa o cero la Cantidad a Comprar");

                BD_Bonos.comprar_bono(this.id_afiliado_que_compra, cantidad);
                MessageBox.Show("Bonos Comprados", "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Comprar. " + ex.Message, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_numeros(e);
        }
    }
}
