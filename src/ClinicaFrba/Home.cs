using ClinicaFrba.Abm_Afiliado;
using ClinicaFrba.Base_de_Datos;
using ClinicaFrba.Clases;
using ClinicaFrba.Pedir_Turno;
using System;
using System.Windows.Forms;


namespace ClinicaFrba
{
    public partial class Home : Form
    {
        public string user;
        public string password;
        public string rol_descripcion;
        public Usuario usuario;

        public void asegurarConeccion()
        {
        }
        public Home()
        {
            InitializeComponent();

        }

        private void deshabilitar_componentes()
        {
            this.nuevoAfiliadoToolStripMenuItem.Enabled                     = false;
            this.modificarAfiliadoToolStripMenuItem.Enabled                 = false;
            this.bajaAfiliadoToolStripMenuItem.Enabled                      = false;
            this.pedirTurnoToolStripMenuItem.Enabled                        = false;
            this.cancelarTurnosProfesional_ToolStripMenuItem.Enabled        = false;
            this.comprarBonoUsuario_ToolStripMenuItem.Enabled               = false;
            this.agendaCrearTurnos_ToolStripMenuItem.Enabled                = false;
            this.cancelarTurnosUsuario_ToolStripMenuItem.Enabled            = false;
            this.registrarLlegadaAfiliadoToolStripMenuItem.Enabled          = false;
            this.registrarResultadoDiagnosticoToolStripMenuItem.Enabled     = false;
            this.nuevRolToolStripMenuItem.Enabled                           = false;
            this.modificarRol_ToolStripMenuItem.Enabled                     = false;
            this.comprarBonoAdmin_ToolStripMenuItem.Enabled                 = false;
            this.estadisticasToolStripMenuItem.Enabled                      = false;

            this.afiliadoToolStripMenuItem.Enabled = false;
            this.profesionalesToolStripMenuItem.Enabled = false;
            this.adminToolStripMenuItem.Enabled = false;
        }
        private void habilitar_componentes()
        {
            //En base a los Permisos, vemos las Pestañas a Habilitar para Usar

            if (this.usuario.permisos.Contains("ALTA_AFILIADO"))                this.nuevoAfiliadoToolStripMenuItem.Enabled                     = true;
            if (this.usuario.permisos.Contains("MODIFICAR_AFILIADO"))           this.modificarAfiliadoToolStripMenuItem.Enabled                 = true;
            if (this.usuario.permisos.Contains("BAJA_AFILIADO"))                this.bajaAfiliadoToolStripMenuItem.Enabled                      = true;
            if (this.usuario.permisos.Contains("PEDIR_TURNO"))                  this.pedirTurnoToolStripMenuItem.Enabled                        = true;
            if (this.usuario.permisos.Contains("CANCELAR_TURNO"))               this.cancelarTurnosUsuario_ToolStripMenuItem.Enabled            = true;
            if (this.usuario.permisos.Contains("COMPRAR_BONO"))                 this.comprarBonoUsuario_ToolStripMenuItem.Enabled               = true;
            if (this.usuario.permisos.Contains("CREAR_AGENDA"))                 this.agendaCrearTurnos_ToolStripMenuItem.Enabled                = true;
            if (this.usuario.permisos.Contains("CANCELAR_TURNOS_AGENDA"))       this.cancelarTurnosProfesional_ToolStripMenuItem.Enabled        = true;
            if (this.usuario.permisos.Contains("REGISTRAR_LLEGADA"))            this.registrarLlegadaAfiliadoToolStripMenuItem.Enabled           = true;
            if (this.usuario.permisos.Contains("REGISTRAR_DIAGNOSTICO"))        this.registrarResultadoDiagnosticoToolStripMenuItem.Enabled     = true;
            if (this.usuario.permisos.Contains("CREAR_ROL"))                    this.nuevRolToolStripMenuItem.Enabled                           = true;
            if (this.usuario.permisos.Contains("MODIFICAR_ROL"))                this.modificarRol_ToolStripMenuItem.Enabled                     = true;
            if (this.usuario.permisos.Contains("COMPRA_BONO_ADMINISTRADOR"))    this.comprarBonoAdmin_ToolStripMenuItem.Enabled                 = true;
            if (this.usuario.permisos.Contains("ESTADISTICAS"))                 this.estadisticasToolStripMenuItem.Enabled                      = true;


            if (usuario.permisos.Contains("ALTA_AFILIADO")  || 
                usuario.permisos.Contains("MODIFICAR_AFILIADO")  || 
                usuario.permisos.Contains("BAJA_AFILIADO")  || 
                usuario.permisos.Contains("PEDIR_TURNO")  || 
                usuario.permisos.Contains("CANCELAR_TURNO")  || 
                usuario.permisos.Contains("COMPRAR_BONO")
                ) this.afiliadoToolStripMenuItem.Enabled = true;

            if (usuario.permisos.Contains("CREAR_AGENDA") ||
                usuario.permisos.Contains("CANCELAR_TURNOS_AGENDA") ||
                usuario.permisos.Contains("REGISTRAR_DIAGNOSTICO")
                )
                this.profesionalesToolStripMenuItem.Enabled = true;

            if (usuario.permisos.Contains("REGISTRAR_LLEGADA") ||
                usuario.permisos.Contains("CREAR_ROL") ||
                usuario.permisos.Contains("MODIFICAR_ROL") ||
                usuario.permisos.Contains("COMPRA_BONO_ADMINISTRADOR") ||
                usuario.permisos.Contains("ESTADISTICAS")
                )
                this.adminToolStripMenuItem.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            deshabilitar_componentes();
            this.AcceptButton = boton_loguear;

            Configuracion_Global.cargar_archivo_configuracion();
            label_fecha.Text = "Fecha Actual: " + Configuracion_Global.fecha_actual;

            try
            {
                var lista = BD_Roles.obtener_roles();
                ComboData.llenarCombo(this.comboBox_rol, lista);
                this.comboBox_rol.DropDownStyle = ComboBoxStyle.DropDownList;
                this.comboBox_rol.Text = "ADMINISTRADOR GENERAL";
            }
            catch (Exception ex)
            {
                InteraccionDB.ImprimirExcepcion(ex);
                MessageBox.Show("Error al Pedir Roles contra la Base. Compruebe que la Base de Datos este Poblada. " + ex.Message, "Log_In", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loguear();
        }

        /// <summary>
        /// Log In de cualquier Usuario en la Base Datos
        /// </summary>
        private void loguear()
        {
            //Evitamos Cosas Raras de Doble Logueo
            deshabilitar_componentes();

            try
            {
                this.user = textBox_usuario.Text.Trim();
                this.password = textBox_password.Text.Trim();
                this.rol_descripcion = comboBox_rol.Text.Trim();

                this.usuario = Negocio.Log_In.Ingresar_App(this.user, this.password, this.rol_descripcion);
                this.usuario.nick_usuario = user;
                this.usuario.password = this.password;

                MessageBox.Show("Login Exitoso", "Log_In", MessageBoxButtons.OK, MessageBoxIcon.Information);

                habilitar_componentes();
                label_bienvenido.Visible = true;
                //Deshabilito Loguear
                /*
                this.textBox_usuario.Enabled = false;
                this.textBox_password.Enabled = false;
                this.comboBox_rol.Enabled = false;
                this.logInToolStripMenuItem.Enabled = false;
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Log_In", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var altaAfiliado = new ABM_AFILIADO();
            altaAfiliado.funcionalidad = ABM_AFILIADO.tipos_funcionalidad.ALTA;
            altaAfiliado.usuario = this.usuario;

            var identificar_afiliado = new IdentificarAfiliado();
            identificar_afiliado.usuario = this.usuario;
            identificar_afiliado.siguiente = altaAfiliado;
            identificar_afiliado.ShowDialog();
        }

        private void modificarAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var modificaAfiliado = new ABM_AFILIADO();
            modificaAfiliado.funcionalidad = ABM_AFILIADO.tipos_funcionalidad.MODIFICACION;
            modificaAfiliado.usuario = this.usuario;

            var identificar_afiliado = new IdentificarAfiliado();
            identificar_afiliado.usuario = this.usuario;
            identificar_afiliado.siguiente = modificaAfiliado;
            identificar_afiliado.ShowDialog();
        }

        private void bajaAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var bajaAfiliado = new ABM_AFILIADO();
            bajaAfiliado.funcionalidad = ABM_AFILIADO.tipos_funcionalidad.BAJA;
            bajaAfiliado.usuario = this.usuario;

            var identificar_afiliado = new IdentificarAfiliado();
            identificar_afiliado.usuario = this.usuario;
            identificar_afiliado.siguiente = bajaAfiliado;
            identificar_afiliado.ShowDialog();
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var agendaMedico = new AgendaMedico.AgendaMedico();
            agendaMedico.usuario = this.usuario;
            agendaMedico.ShowDialog();
        }

        private void cancelarTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cancelarTurnoPro = new CancelarTurno.CancelarTurnoProfesional();
            cancelarTurnoPro.usuario = this.usuario;
            cancelarTurnoPro.ShowDialog();
        }

        private void cancelarTurnosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var cancelarTurnoAfiliado = new CancelarTurno.CancelarTurnoAfiliado();
            cancelarTurnoAfiliado.usuario = this.usuario;
            cancelarTurnoAfiliado.ShowDialog();
        }

        private void pedirTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pedir_turno = new PedirTurno();
            pedir_turno.usuario = this.usuario;
            pedir_turno.ShowDialog();
        }

        private void comprarBonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Compra_Bono.CompraBonoAfiliado();
            form.usuario = this.usuario;
            form.ShowDialog();
        }

        private void comprarBonoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Compra_Bono.CompraBonoAdmin();
            form.funcionalidad = Compra_Bono.CompraBonoAdmin.tipos_funcionalidad.ADMIN;
            form.usuario_o_administrador = this.usuario;
            form.ShowDialog();
        }

        private void nuevRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AbmRol.CrearRol().ShowDialog();
        }

        private void bajaRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AbmRol.ModificarRol().ShowDialog();
        }

        private void estadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Estadisticas.Estadisticas().ShowDialog();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            loguear();
        }
        
        private void textBox_usuario_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras_y_arroba(e);
        }

        private void registrarResultadoDiagnosticoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var registrarResultado = new AtencionesMedicas.RegistrarResultado();
            registrarResultado.usuario = this.usuario;
            registrarResultado.ShowDialog();
        }

        private void registrarLlegadaAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AtencionesMedicas.RegistrarLlegada();
            form.usuario_profesional = this.usuario;
            form.ShowDialog();
        }
    }
}
