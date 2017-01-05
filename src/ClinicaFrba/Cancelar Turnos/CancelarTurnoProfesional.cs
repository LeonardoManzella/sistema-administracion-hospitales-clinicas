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

namespace ClinicaFrba.CancelarTurno
{
    public partial class CancelarTurnoProfesional : Form
    {
        public Usuario usuario { get; set; }

        public CancelarTurnoProfesional()
        {
            InitializeComponent();
        }

        private void CancelarTurnoProfesional_Load(object sender, EventArgs e)
        {
            fechaDesdePicker.Value = DateTime.ParseExact(Configuracion_Global.fecha_actual, "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture).AddDays(1);
            fechaDesdePicker.MinDate = fechaDesdePicker.Value;
            fechaHastaPicker.Value = DateTime.ParseExact(Configuracion_Global.fecha_actual, "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture).AddDays(1);
            fechaHastaPicker.MinDate = fechaHastaPicker.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fechaDesdePicker_ValueChanged(object sender, EventArgs e)
        {
            fechaHastaPicker.MinDate = fechaDesdePicker.Value;
        }

        private void cancelarTurnoProButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaDesde = fechaDesdePicker.Value;
                DateTime fechaHasta = fechaHastaPicker.Value.AddDays(1);
                string motivo = motivoTextBox.Text.ToString();
                DateTime fechaActual = DateTime.Parse(Configuracion_Global.fecha_actual);

                if (motivo.Trim().Equals(""))
                {
                    MessageBox.Show("Debe completar todos los campos del formulario", "Cancelar Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Base_de_Datos.BD_Turnos.cancelar_turnos_pro(fechaDesde, fechaHasta, motivo, usuario.id);

                MessageBox.Show("Los turnos se cancelaron exitosamente", "Cancelar Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Cancelar Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

}
