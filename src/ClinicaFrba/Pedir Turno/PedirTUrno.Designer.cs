namespace ClinicaFrba.Pedir_Turno
{
    partial class PedirTurno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboEspecialidades = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.boton_salir = new System.Windows.Forms.Button();
            this.button_horarios = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.groupBox_filtros = new System.Windows.Forms.GroupBox();
            this.button_fecha = new System.Windows.Forms.Button();
            this.textBox_fecha = new System.Windows.Forms.TextBox();
            this.textBox_apellido = new System.Windows.Forms.TextBox();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView_resultados_filtros = new System.Windows.Forms.DataGridView();
            this.label_cargando = new System.Windows.Forms.Label();
            this.groupBox_filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados_filtros)).BeginInit();
            this.SuspendLayout();
            // 
            // comboEspecialidades
            // 
            this.comboEspecialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEspecialidades.FormattingEnabled = true;
            this.comboEspecialidades.Location = new System.Drawing.Point(409, 25);
            this.comboEspecialidades.Name = "comboEspecialidades";
            this.comboEspecialidades.Size = new System.Drawing.Size(182, 21);
            this.comboEspecialidades.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccionar Especialidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Elegir Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(216, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Turnos Disponibles";
            // 
            // boton_salir
            // 
            this.boton_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_salir.Location = new System.Drawing.Point(406, 387);
            this.boton_salir.Name = "boton_salir";
            this.boton_salir.Size = new System.Drawing.Size(103, 40);
            this.boton_salir.TabIndex = 7;
            this.boton_salir.Text = "Cancelar";
            this.boton_salir.UseVisualStyleBackColor = true;
            this.boton_salir.Click += new System.EventHandler(this.boton_salir_Click);
            // 
            // button_horarios
            // 
            this.button_horarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_horarios.Location = new System.Drawing.Point(597, 25);
            this.button_horarios.Name = "button_horarios";
            this.button_horarios.Size = new System.Drawing.Size(82, 62);
            this.button_horarios.TabIndex = 4;
            this.button_horarios.Text = "Buscar Turnos";
            this.button_horarios.UseVisualStyleBackColor = true;
            this.button_horarios.Click += new System.EventHandler(this.button_horarios_Click);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_limpiar.Location = new System.Drawing.Point(171, 387);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(103, 40);
            this.button_limpiar.TabIndex = 14;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // groupBox_filtros
            // 
            this.groupBox_filtros.Controls.Add(this.button_fecha);
            this.groupBox_filtros.Controls.Add(this.textBox_fecha);
            this.groupBox_filtros.Controls.Add(this.textBox_apellido);
            this.groupBox_filtros.Controls.Add(this.textBox_nombre);
            this.groupBox_filtros.Controls.Add(this.label6);
            this.groupBox_filtros.Controls.Add(this.button_horarios);
            this.groupBox_filtros.Controls.Add(this.label5);
            this.groupBox_filtros.Controls.Add(this.label1);
            this.groupBox_filtros.Controls.Add(this.label3);
            this.groupBox_filtros.Controls.Add(this.comboEspecialidades);
            this.groupBox_filtros.Location = new System.Drawing.Point(12, 12);
            this.groupBox_filtros.Name = "groupBox_filtros";
            this.groupBox_filtros.Size = new System.Drawing.Size(685, 100);
            this.groupBox_filtros.TabIndex = 15;
            this.groupBox_filtros.TabStop = false;
            this.groupBox_filtros.Text = "Filtros de Busqueda";
            // 
            // button_fecha
            // 
            this.button_fecha.Location = new System.Drawing.Point(479, 62);
            this.button_fecha.Name = "button_fecha";
            this.button_fecha.Size = new System.Drawing.Size(112, 23);
            this.button_fecha.TabIndex = 12;
            this.button_fecha.Text = "Seleccionar";
            this.button_fecha.UseVisualStyleBackColor = true;
            this.button_fecha.Click += new System.EventHandler(this.button_fecha_Click);
            // 
            // textBox_fecha
            // 
            this.textBox_fecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_fecha.Enabled = false;
            this.textBox_fecha.Location = new System.Drawing.Point(342, 63);
            this.textBox_fecha.Name = "textBox_fecha";
            this.textBox_fecha.ReadOnly = true;
            this.textBox_fecha.Size = new System.Drawing.Size(131, 20);
            this.textBox_fecha.TabIndex = 11;
            // 
            // textBox_apellido
            // 
            this.textBox_apellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_apellido.Location = new System.Drawing.Point(120, 61);
            this.textBox_apellido.Name = "textBox_apellido";
            this.textBox_apellido.Size = new System.Drawing.Size(142, 20);
            this.textBox_apellido.TabIndex = 10;
            this.textBox_apellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_apellido_KeyPress);
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_nombre.Location = new System.Drawing.Point(120, 26);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(142, 20);
            this.textBox_nombre.TabIndex = 9;
            this.textBox_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_apellido_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Apellido Profesional";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nombre Profesional";
            // 
            // dataGridView_resultados_filtros
            // 
            this.dataGridView_resultados_filtros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_resultados_filtros.Location = new System.Drawing.Point(12, 155);
            this.dataGridView_resultados_filtros.Name = "dataGridView_resultados_filtros";
            this.dataGridView_resultados_filtros.Size = new System.Drawing.Size(685, 216);
            this.dataGridView_resultados_filtros.TabIndex = 16;
            this.dataGridView_resultados_filtros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_resultados_filtros_CellContentClick);
            // 
            // label_cargando
            // 
            this.label_cargando.AutoSize = true;
            this.label_cargando.ForeColor = System.Drawing.Color.DarkRed;
            this.label_cargando.Location = new System.Drawing.Point(437, 133);
            this.label_cargando.Name = "label_cargando";
            this.label_cargando.Size = new System.Drawing.Size(102, 13);
            this.label_cargando.TabIndex = 17;
            this.label_cargando.Text = "...Leyendo Turnos...";
            this.label_cargando.Visible = false;
            // 
            // PedirTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 439);
            this.Controls.Add(this.label_cargando);
            this.Controls.Add(this.dataGridView_resultados_filtros);
            this.Controls.Add(this.groupBox_filtros);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.boton_salir);
            this.Controls.Add(this.label4);
            this.Name = "PedirTurno";
            this.Text = "Pedir Turnos";
            this.Load += new System.EventHandler(this.PedirTurno_Load);
            this.groupBox_filtros.ResumeLayout(false);
            this.groupBox_filtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados_filtros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboEspecialidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button boton_salir;
        private System.Windows.Forms.Button button_horarios;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.GroupBox groupBox_filtros;
        private System.Windows.Forms.DataGridView dataGridView_resultados_filtros;
        private System.Windows.Forms.TextBox textBox_apellido;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_cargando;
        private System.Windows.Forms.Button button_fecha;
        private System.Windows.Forms.TextBox textBox_fecha;
    }
}