namespace ClinicaFrba
{
    partial class Home
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afiliadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMAfiliadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoAfiliadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarAfiliadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaAfiliadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedirTurnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarTurnosUsuario_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprarBonoUsuario_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profesionalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agendaCrearTurnos_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarTurnosProfesional_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarResultadoDiagnosticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarRol_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprarBonoAdmin_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarLlegadaAfiliadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_bienvenido = new System.Windows.Forms.Label();
            this.boton_loguear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_rol = new System.Windows.Forms.ComboBox();
            this.label_fecha = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sesiónToolStripMenuItem,
            this.afiliadoToolStripMenuItem,
            this.profesionalesToolStripMenuItem,
            this.adminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(563, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sesiónToolStripMenuItem
            // 
            this.sesiónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logInToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.sesiónToolStripMenuItem.Name = "sesiónToolStripMenuItem";
            this.sesiónToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.sesiónToolStripMenuItem.Text = "&Sesión";
            // 
            // logInToolStripMenuItem
            // 
            this.logInToolStripMenuItem.Name = "logInToolStripMenuItem";
            this.logInToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.logInToolStripMenuItem.Text = "&Log In";
            this.logInToolStripMenuItem.Click += new System.EventHandler(this.logInToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // afiliadoToolStripMenuItem
            // 
            this.afiliadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMAfiliadoToolStripMenuItem,
            this.pedirTurnoToolStripMenuItem,
            this.cancelarTurnosUsuario_ToolStripMenuItem,
            this.comprarBonoUsuario_ToolStripMenuItem});
            this.afiliadoToolStripMenuItem.Name = "afiliadoToolStripMenuItem";
            this.afiliadoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.afiliadoToolStripMenuItem.Text = "&Afiliado";
            // 
            // aBMAfiliadoToolStripMenuItem
            // 
            this.aBMAfiliadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoAfiliadoToolStripMenuItem,
            this.modificarAfiliadoToolStripMenuItem,
            this.bajaAfiliadoToolStripMenuItem});
            this.aBMAfiliadoToolStripMenuItem.Name = "aBMAfiliadoToolStripMenuItem";
            this.aBMAfiliadoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.aBMAfiliadoToolStripMenuItem.Text = "ABM &Afiliado";
            // 
            // nuevoAfiliadoToolStripMenuItem
            // 
            this.nuevoAfiliadoToolStripMenuItem.Name = "nuevoAfiliadoToolStripMenuItem";
            this.nuevoAfiliadoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.nuevoAfiliadoToolStripMenuItem.Text = "&Alta Afiliado";
            this.nuevoAfiliadoToolStripMenuItem.Click += new System.EventHandler(this.nuevoAfiliadoToolStripMenuItem_Click);
            // 
            // modificarAfiliadoToolStripMenuItem
            // 
            this.modificarAfiliadoToolStripMenuItem.Name = "modificarAfiliadoToolStripMenuItem";
            this.modificarAfiliadoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.modificarAfiliadoToolStripMenuItem.Text = "&Modificar Afiliado";
            this.modificarAfiliadoToolStripMenuItem.Click += new System.EventHandler(this.modificarAfiliadoToolStripMenuItem_Click);
            // 
            // bajaAfiliadoToolStripMenuItem
            // 
            this.bajaAfiliadoToolStripMenuItem.Name = "bajaAfiliadoToolStripMenuItem";
            this.bajaAfiliadoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.bajaAfiliadoToolStripMenuItem.Text = "&Baja Afiliado";
            this.bajaAfiliadoToolStripMenuItem.Click += new System.EventHandler(this.bajaAfiliadoToolStripMenuItem_Click);
            // 
            // pedirTurnoToolStripMenuItem
            // 
            this.pedirTurnoToolStripMenuItem.Name = "pedirTurnoToolStripMenuItem";
            this.pedirTurnoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.pedirTurnoToolStripMenuItem.Text = "&Pedir Turno";
            this.pedirTurnoToolStripMenuItem.Click += new System.EventHandler(this.pedirTurnoToolStripMenuItem_Click);
            // 
            // cancelarTurnosUsuario_ToolStripMenuItem
            // 
            this.cancelarTurnosUsuario_ToolStripMenuItem.Name = "cancelarTurnosUsuario_ToolStripMenuItem";
            this.cancelarTurnosUsuario_ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cancelarTurnosUsuario_ToolStripMenuItem.Text = "&Cancelar Turnos";
            this.cancelarTurnosUsuario_ToolStripMenuItem.Click += new System.EventHandler(this.cancelarTurnosToolStripMenuItem1_Click);
            // 
            // comprarBonoUsuario_ToolStripMenuItem
            // 
            this.comprarBonoUsuario_ToolStripMenuItem.Name = "comprarBonoUsuario_ToolStripMenuItem";
            this.comprarBonoUsuario_ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.comprarBonoUsuario_ToolStripMenuItem.Text = "Comprar &Bono";
            this.comprarBonoUsuario_ToolStripMenuItem.Click += new System.EventHandler(this.comprarBonoToolStripMenuItem_Click);
            // 
            // profesionalesToolStripMenuItem
            // 
            this.profesionalesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agendaCrearTurnos_ToolStripMenuItem,
            this.cancelarTurnosProfesional_ToolStripMenuItem,
            this.registrarResultadoDiagnosticoToolStripMenuItem});
            this.profesionalesToolStripMenuItem.Name = "profesionalesToolStripMenuItem";
            this.profesionalesToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.profesionalesToolStripMenuItem.Text = "&Profesionales";
            // 
            // agendaCrearTurnos_ToolStripMenuItem
            // 
            this.agendaCrearTurnos_ToolStripMenuItem.Name = "agendaCrearTurnos_ToolStripMenuItem";
            this.agendaCrearTurnos_ToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.agendaCrearTurnos_ToolStripMenuItem.Text = "Crear &Agenda";
            this.agendaCrearTurnos_ToolStripMenuItem.Click += new System.EventHandler(this.agendaToolStripMenuItem_Click);
            // 
            // cancelarTurnosProfesional_ToolStripMenuItem
            // 
            this.cancelarTurnosProfesional_ToolStripMenuItem.Name = "cancelarTurnosProfesional_ToolStripMenuItem";
            this.cancelarTurnosProfesional_ToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.cancelarTurnosProfesional_ToolStripMenuItem.Text = "&Cancelar Turnos";
            this.cancelarTurnosProfesional_ToolStripMenuItem.Click += new System.EventHandler(this.cancelarTurnosToolStripMenuItem_Click);
            // 
            // registrarResultadoDiagnosticoToolStripMenuItem
            // 
            this.registrarResultadoDiagnosticoToolStripMenuItem.Name = "registrarResultadoDiagnosticoToolStripMenuItem";
            this.registrarResultadoDiagnosticoToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.registrarResultadoDiagnosticoToolStripMenuItem.Text = "&Registrar Resultado Diagnostico";
            this.registrarResultadoDiagnosticoToolStripMenuItem.Click += new System.EventHandler(this.registrarResultadoDiagnosticoToolStripMenuItem_Click_1);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rolesToolStripMenuItem,
            this.comprarBonoAdmin_ToolStripMenuItem,
            this.registrarLlegadaAfiliadoToolStripMenuItem,
            this.estadisticasToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.adminToolStripMenuItem.Text = "A&dministrativo";
            // 
            // rolesToolStripMenuItem
            // 
            this.rolesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevRolToolStripMenuItem,
            this.modificarRol_ToolStripMenuItem});
            this.rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            this.rolesToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.rolesToolStripMenuItem.Text = "&Roles";
            // 
            // nuevRolToolStripMenuItem
            // 
            this.nuevRolToolStripMenuItem.Name = "nuevRolToolStripMenuItem";
            this.nuevRolToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.nuevRolToolStripMenuItem.Text = "&Nuevo Rol";
            this.nuevRolToolStripMenuItem.Click += new System.EventHandler(this.nuevRolToolStripMenuItem_Click);
            // 
            // modificarRol_ToolStripMenuItem
            // 
            this.modificarRol_ToolStripMenuItem.Name = "modificarRol_ToolStripMenuItem";
            this.modificarRol_ToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.modificarRol_ToolStripMenuItem.Text = "&Modificar y Dar Baja Roles";
            this.modificarRol_ToolStripMenuItem.Click += new System.EventHandler(this.bajaRolToolStripMenuItem_Click);
            // 
            // comprarBonoAdmin_ToolStripMenuItem
            // 
            this.comprarBonoAdmin_ToolStripMenuItem.Name = "comprarBonoAdmin_ToolStripMenuItem";
            this.comprarBonoAdmin_ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.comprarBonoAdmin_ToolStripMenuItem.Text = "Comprar &Bono Usuario";
            this.comprarBonoAdmin_ToolStripMenuItem.Click += new System.EventHandler(this.comprarBonoUsuarioToolStripMenuItem_Click);
            // 
            // registrarLlegadaAfiliadoToolStripMenuItem
            // 
            this.registrarLlegadaAfiliadoToolStripMenuItem.Name = "registrarLlegadaAfiliadoToolStripMenuItem";
            this.registrarLlegadaAfiliadoToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.registrarLlegadaAfiliadoToolStripMenuItem.Text = "&Registrar Llegada Afiliado";
            this.registrarLlegadaAfiliadoToolStripMenuItem.Click += new System.EventHandler(this.registrarLlegadaAfiliadoToolStripMenuItem_Click);
            // 
            // estadisticasToolStripMenuItem
            // 
            this.estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            this.estadisticasToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.estadisticasToolStripMenuItem.Text = "&Estadisticas";
            this.estadisticasToolStripMenuItem.Click += new System.EventHandler(this.estadisticasToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_usuario.Location = new System.Drawing.Point(149, 108);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(213, 20);
            this.textBox_usuario.TabIndex = 1;
            this.textBox_usuario.Text = "ADMIN";
            this.textBox_usuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_usuario_KeyPress_1);
            // 
            // textBox_password
            // 
            this.textBox_password.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_password.Location = new System.Drawing.Point(149, 154);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(213, 20);
            this.textBox_password.TabIndex = 2;
            this.textBox_password.Text = "W23E";
            this.textBox_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_usuario_KeyPress_1);
            // 
            // label_bienvenido
            // 
            this.label_bienvenido.AutoSize = true;
            this.label_bienvenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bienvenido.Location = new System.Drawing.Point(127, 45);
            this.label_bienvenido.Name = "label_bienvenido";
            this.label_bienvenido.Size = new System.Drawing.Size(270, 25);
            this.label_bienvenido.TabIndex = 4;
            this.label_bienvenido.Text = "Bienvenido a Clinica FRBA";
            this.label_bienvenido.Visible = false;
            // 
            // boton_loguear
            // 
            this.boton_loguear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_loguear.Location = new System.Drawing.Point(382, 111);
            this.boton_loguear.Name = "boton_loguear";
            this.boton_loguear.Size = new System.Drawing.Size(109, 107);
            this.boton_loguear.TabIndex = 4;
            this.boton_loguear.Text = "Loguear";
            this.boton_loguear.UseVisualStyleBackColor = true;
            this.boton_loguear.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Rol a Usar";
            // 
            // comboBox_rol
            // 
            this.comboBox_rol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_rol.FormattingEnabled = true;
            this.comboBox_rol.Location = new System.Drawing.Point(149, 194);
            this.comboBox_rol.Name = "comboBox_rol";
            this.comboBox_rol.Size = new System.Drawing.Size(212, 21);
            this.comboBox_rol.TabIndex = 3;
            // 
            // label_fecha
            // 
            this.label_fecha.AutoSize = true;
            this.label_fecha.Location = new System.Drawing.Point(429, 272);
            this.label_fecha.Name = "label_fecha";
            this.label_fecha.Size = new System.Drawing.Size(62, 13);
            this.label_fecha.TabIndex = 7;
            this.label_fecha.Text = "label_fecha";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 294);
            this.Controls.Add(this.label_fecha);
            this.Controls.Add(this.comboBox_rol);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.boton_loguear);
            this.Controls.Add(this.label_bienvenido);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_usuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clinica FRBA -KFC";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afiliadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profesionalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMAfiliadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoAfiliadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarAfiliadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaAfiliadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agendaCrearTurnos_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarRol_ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.ToolStripMenuItem cancelarTurnosProfesional_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarTurnosUsuario_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedirTurnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprarBonoUsuario_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprarBonoAdmin_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadisticasToolStripMenuItem;
        private System.Windows.Forms.Label label_bienvenido;
        private System.Windows.Forms.Button boton_loguear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_rol;
        private System.Windows.Forms.Label label_fecha;
        private System.Windows.Forms.ToolStripMenuItem registrarResultadoDiagnosticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarLlegadaAfiliadoToolStripMenuItem;
    }
}
