using ClinicaFrba.Base_de_Datos;
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

namespace ClinicaFrba.Estadisticas
{

    public partial class Estadisticas : Form
    {

        private int especialidad;
        private int plan;
        private int cancelador;
        private int mes_desde;
        private int mes_hasta;
        private List<ComboData> semestre1;
        private List<ComboData> semestre2;

        ComboData cero;
        public Estadisticas()
        {
            InitializeComponent();
        }


        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                int año;
                if (!string.IsNullOrWhiteSpace(this.txtAnio.Text))
                    año = Int32.Parse(this.txtAnio.Text);
                else
                {
                    año = 0;
                    //throw new Exception("Debe indicar un año, para realizar la consulta \r\n Usar 0 si se quiere de todos los años");
                }

                if (mes_desde > mes_hasta)
                {
                    throw new Exception("El Mes de Inicio no puede ser mayor al Mes Final");
                }

                var estadistica = ComboData.obtener_identificador(this.comboTop5);
                switch (estadistica)
                {
                    case 1:
                        Especialidades_mas_canceladas(año);
                        break;
                    case 2:
                        Profesionales_mas_consultados(año);
                        break;
                    case 3:
                        Profesionales_que_menos_trabajaron(año);
                        break;
                    case 4:
                        Afiliado_que_mas_bonos_compro(año);
                        break;
                    case 5:
                        Especialidades_mas_concurridas(año);
                        break;
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ESTADISTICAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Especialidades_mas_concurridas(int año)
        {
            try
            {

                //DATAGRID
                DataTable datos = BD_Estadisticas.get_top5_esp_con_mas_bonos(año, mes_desde, mes_hasta);

                //Lleno el DataGrid
                Comunes.llenar_dataGrid(dataGridEstadistico, datos);

                if (datos.Rows.Count <= 0) throw new Exception("No hay resultados para Estos Filtros");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ESTADISTICAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void Profesionales_que_menos_trabajaron(int año)
        {
            try
            {

                //DATAGRID
                DataTable datos = BD_Estadisticas.get_top5_prof_vagos(año, mes_desde, mes_hasta, plan, especialidad);

                //Lleno el DataGrid
                Comunes.llenar_dataGrid(dataGridEstadistico, datos);

                if (datos.Rows.Count <= 0) throw new Exception("No hay resultados para Estos Filtros");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ESTADISTICAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void Profesionales_mas_consultados(int año)
        {
            try
            {

                //DATAGRID
                DataTable datos = BD_Estadisticas.get_top5_prof_plan(año, mes_desde, mes_hasta, plan);

                //Lleno el DataGrid
                Comunes.llenar_dataGrid(dataGridEstadistico, datos);

                if (datos.Rows.Count <= 0) throw new Exception("No hay resultados para Estos Filtros");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ESTADISTICAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void Afiliado_que_mas_bonos_compro(int año)
        {
            try
            {

                //DATAGRID
                DataTable datos = BD_Estadisticas.get_top5_afil_compra_bonos(año, mes_desde, mes_hasta);

                //Lleno el DataGrid
                Comunes.llenar_dataGrid(dataGridEstadistico, datos);

                if (datos.Rows.Count <= 0) throw new Exception("No hay resultados para Estos Filtros");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ESTADISTICAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Especialidades_mas_canceladas(int año)
        {
            try
            {

                //DATAGRID
                DataTable datos = BD_Estadisticas.get_top5_canc_esp(año, mes_desde, mes_hasta, cancelador);

                //Lleno el DataGrid
                Comunes.llenar_dataGrid(dataGridEstadistico, datos);

                if (datos.Rows.Count <= 0) throw new Exception("No hay resultados para Estos Filtros. Revise que haya almenos una cancelacion");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ESTADISTICAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_numeros(e);
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {
            try
            {

                #region combos

                cero = new ComboData(0, "Indistinto");

                this.comboEspec.DisplayMember = "descripcion";
                this.comboEspec.ValueMember = "identificador";
                var estados = Llegada_At_Med.obtenerEspecialidades();
                this.comboEspec.Items.Add(cero);
                foreach (ComboData item in estados)
                {
                    this.comboEspec.Items.Add(item);
                }

                this.comboBox3.DisplayMember = "descripcion";
                this.comboBox3.ValueMember = "identificador";
                var planes = ABMAFIL.get_Planes_Sociales();
                this.comboBox3.Items.Add(cero);
                foreach (ComboData item in planes)
                {
                    this.comboBox3.Items.Add(item);
                }


                this.comboTop5.DisplayMember = "descripcion";
                this.comboTop5.ValueMember = "identificador";
                this.comboTop5.Items.Add(new ComboData(1, "Especialidades más canceladas"));
                this.comboTop5.Items.Add(new ComboData(2, "Profesionales más consultados"));
                this.comboTop5.Items.Add(new ComboData(3, "Profesionales que menos trabajaron"));
                this.comboTop5.Items.Add(new ComboData(4, "Afiliado que más bonos compró"));
                this.comboTop5.Items.Add(new ComboData(5, "Especialidades más concurridas"));

                this.comboSemestre.DisplayMember = "descripcion";
                this.comboSemestre.ValueMember = "identificador";
                this.comboSemestre.Items.Add(cero);
                this.comboSemestre.Items.Add(new ComboData(1, "Primer"));
                this.comboSemestre.Items.Add(new ComboData(2, "Segundo"));

                this.cmbQuienCancela.DisplayMember = "descripcion";
                this.cmbQuienCancela.ValueMember = "identificador";
                this.cmbQuienCancela.Items.Add(cero);
                this.cmbQuienCancela.Items.Add(new ComboData(2, "Profesional"));
                this.cmbQuienCancela.Items.Add(new ComboData(1, "Afiliado"));


                this.cmbHasta.DisplayMember = "descripcion";
                this.cmbHasta.ValueMember = "identificador";

                this.cmbDesde.DisplayMember = "descripcion";
                this.cmbDesde.ValueMember = "identificador";

                this.semestre1 = cargarSemestre(1);
                this.semestre2 = cargarSemestre(2);
                #endregion

                btnLimpiar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Cargar Form: " + ex.Message, "Estadisticas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<ComboData> cargarSemestre(int nro)
        {
            var semestre = new List<ComboData>();
            //Esto devuelve un ciclo entre 0 y 6, o entre 6 y 12
            for (int i = (6 * (nro - 1)) + 1; i < nro * 6 + 1; i++)
            {
                semestre.Add(new ComboData(i, i.ToString()));
            }

            return semestre;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtAnio.Text = "";
            this.cmbQuienCancela.SelectedIndex = ComboData.obtener_indice(0, this.cmbQuienCancela);
            comboBox3.SelectedIndex = ComboData.obtener_indice(0, this.comboBox3);
            comboSemestre.SelectedIndex = ComboData.obtener_indice(0, this.comboSemestre);
            comboTop5.SelectedIndex = ComboData.obtener_indice(1, this.comboTop5);
            comboEspec.SelectedIndex = ComboData.obtener_indice(0, this.comboEspec);
            Comunes.llenar_dataGrid(dataGridEstadistico, new DataTable());
        }

        private void comboTop5_SelectedIndexChanged(object sender, EventArgs e)
        {
            var estadistica = ComboData.obtener_identificador(this.comboTop5);
            switch (estadistica)
            {
                case 1: //Especialidades_mas_canceladas();
                    this.lblEspecialidad.Visible = false;
                    this.comboEspec.Visible = false;
                    this.lblPlan.Visible = false;
                    this.comboBox3.Visible = false;
                    this.lblCance.Visible = true;
                    this.cmbQuienCancela.Visible = true;
                    break;
                case 2://Profesionales_mas_consultados();
                    this.lblEspecialidad.Visible = false;
                    this.comboEspec.Visible = false;
                    this.lblPlan.Visible = true;
                    this.comboBox3.Visible = true;
                    this.lblCance.Visible = false;
                    this.cmbQuienCancela.Visible = false;
                    break;
                case 3://Profesionales_que_menos_trabajaron();
                    this.lblEspecialidad.Visible = true;
                    this.comboEspec.Visible = true;
                    this.lblPlan.Visible = true;
                    this.comboBox3.Visible = true;
                    this.lblCance.Visible = false;
                    this.cmbQuienCancela.Visible = false;
                    break;
                case 4://Afiliado_que_mas_bonos_compro();
                    this.lblEspecialidad.Visible = false;
                    this.comboEspec.Visible = false;
                    this.lblPlan.Visible = false;
                    this.comboBox3.Visible = false;
                    this.lblCance.Visible = false;
                    this.cmbQuienCancela.Visible = false;
                    break;
                case 5://Especialidades_mas_concurridas();
                    this.lblEspecialidad.Visible = false;
                    this.comboEspec.Visible = false;
                    this.lblPlan.Visible = false;
                    this.comboBox3.Visible = false;
                    this.lblCance.Visible = false;
                    this.cmbQuienCancela.Visible = false;
                    break;
            };
        }

        private void comboEspec_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.especialidad = ComboData.obtener_identificador(comboEspec);
        }

        private void cmbQuienCancela_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cancelador = ComboData.obtener_identificador(cmbQuienCancela);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.plan = ComboData.obtener_identificador(comboBox3);
        }

        private void comboSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            var semestre = ComboData.obtener_identificador(comboSemestre);
            if (semestre == 1)
            {
                this.cmbDesde.Items.Clear();
                this.cmbHasta.Items.Clear();
                foreach (ComboData item in semestre1)
                {
                    this.cmbDesde.Items.Add(item);
                    this.cmbHasta.Items.Add(item);
                };
                cmbDesde.SelectedIndex = 0;
                cmbHasta.SelectedIndex = 5;
            }
            else
            {
                if (semestre == 2)
                {
                    this.cmbDesde.Items.Clear();
                    this.cmbHasta.Items.Clear();
                    foreach (ComboData item in semestre2)
                    {
                        this.cmbDesde.Items.Add(item);
                        this.cmbHasta.Items.Add(item);
                    };
                    cmbDesde.SelectedIndex = 0;
                    cmbHasta.SelectedIndex = 5;
                }
                else
                {
                    this.cmbDesde.Items.Clear();
                    this.cmbHasta.Items.Clear();
                    foreach (ComboData item in semestre1)
                    {
                        this.cmbDesde.Items.Add(item);
                        this.cmbHasta.Items.Add(item);
                    };
                    foreach (ComboData item in semestre2)
                    {
                        this.cmbDesde.Items.Add(item);
                        this.cmbHasta.Items.Add(item);
                    };
                    cmbDesde.SelectedIndex = 0;
                    cmbHasta.SelectedIndex = 11;
                }
            }
        }

        private void cmbDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mes_desde = int.Parse(ComboData.obtener_descripcion(cmbDesde));
        }

        private void cmbHasta_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mes_hasta = int.Parse(ComboData.obtener_descripcion(cmbHasta));
        }
    }
}
