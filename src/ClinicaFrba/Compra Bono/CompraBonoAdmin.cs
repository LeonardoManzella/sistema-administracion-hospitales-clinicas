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
    public partial class CompraBonoAdmin : Form
    {
        public enum tipos_funcionalidad
        {
            ADMIN,
            USUARIO
        };


        public tipos_funcionalidad funcionalidad;
        public Usuario usuario_o_administrador;
        private int id_afiliado_que_compra;
        private string nombre_boton_datagrid = "boton_seleccionar";

        public CompraBonoAdmin()
        {
            InitializeComponent();
        }

        private void resetear_comprar()
        {
            this.textBox_Plan.Text = "";
            this.textBox_precio.Text = "";
            this.textBox_Cantidad.Text = "";
        }

        private void deshabilitar_busqueda()
        {
            this.textBox_Nombre.Enabled = false;
            this.textBox_Apellido.Enabled = false;
            this.textBox_Nombre.Visible = false;
            this.textBox_Apellido.Visible = false;
            this.label_Usuario.Visible = false;
            this.label_apellido.Visible = false;
            this.groupBox_filtros.Enabled = false;
            this.groupBox_filtros.Visible = false;
            this.dataGridView_resultados_filtros.Visible = false;
            this.button_Buscar.Visible = false;
            this.label_afiliados.Visible = false;
            this.button_limpiar.Visible = false;
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
            label_Id_Usuario.Text = "";
            try
            {
                if (this.funcionalidad == tipos_funcionalidad.USUARIO)
                {
                    deshabilitar_busqueda();
                    this.id_afiliado_que_compra = BD_Afiliados.obtenerID_afiliado(usuario_o_administrador.nombre, usuario_o_administrador.apellido, usuario_o_administrador.id); ;
                    mostrar_plan();
                }
                else
                {
                    this.id_afiliado_que_compra = -1;
                    deshabilitar_comprar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Cargar Ventana: " + ex.Message, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrar_plan()
        {
            this.textBox_Plan.Text = BD_Bonos.obtener_nombre_plan(this.id_afiliado_que_compra);
            this.textBox_precio.Text = BD_Bonos.obtener_precio_plan(this.id_afiliado_que_compra).ToString();
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = this.textBox_Nombre.Text.Trim();
                string apellido = this.textBox_Apellido.Text.Trim();
                string documento = this.textBox_Documento.Text.Trim();


                //DATAGRID
                DataTable datos = BD_Afiliados.obtener_afiliados_filtros(nombre, apellido, documento, false);

                if (datos.Rows.Count <= 0) throw new Exception("No hay Afiliados para Estos Filtros");

                //Lleno el DataGrid
                Comunes.llenar_dataGrid(dataGridView_resultados_filtros, datos);

                //Agrego Boton
                Comunes.agregar_boton_dataGrid(dataGridView_resultados_filtros, "Seleccionar", nombre_boton_datagrid);

            }
            catch (Exception ex)
            {
                resetear_comprar();
                Comunes.limpiarDataGrid(dataGridView_resultados_filtros);
                MessageBox.Show("Error al Buscar Afiliado con Filtros.  " + ex.Message, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                button_limpiar_Click(null, null);
            }
            catch (Exception ex)
            {
                button_limpiar_Click(null,null);
                MessageBox.Show("Error al Comprar: " + ex.Message, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_Nombre.Text = "";
                textBox_Apellido.Text = "";
                textBox_Documento.Text = "";
                resetear_comprar();
                deshabilitar_comprar();

                Comunes.limpiarDataGrid(dataGridView_resultados_filtros);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Limpiar: " + ex.Message, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Handler para Cuando se Selecciona un Boton del DataGrid
        //IMPORTANTE: Se genera haciendo doble click en el DataGrid
        private void dataGridView_resultados_filtros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dataGridView_resultados_filtros.Columns[e.ColumnIndex].Name == nombre_boton_datagrid)
                {
                    //Hago cosas con los valores de la fila seleccionada
                    this.id_afiliado_que_compra = Comunes.obtenerIntDataGrid(dataGridView_resultados_filtros, e.RowIndex, 0);
                    string nombre = Comunes.obtenerStringDataGrid(dataGridView_resultados_filtros, e.RowIndex, 1);
                    string apellido = Comunes.obtenerStringDataGrid(dataGridView_resultados_filtros, e.RowIndex, 2);


                    mostrar_plan();
                    habilitar_comprar();
                    //MessageBox.Show("Seleccionado Afiliado: " + nombre + " " + apellido, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Seleccionar: " + ex.Message, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras(e);
        }

        private void textBox_Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_numeros(e);
        }

        private void textBox_Documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_numeros(e);
        }
    }
}
