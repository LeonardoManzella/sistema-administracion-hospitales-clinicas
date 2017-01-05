using System;
using System.Windows.Forms;
using ClinicaFrba.Clases;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ABM_AFILIADO : Form
    {
        public enum tipos_funcionalidad
        {
            ALTA,
            MODIFICACION,
            BAJA
        };


        public tipos_funcionalidad funcionalidad;
        public Usuario usuario;
        public Afiliado afiliado;
        public Afiliado afiliado_principal;
        private List<Afiliado> afiliados_a_cargo = new List<Afiliado>();
        private int ID_CONYUGE = 2;     //El ID base para Conyuge debe ser 2

        public ABM_AFILIADO()
        {
            InitializeComponent();
        }

        private string validar_campos()
        {
            var error = "";
            if (string.IsNullOrWhiteSpace(txtApellido.Text.Trim()))
                error += "El Campo apellido no puede quedar vacío \r\n";

            if (cmbEstadoCiv.SelectedIndex < 0)
                error += "El estado civil no puede quedar sin seleccionar \r\n";


            if (cmbSexo.SelectedIndex < 0)
                error += "El género no puede quedar sin seleccionar \r\n";


            if (cmbTipoDoc.SelectedIndex < 0)
                error += "El tipo de documento no puede quedar sin seleccionar \r\n";

            if (string.IsNullOrWhiteSpace(TxtMail.Text.Trim()))
            { error += "El campo e-mail es obligatorio \r\n"; }
            else
            {
                if (!Helper.Email_valido(TxtMail.Text.Trim()))
                {
                    error += "El campo e-mail no tiene un formato correcto \r\n" ;
                };
            }
            //if (dtFNac.Value < DateTime.Parse(Configuracion_Global.fecha_actual).AddYears(-115))
            if (afiliado.fecha_nac < DateTime.Parse(Configuracion_Global.fecha_actual).AddYears(-115))
            {
                var rta = MessageBox.Show("EL año de nacimiento parece mal cargado, ¿está seguro desea continuar? \r\n", "Fecha Nacimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rta == DialogResult.No)
                    error += "La fecha indicada se ha declarado como incorrecta, debe reasignarse \r\n";
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text.Trim()))
            {
                error += "El Campo nombre no puede quedar vacío \r\n";
            };

            if (String.IsNullOrEmpty(txtNroDoc.Text.Trim()))
                error += "El Campo Número de Documento no puede quedar vacío \r\n";

            return error;
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            try
            {
                //var cerrar = false; por pedido
                var cerrar = false;
                var error = "";
                var id_us = 0;

                if (funcionalidad == tipos_funcionalidad.MODIFICACION)
                //Modific
                {

                    error = validar_campos();
                    if (error == "")
                    {
                        mapAfiliado_Vista(afiliado);
                        Negocio.ABMAFIL.modifica_afiliado(afiliado);
                        MessageBox.Show("Se ha modificado el afiliado sastifactoriamente");
                        cerrar = true;
                    }
                }
                else if (funcionalidad == tipos_funcionalidad.ALTA)
                {  //alta
                    error = validar_campos();
                    if (error == "")
                    {//Si es un alta y viene un  id en el afiliado principal, significa que estamos dando de alta un afiliado a cargo
                        if (afiliado_principal.id != 0)
                        {
                            afiliado.id_principal = afiliado_principal.id;
                            mapAfiliado_Vista(afiliado);
                            if (this.chkConyuge.Checked == true)
                            {
                                afiliado.id = ID_CONYUGE;
                            }
                            id_us = Negocio.ABMAFIL.alta_afiliado_adjunto(afiliado);
                            if (id_us > 0)
                            {
                                this.txtAfilId.Text = id_us.ToString();
                                this.Text = "MODIFICA AFILIADO";
                                this.chkConyuge.Visible = false;
                                this.chkConyuge.Checked = false;
                                MessageBox.Show("Se ha realizado el alta correctamente");
                                funcionalidad = tipos_funcionalidad.MODIFICACION;
                                bloquearNoEditable();
                                cerrar = true;
                            }
                            else
                            {
                                MessageBox.Show("Ha ocurrido un error no manejado, contacte a su administrador de BD", "ERROR ABM AFILIADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            };

                        }
                        else
                        {
                            //Si viene por acá significa que es  un titular
                            mapAfiliado_Vista(afiliado_principal);
                            id_us = Negocio.ABMAFIL.alta_afiliado(afiliado_principal);
                            if (id_us > 0)
                            {

                                int i = 0;
                                //Si se agrega una nueva ventana a traves de un botón que 
                                //llame a la misma pantalla podría adjuntar a una lista el grupo familiar
                                var sin_problema = true;
                                for (i = 0; i < afiliados_a_cargo.Count; i++)
                                {
                                    var id_us_sec = Negocio.ABMAFIL.alta_afiliado_adjunto(afiliados_a_cargo[i]);
                                    if (id_us_sec <= 0)
                                    {
                                        sin_problema = false;
                                        MessageBox.Show("No se ha realizado el alta correctamente");
                                    }
                                }

                                if (sin_problema)
                                {
                                    this.txtAfilId.Text = id_us.ToString();
                                    this.Text = "MODIFICA AFILIADO";

                                    MessageBox.Show("Se ha realizado el alta correctamente");
                                    funcionalidad = tipos_funcionalidad.MODIFICACION;
                                    bloquearNoEditable();
                                    cerrar = true;
                                }
                            }
                        }
                    }
                }

                else if (funcionalidad == tipos_funcionalidad.BAJA)
                //Baja
                {
                    var respuesta = Negocio.ABMAFIL.baja_afiliado(afiliado.id);
                    if (respuesta)
                    {
                        error = "";
                        MessageBox.Show("Se ha realizado la baja correctamente");
                        cerrar = true;
                    }
                    else
                    {
                        error = "Ha ocurrido un error la baja no ha podido realizarse \r\n";
                    }
                };

                if (error != "")
                {
                    MessageBox.Show(error, "ERROR ABM AFILIADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };

                if (cerrar)
                    this.Close();
            }
            catch (Exception ex)
            {
                string mensaje = "Ha ocurrido un Error. Por Favor Verifique los datos";
                if (ex.Message.Contains("Ya existe el Afiliado")) mensaje = ex.Message;
                if (ex.Message.Contains("cónyuge declarado")) mensaje = ex.Message;

                MessageBox.Show(mensaje, "ABM_AFILIADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void ABMAFILIADO_Load(object sender, EventArgs e)
        {
            try
            {
                cargar_pantalla();
                txtAfilId.Enabled = false;
                if (funcionalidad == tipos_funcionalidad.ALTA)
                {
                    this.afiliado.fecha_nac = DateTime.Parse(Configuracion_Global.fecha_actual);
                    this.txtFec_Nac.Text = this.afiliado.fecha_nac.ToShortDateString();
                    
                    btnLimpiar_Click(sender, e);
                    this.Text = "ALTA AFILIADO";
                    if (afiliado_principal.id != 0)
                    {
                        this.chkConyuge.Visible = true;
                    }
                    else
                    {
                        this.chkConyuge.Visible = false;
                    };
                }
                else if (funcionalidad == tipos_funcionalidad.MODIFICACION)
                {
                    this.Text = "MODIFICA AFILIADO";
                    this.afiliado = Negocio.ABMAFIL.Get_Afiliado(afiliado.id);
                    afiliado_en_pantalla();
                    bloquearNoEditable();
                }
                else
                {
                    this.Text = "ELIMINA AFILIADO";
                    this.afiliado = Negocio.ABMAFIL.Get_Afiliado(afiliado.id);
                    afiliado_en_pantalla();
                    bloquearTodo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Cargar Form. " + ex.Message, "ABM_AFILIADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void afiliado_en_pantalla()
        {
            txtApellido.Text = afiliado.apellido;
            txtDireccion.Text = afiliado.direccion;
            cmbEstadoCiv.SelectedIndex = ComboData.obtener_indice(afiliado.estado_civil, cmbEstadoCiv);
            TxtMail.Text = afiliado.e_mail;
            //dtFNac.Value = afiliado.fecha_nac;
            txtFec_Nac.Text = afiliado.fecha_nac.ToShortDateString();
            txtAfilId.Text = afiliado.id.ToString();
            txtNombre.Text = afiliado.nombre;
            txtNroDoc.Text = afiliado.nro_doc.ToString();
            cmbPlan.SelectedIndex = ComboData.obtener_indice(afiliado.plan_id.Value, cmbPlan);
            txtNroTelefono.Text = afiliado.telefono.ToString();
            //selecciono el item que tiene de descripcion
            cmbSexo.SelectedIndex = ComboData.obtener_indice(afiliado.sexo, cmbSexo);
            //selecciono el item que tiene de descripcion
            cmbTipoDoc.SelectedIndex = ComboData.obtener_indice(afiliado.tipo_doc, cmbTipoDoc);

        }

        private void bloquearNoEditable()
        {
            txtApellido.Enabled = false;
            txtNombre.Enabled = false;
            txtNroDoc.Enabled = false;
            //dtFNac.Enabled = false;
            btn_fecha.Enabled = false;
        }

        private void bloquearTodo()
        {
            txtApellido.Enabled = false;
            txtDireccion.Enabled = false;
            cmbEstadoCiv.Enabled = false;
            TxtMail.Enabled = false;
            btn_fecha.Enabled = false;
            //dtFNac.Enabled = false;
            txtAfilId.Enabled = false;
            txtNombre.Enabled = false;
            txtNroDoc.Enabled = false;
            cmbPlan.Enabled = false;
            txtNroTelefono.Enabled = false;
            cmbSexo.Enabled = false;
            cmbTipoDoc.Enabled = false;
            btnLimpiar.Visible = false;

        }

        private void cargar_pantalla()
        {
            #region combos

            //cargo el combo de sexo
            this.cmbSexo.DisplayMember = "descripcion";
            this.cmbSexo.ValueMember = "identificador";
            this.cmbSexo.Items.Clear();
            this.cmbSexo.Items.Add(new ComboData(77, "M"));
            this.cmbSexo.Items.Add(new ComboData(70, "F"));
            this.cmbSexo.Items.Add(new ComboData(84, "T"));

            this.cmbEstadoCiv.DisplayMember = "descripcion";
            this.cmbEstadoCiv.ValueMember = "identificador";
            var estados = Negocio.ABMAFIL.get_Estados_Civiles();

            foreach (ComboData estado in estados)
            {
                this.cmbEstadoCiv.Items.Add(estado);
            }

            this.cmbPlan.DisplayMember = "descripcion";
            this.cmbPlan.ValueMember = "identificador";
            var planes = Negocio.ABMAFIL.get_Planes_Sociales();

            foreach (ComboData plan in planes)
            {
                this.cmbPlan.Items.Add(plan);
            }

            //Cargo el combo de tipos de documentos

            var tipos = Negocio.ABMAFIL.get_Tipos_Documentos();
            this.cmbTipoDoc.DataSource = tipos;
            this.cmbTipoDoc.DisplayMember = "descripcion";
            this.cmbTipoDoc.ValueMember = "identificador";

            #endregion
        }

        private void mapAfiliado_Vista(Afiliado afiliado)
        {
            afiliado.apellido = txtApellido.Text;
            afiliado.direccion = txtDireccion.Text;
            afiliado.estado_civil = ComboData.obtener_identificador(cmbEstadoCiv);
            afiliado.e_mail = TxtMail.Text;
            //afiliado.fecha_nac = dtFNac.Value;
            if (!String.IsNullOrEmpty(txtAfilId.Text.Trim()))
                afiliado.id = Int32.Parse(txtAfilId.Text);

            afiliado.nombre = txtNombre.Text;

            if (!String.IsNullOrEmpty(txtNroDoc.Text.Trim()))
                afiliado.nro_doc = Int32.Parse(txtNroDoc.Text);

            afiliado.plan_id = ComboData.obtener_identificador(cmbPlan);
            afiliado.sexo = ComboData.obtener_descripcion(cmbSexo)[0];
            afiliado.telefono = string.IsNullOrEmpty(txtNroTelefono.Text.Trim())? new int?(): Int32.Parse(txtNroTelefono.Text.Trim());
            afiliado.tipo_doc = ComboData.obtener_descripcion(cmbTipoDoc);
            afiliado.fecha_nac = DateTime.Parse(txtFec_Nac.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras(e);
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_numeros(e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras_y_numeros(e);
        }

        private void txtNroTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_numeros(e);
        }

        private void TxtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras_y_arroba(e);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            var new_afil = new Afiliado() { id = this.afiliado.id, id_principal = this.afiliado.id_principal, usuario = this.afiliado.usuario };
            this.afiliado = new_afil;

            if (!Equals(this.funcionalidad, tipos_funcionalidad.MODIFICACION))
            {
                this.afiliado.fecha_nac = DateTime.Parse( Configuracion_Global.fecha_actual);
                txtFec_Nac.Text = afiliado.fecha_nac.ToShortDateString();
                txtAfilId.Text = (afiliado.id == 0) ? string.Empty : afiliado.id.ToString();
                txtNombre.Text = afiliado.nombre;
                txtApellido.Text = afiliado.apellido;
                //dtFNac.Value = dtFNac.MinDate;
                txtNroDoc.Text = (afiliado.nro_doc == 0) ? string.Empty : afiliado.nro_doc.ToString();
            }
            txtDireccion.Text = afiliado.direccion;
            TxtMail.Text = afiliado.e_mail;
            txtNroTelefono.Text = afiliado.telefono.ToString();
            cmbTipoDoc.SelectedIndex = 0;
            cmbPlan.SelectedIndex = 0;
            cmbSexo.SelectedIndex = 0;
            cmbEstadoCiv.SelectedIndex = 0;

        }

        private void btn_fecha_Click(object sender, EventArgs e)
        {
            var seleccionarFecha = new SelecionarFecha();
            seleccionarFecha.fecha = DateTime.Parse(this.txtFec_Nac.Text);
            seleccionarFecha.ShowDialog();
            this.afiliado.fecha_nac = seleccionarFecha.fecha;
            this.afiliado_principal.fecha_nac = seleccionarFecha.fecha;
            this.txtFec_Nac.Text = afiliado_principal.fecha_nac.ToShortDateString();
        }
    }
}
