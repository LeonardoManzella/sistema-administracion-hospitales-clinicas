using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Clases;

namespace ClinicaFrba.AgendaMedico
{
    public partial class AgendaMedico : Form
    {

        private Dictionary<string, int> diasSemana = new Dictionary<string, int>();
        private List<HorariosDia> diasAgenda = new List<HorariosDia>();
        List<string> horariosComun = new List<string>();
        List<string> horariosSabado = new List<string>();
        public Usuario usuario;
        private int idProfesional;

        public AgendaMedico()
        {
            try
            {

                InitializeComponent();
                this.diasSemana.Add("Lunes", 1);
                this.diasSemana.Add("Martes", 2);
                this.diasSemana.Add("Miercoles", 3);
                this.diasSemana.Add("Jueves", 4);
                this.diasSemana.Add("Viernes", 5);
                this.diasSemana.Add("Sabado", 6);

                this.horariosComun.Add("07:00");
                this.horariosComun.Add("07:30");
                this.horariosComun.Add("08:00");
                this.horariosComun.Add("08:30");
                this.horariosComun.Add("09:00");
                this.horariosComun.Add("09:30");
                this.horariosComun.Add("10:00");
                this.horariosComun.Add("10:30");
                this.horariosComun.Add("11:00");
                this.horariosComun.Add("11:30");
                this.horariosComun.Add("12:00");
                this.horariosComun.Add("12:30");
                this.horariosComun.Add("13:00");
                this.horariosComun.Add("13:30");
                this.horariosComun.Add("14:00");
                this.horariosComun.Add("14:30");
                this.horariosComun.Add("15:00");
                this.horariosComun.Add("15:30");
                this.horariosComun.Add("16:00");
                this.horariosComun.Add("16:30");
                this.horariosComun.Add("17:00");
                this.horariosComun.Add("17:30");
                this.horariosComun.Add("18:00");
                this.horariosComun.Add("18:30");
                this.horariosComun.Add("19:00");
                this.horariosComun.Add("19:30");
                this.horariosComun.Add("20:00");

                this.horariosSabado.Add("10:00");
                this.horariosSabado.Add("10:30");
                this.horariosSabado.Add("11:00");
                this.horariosSabado.Add("11:30");
                this.horariosSabado.Add("12:00");
                this.horariosSabado.Add("12:30");
                this.horariosSabado.Add("13:00");
                this.horariosSabado.Add("13:30");
                this.horariosSabado.Add("14:00");
                this.horariosSabado.Add("14:30");
                this.horariosSabado.Add("15:00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Llenar Clase del Form: " + ex.Message, "ABM_AFILIADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgendaMedico_Load(object sender, EventArgs e)
        {
            diasAgenda.Clear();
            especialidadCombo.Items.Clear();
            diasSemanaCombo.Items.Clear();
            horariosPorDiaList.Items.Clear();

            List<string> keyList = new List<string>(this.diasSemana.Keys);
            ComboData.llenarCombo(diasSemanaCombo, keyList);
            diasSemanaCombo.SelectedItem = diasSemanaCombo.Items[0];

            horarioDesdeCombo.Items.Clear();
            horarioHastaCombo.Items.Clear();
            this.llenarHorariosDesde(horarioDesdeCombo, false);
            this.llenarHorariosHasta(horarioHastaCombo, false);
            horarioDesdeCombo.SelectedItem = horarioDesdeCombo.Items[0];
            horarioHastaCombo.SelectedItem = horarioHastaCombo.Items[0];

            try
            {
                this.idProfesional = Base_de_Datos.BD_Profesional.obtenerID_profesional(usuario.id);
                List<string> especialidades = Base_de_Datos.BD_Profesional.getEspecialidadesProfesional(this.idProfesional);
                ComboData.llenarCombo(especialidadCombo, especialidades);
                especialidadCombo.SelectedItem = especialidadCombo.Items[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se obtuvieron las especialidades del profesional. " + ex.Message, "Agenda Medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime maxFechaAgendaExistente = Base_de_Datos.BD_Profesional.getUltimaFechaAgenda(this.idProfesional);
            if (maxFechaAgendaExistente != null)
            {
                DateTime minDate = maxFechaAgendaExistente.AddDays(1);
                fechaDesdePicker.MinDate = minDate;
                fechaDesdePicker.Value = minDate;
                fechaHastaPicker.MinDate = minDate;
                fechaHastaPicker.Value = minDate;
            }
            else
            {
                DateTime tomorrow = DateTime.ParseExact(Configuracion_Global.fecha_actual, "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture).AddDays(1);
                fechaDesdePicker.MinDate = tomorrow;
                fechaDesdePicker.Value = tomorrow;
                fechaHastaPicker.MinDate = tomorrow;
                fechaHastaPicker.Value = tomorrow;
            }
        }


        private void llenarHorariosDesde(ComboBox horarioComboBox, Boolean isSabado)
        {
            if (isSabado)
                ComboData.llenarCombo(horarioComboBox, this.horariosSabado);
            else
                ComboData.llenarCombo(horarioComboBox, this.horariosComun);
            horarioComboBox.Items.RemoveAt(horarioComboBox.Items.Count - 1);
        }

        private void llenarHorariosHasta(ComboBox horarioComboBox, Boolean isSabado)
        {
            if (isSabado)
                ComboData.llenarCombo(horarioComboBox, this.horariosSabado);
            else
                ComboData.llenarCombo(horarioComboBox, this.horariosComun);
            horarioComboBox.Items.RemoveAt(0);
        }

        private void diasSemanaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (String.Compare(diasSemanaCombo.Text, "Sabado") == 0)
                {
                    horarioDesdeCombo.Items.Clear();
                    horarioHastaCombo.Items.Clear();
                    this.llenarHorariosDesde(horarioDesdeCombo, true);
                    this.llenarHorariosHasta(horarioHastaCombo, true);
                }
                else
                {
                    horarioDesdeCombo.Items.Clear();
                    horarioHastaCombo.Items.Clear();
                    this.llenarHorariosDesde(horarioDesdeCombo, false);
                    this.llenarHorariosHasta(horarioHastaCombo, false);
                }
                horarioDesdeCombo.SelectedItem = horarioDesdeCombo.Items[0];
                horarioHastaCombo.SelectedItem = horarioHastaCombo.Items[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el dia de la semana: " + ex.Message, "Agenda Medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void agregarHorarioButton_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreDiaSemana = diasSemanaCombo.Text;
                int diaSemana = diasSemana[nombreDiaSemana];
                string horaDesde = horarioDesdeCombo.Text;
                string horaHasta = horarioHastaCombo.Text;
                HorariosDia diaNuevo = new HorariosDia(diaSemana, horaDesde, horaHasta, nombreDiaSemana);

                if ((diaNuevo.getCantidadHoras() + this.horasSumadas()) > 48)
                {
                    MessageBox.Show("El profesional no puede sumar mas de 48 horas semanales", "Agenda Medico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    diasSemanaCombo.Items.Add(diasSemanaCombo.SelectedItem);
                    return;
                }


                if (Int32.Parse(horaDesde.Substring(0, 2)) > Int32.Parse(horaHasta.Substring(0, 2)) ||
                    (Int32.Parse(horaDesde.Substring(0, 2)) == Int32.Parse(horaHasta.Substring(0, 2)) &&
                    Int32.Parse(horaDesde.Substring(3, 2)) >= Int32.Parse(horaHasta.Substring(3, 2))))
                {
                    MessageBox.Show("El horario final no puede ser menor o igual al inicial", "Agenda Medico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    diasSemanaCombo.Items.Add(diasSemanaCombo.SelectedItem);
                    return;
                }
                diasSemanaCombo.Items.Remove(diasSemanaCombo.SelectedItem);
                if (diasSemanaCombo.Items.Count == 0)
                {
                    agregarHorarioButton.Enabled = false;
                }
                else
                {
                    diasSemanaCombo.SelectedItem = diasSemanaCombo.Items[0];
                }
                diasAgenda.Add(diaNuevo);
                horariosPorDiaList.Items.Add(diaNuevo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar horario: " + ex.Message, "Agenda Medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double horasSumadas()
        {
            double horasSumadas = 0;
            foreach (HorariosDia dia in diasAgenda)
                horasSumadas += dia.getCantidadHoras();

            return horasSumadas;
        }

        private void borrarHorarioButton_Click(object sender, EventArgs e)
        {
            if (horariosPorDiaList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione los horarios a borrar", "Agenda Medico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else {

                if (diasSemanaCombo.Items.Count == 0)
                {
                    agregarHorarioButton.Enabled = true;
                }
                List<HorariosDia> selectedItemsList = horariosPorDiaList.SelectedItems.Cast<HorariosDia>().ToList();
                foreach (HorariosDia selectedItem in selectedItemsList)
                {
                    diasSemanaCombo.Items.Add(selectedItem.nombreDiaSemana);
                    diasAgenda.Remove(selectedItem);
                    horariosPorDiaList.Items.Remove(selectedItem);
                }

                horariosPorDiaList.SelectedItems.Clear();
            }
        }

        private void cancelarAgendaMedicaButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aceptarAgendaMedicaButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaDesde = fechaDesdePicker.Value;
                DateTime fechaHasta = fechaHastaPicker.Value;
                if (diasAgenda.Count == 0 || fechaDesde > fechaHasta)
                {
                    MessageBox.Show("Verifique los datos seleccionados", "Agenda Medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string especialidad = especialidadCombo.Text;

                Base_de_Datos.BD_Profesional.crearAgenda(this.idProfesional, fechaDesde, fechaHasta, diasAgenda, especialidad);

                MessageBox.Show("La agenda fue creada exitosamente", "Agenda Medico", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AgendaMedico_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la creacion de la agenda: " + ex.Message, "Agenda Medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fechaDesdePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaDesde = fechaDesdePicker.Value;
            fechaHastaPicker.MinDate = fechaDesde;
        }
    }
}
