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

namespace ClinicaFrba.Pedir_Turno
{
    public partial class PedirTurno : Form
    {
        public Usuario usuario { get; set; }
        private DateTime fecha;
        private string nombre_boton_datagrid = "boton_pedir_turno";

        public PedirTurno()
        {
            InitializeComponent();
        }

        private void PedirTurno_Load(object sender, EventArgs e)
        {
            try
            {
                this.comboEspecialidades.DropDownStyle = ComboBoxStyle.DropDownList;
                ComboData.llenarCombo(comboEspecialidades, InteraccionDB.obtener_todas_especialidades());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pedir Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void boton_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_horarios_Click(object sender, EventArgs e)
        {
            try
            {
                Comunes.limpiarDataGrid(dataGridView_resultados_filtros);

                actualizar_datagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pedir Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizar_datagrid()
        {
            try
            {
                var descripcion_especialidad = comboEspecialidades.Text.Trim();
                var profesional_nombre = textBox_nombre.Text.Trim();
                var profesional_apellido = textBox_apellido.Text.Trim();
                string fecha_texto = textBox_fecha.Text;

                label_cargando.Visible = true;
                this.Refresh();
                DataTable datos = BD_Turnos.obtener_turnos_disponibles(profesional_nombre, profesional_apellido, descripcion_especialidad, fecha_texto);
                if (datos.Rows.Count <= 0) throw new Exception("No hay Turnos Disponibles para los Filtros Seleccionados");

                Comunes.llenar_dataGrid(dataGridView_resultados_filtros, datos);

                Comunes.agregar_boton_dataGrid(dataGridView_resultados_filtros, "Pedir Turno", nombre_boton_datagrid);
                label_cargando.Visible = false;
                this.Refresh();
            }
            catch (Exception ex)
            {
                label_cargando.Visible = false;
                this.Refresh();
                MessageBox.Show(ex.Message, "Pedir Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    fecha = DateTime.Parse  (
                                            Comunes.obtenerStringDataGrid(dataGridView_resultados_filtros, e.RowIndex, 0)
                                            );
                    string horario = Comunes.obtenerStringDataGrid(dataGridView_resultados_filtros, e.RowIndex, 1);
                    string prof_nombre = Comunes.obtenerStringDataGrid(dataGridView_resultados_filtros, e.RowIndex, 2);
                    string prof_apellido = Comunes.obtenerStringDataGrid(dataGridView_resultados_filtros, e.RowIndex, 3);
                    string especialidad = Comunes.obtenerStringDataGrid(dataGridView_resultados_filtros, e.RowIndex, 4);
                    int afil_id = BD_Afiliados.obtenerID_afiliado(usuario.nombre, usuario.apellido, usuario.id);

                    BD_Turnos.asignar_turno(prof_nombre, prof_apellido, fecha, horario, especialidad, afil_id);

                    MessageBox.Show("Turno Asignado.   Seleccionado Profesional: " + prof_nombre + " " + prof_apellido + "   Especialidad: " + especialidad, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button_limpiar_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener Datos Afiliado. " + ex.Message, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button_limpiar_Click(object sender, EventArgs e)
        {
            //Truco para Limpiar ComboBox
            comboEspecialidades.Items.Add("");
            comboEspecialidades.Text = "";
            textBox_nombre.Text = "";
            textBox_apellido.Text = "";
            textBox_fecha.Text = "";
            Comunes.limpiarDataGrid(dataGridView_resultados_filtros);
        }

        private void button_fecha_Click(object sender, EventArgs e)
        {
            var seleccionarFecha = new SelecionarFecha();
            seleccionarFecha.ShowDialog();
            var fecha = seleccionarFecha.fecha;
            this.textBox_fecha.Text = fecha.ToString("yyyy.MM.dd");
        }

        private void textBox_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras(e);
        }
    }
}
