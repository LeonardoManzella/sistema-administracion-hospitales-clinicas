using ClinicaFrba.Clases;
using ClinicaFrba.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AtencionesMedicas
{
    public partial class RegistrarLlegada : Form
    {
        private ComboData cero = new ComboData(0, "");
        private ComboData vacio = new ComboData(0, "");


        public Usuario usuario_profesional;
        private int profesional_id;     //Soy yo, porque el unico usuario que puede ver la pantalla es un profesional
        private List<string> profesional_especialidades = new List<string>();
        private string nombre_boton_datagrid = "boton_seleccionar";
        private int id_turno;
        private int id_afiliado;
        private TimeSpan hora_seleccionada;
        private int plan_id;

        public RegistrarLlegada()
        {
            InitializeComponent();
        }

        private void RegistrarAtencion_Load(object sender, EventArgs e)
        {
            try
            {
                profesional_id = Base_de_Datos.BD_Profesional.obtenerID_profesional(usuario_profesional.id);
                profesional_especialidades = Base_de_Datos.BD_Profesional.getEspecialidadesProfesional(profesional_id);
                ComboData.llenarCombo(comboEspecialidades, profesional_especialidades);
                this.combo_Bono.DropDownStyle = ComboBoxStyle.DropDown;
                this.comboEspecialidades.DropDownStyle = ComboBoxStyle.DropDown;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Cargar Ventana: " + ex.Message, "RegistrarLlegada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar()
        {
            this.label_Afiliado.Text = "";
            this.label_profesional.Text = "";
            this.comboEspecialidades.Items.Clear();
            this.comboEspecialidades.Text = "";

            this.combo_Bono.Items.Clear();
            this.combo_Bono.Text = "";
            this.combo_Bono.Enabled = false;
            this.button_Registrar.Enabled = false;

            this.textBox_afiliado_apellido.Text = "";
            this.textBox_afiliado_nombre.Text = "";
            this.textBox_profesional_nombre.Text = "";
            this.textBox_profesional_apellido.Text = "";

            Comunes.limpiarDataGrid(dataGridView_resultados_filtros);

            //actualizar_datagrid("", "", "", "", "");
        }
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_numeros(e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Comunes.limpiarDataGrid(dataGridView_resultados_filtros);

                string afiliado_nombre = this.textBox_afiliado_nombre.Text.Trim();
                string afiliado_apellido = this.textBox_afiliado_apellido.Text.Trim();
                string profesional_nombre = this.textBox_profesional_nombre.Text.Trim();
                string profesional_apellido = this.textBox_profesional_apellido.Text.Trim();
                string especialidad_descripcion = this.comboEspecialidades.Text.Trim();

                actualizar_datagrid(afiliado_nombre, afiliado_apellido, profesional_nombre, profesional_apellido, especialidad_descripcion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Buscar: " + ex.Message, "RegistrarLlegada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizar_datagrid(string afiliado_nombre, string afiliado_apellido, string profesional_nombre, string profesional_apellido, string especialidad_descripcion)
        {
            //DATAGRID
            DataTable datos = Base_de_Datos.BD_Turnos.obtener_turnos_filtros(afiliado_nombre, afiliado_apellido, profesional_nombre, profesional_apellido, especialidad_descripcion);

            if (datos.Rows.Count <= 0) throw new Exception("No hay Turnos para Estos Filtros");

            //Lleno el DataGrid
            Comunes.llenar_dataGrid(dataGridView_resultados_filtros, datos);

            //Agrego Boton
            Comunes.agregar_boton_dataGrid(dataGridView_resultados_filtros, "Seleccionar", nombre_boton_datagrid);
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("No hay Turnos para Estos Filtros"))
                {
                    MessageBox.Show("Error al Limpiar Datos: " + ex.Message, "RegistrarLlegada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                var texto = this.combo_Bono.Text.Trim();
                if (String.IsNullOrEmpty(texto)) throw new Exception("Debe seleccionar un Bono");

                int bono_id_numero = Convert.ToInt32(texto);
                if (bono_id_numero <= 0) throw new Exception("El numero de bono no puede ser Cero o Negativo");

                Base_de_Datos.BD_LLegada.registrar_llegada(id_afiliado, id_turno, bono_id_numero, hora_seleccionada);
                MessageBox.Show("Registrada Llegada", "RegistrarLlegada", MessageBoxButtons.OK, MessageBoxIcon.None);
                btnLimpiar_Click(null, null);
            }
            catch (Exception ex)
            {
                btnLimpiar_Click(null, null);
                MessageBox.Show("Error al Registrar Llegada: " + ex.Message, "RegistrarLlegada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    string afiliado_nombre = Comunes.obtenerStringDataGrid(dataGridView_resultados_filtros, e.RowIndex, 0);
                    string afiliado_apellido = Comunes.obtenerStringDataGrid(dataGridView_resultados_filtros, e.RowIndex, 1);
                    hora_seleccionada = TimeSpan.Parse(
                                                    Comunes.obtenerStringDataGrid(dataGridView_resultados_filtros, e.RowIndex, 3)
                                                    );
                    string profesional_nombre = Comunes.obtenerStringDataGrid(dataGridView_resultados_filtros, e.RowIndex, 4);
                    string profesional_apellido = Comunes.obtenerStringDataGrid(dataGridView_resultados_filtros, e.RowIndex, 5);

                    id_turno = Comunes.obtenerIntDataGrid(dataGridView_resultados_filtros, e.RowIndex, 6);
                    id_afiliado = Comunes.obtenerIntDataGrid(dataGridView_resultados_filtros, e.RowIndex, 7);
                    plan_id = Comunes.obtenerIntDataGrid(dataGridView_resultados_filtros, e.RowIndex, 8);


                    this.label_profesional.Text = "PROF.: " + profesional_nombre + " " + profesional_apellido;
                    this.label_Afiliado.Text = "AFILIADO: " + afiliado_nombre + " " + afiliado_apellido;
                    var bonos = Base_de_Datos.BD_Bonos.getBonos(id_afiliado);
                    ComboData.llenarCombo(combo_Bono, bonos);

                    this.combo_Bono.Enabled = true;
                    //MessageBox.Show("Seleccionado Afiliado: " + nombre + " " + apellido, "RegistrarLlegada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                btnLimpiar_Click(null, null);
                MessageBox.Show("Error al Seleccionar: " + ex.Message, "RegistrarLlegada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void combo_Bono_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.button_Registrar.Enabled = true;
        }

        private void textBox_profesional_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras(e);
        }
    }
}
