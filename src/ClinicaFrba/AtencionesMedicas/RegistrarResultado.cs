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

namespace ClinicaFrba.AtencionesMedicas
{
    public partial class RegistrarResultado : Form
    {

        public Usuario usuario;
        private int profID;
        private string nombre_boton_datagrid = "Seleccionar";
        private int turnoID;

        public RegistrarResultado()
        {
            InitializeComponent();
        }

        private void RegistrarResultado_Load(object sender, EventArgs e)
        {
            try
            {
                this.profID = Base_de_Datos.BD_Profesional.obtenerID_profesional(usuario.id);
                sintomasTextbox.ReadOnly = true;
                diagnosticoTextbox.ReadOnly = true;
                registrarAtencionButton.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar la ventana: " + ex.Message, "Registrar Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                Comunes.limpiarDataGrid(turnosDatagrid);

                string afiliado_nombre = this.nombreTextbox.Text.Trim();
                string afiliado_apellido = this.apellidoTextbox.Text.Trim();
                string documento = this.documentoTextbox.Text.Trim();

                actualizar_datagrid(afiliado_nombre, afiliado_apellido, documento);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Buscar: " + ex.Message, "RegistrarLlegada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizar_datagrid(string afiliado_nombre, string afiliado_apellido, string documento)
        {
            DataTable datos = Base_de_Datos.BD_Turnos.obtener_turnos_con_llegada(afiliado_nombre, afiliado_apellido, documento, this.profID);

            if (datos.Rows.Count <= 0)
                throw new Exception("No hay turnos para estos filtros");

            Comunes.llenar_dataGrid(turnosDatagrid, datos);
            Comunes.agregar_boton_dataGrid(turnosDatagrid, "Seleccionar", nombre_boton_datagrid);
        }

        private void textBox_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras(e);
        }

        private void textBox_Documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_numeros(e);
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiarDataGrid_Click(object sender, EventArgs e)
        {
            try
            {
                this.limpiar();
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("No hay Turnos para Estos Filtros"))
                {
                    MessageBox.Show("Error al limpiar los datos: " + ex.Message, "Registrar Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void limpiar()
        {
            this.registrarAtencionButton.Enabled = false;

            this.sintomasTextbox.ReadOnly = true;
            this.diagnosticoTextbox.ReadOnly = true;

            this.apellidoTextbox.Text = "";
            this.nombreTextbox.Text = "";
            this.documentoTextbox.Text = "";

            this.sintomasTextbox.Text = "";
            this.diagnosticoTextbox.Text = "";

            Comunes.limpiarDataGrid(turnosDatagrid);
        }

        private void turnosDatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.sintomasTextbox.Text = "";
            this.diagnosticoTextbox.Text = "";
            this.sintomasTextbox.ReadOnly = false;
            this.diagnosticoTextbox.ReadOnly = false;

            this.turnoID = Comunes.obtenerIntDataGrid(turnosDatagrid, e.RowIndex, 4);
        }

        private void detalleAtencionTextboxValidate(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(this.sintomasTextbox.Text.Trim()) || String.IsNullOrEmpty(this.diagnosticoTextbox.Text.Trim()))
                registrarAtencionButton.Enabled = false;
            else
                registrarAtencionButton.Enabled = true;
        }

        private void registrarAtencionButton_Click(object sender, EventArgs e)
        {
            try
            {
                string diagnostico = this.diagnosticoTextbox.Text.Trim();
                string sintomas = this.sintomasTextbox.Text.Trim();

                DateTime diaReal = DateTime.Now;
                TimeSpan horaReal = diaReal.TimeOfDay;
                DateTime horaConfigurada = DateTime.ParseExact(Configuracion_Global.fecha_actual, "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture);
                horaConfigurada = horaConfigurada.Add(horaReal);

                Base_de_Datos.BD_LLegada.registrar_atencion(this.turnoID, diagnostico, sintomas, horaConfigurada);

                MessageBox.Show("La atencion se registro exitosamente", "Registrar Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.limpiar();
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se pudo registrar la atencion: " + ex.Message, "Registrar Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
