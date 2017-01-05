namespace ClinicaFrba.AtencionesMedicas
{
    partial class RegistrarLlegada
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboEspecialidades = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_profesional_apellido = new System.Windows.Forms.TextBox();
            this.textBox_afiliado_apellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_afiliado_apellido = new System.Windows.Forms.Label();
            this.textBox_profesional_nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_afiliado_nombre = new System.Windows.Forms.TextBox();
            this.label_afiliado_nombre = new System.Windows.Forms.Label();
            this.button_Registrar = new System.Windows.Forms.Button();
            this.combo_Bono = new System.Windows.Forms.ComboBox();
            this.dataGridView_resultados_filtros = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.label_Afiliado = new System.Windows.Forms.Label();
            this.label_profesional = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados_filtros)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccionar Especialidad:";
            // 
            // comboEspecialidades
            // 
            this.comboEspecialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEspecialidades.FormattingEnabled = true;
            this.comboEspecialidades.Location = new System.Drawing.Point(573, 55);
            this.comboEspecialidades.Name = "comboEspecialidades";
            this.comboEspecialidades.Size = new System.Drawing.Size(223, 21);
            this.comboEspecialidades.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(752, 449);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "Bonos:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(18, 433);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(106, 62);
            this.btnLimpiar.TabIndex = 18;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(841, 36);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(85, 47);
            this.btnBuscar.TabIndex = 19;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_profesional_apellido);
            this.groupBox1.Controls.Add(this.textBox_afiliado_apellido);
            this.groupBox1.Controls.Add(this.comboEspecialidades);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label_afiliado_apellido);
            this.groupBox1.Controls.Add(this.textBox_profesional_nombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_afiliado_nombre);
            this.groupBox1.Controls.Add(this.label_afiliado_nombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(823, 89);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // textBox_profesional_apellido
            // 
            this.textBox_profesional_apellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_profesional_apellido.Location = new System.Drawing.Point(638, 27);
            this.textBox_profesional_apellido.Name = "textBox_profesional_apellido";
            this.textBox_profesional_apellido.Size = new System.Drawing.Size(158, 20);
            this.textBox_profesional_apellido.TabIndex = 31;
            this.textBox_profesional_apellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_profesional_apellido_KeyPress);
            // 
            // textBox_afiliado_apellido
            // 
            this.textBox_afiliado_apellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_afiliado_apellido.Location = new System.Drawing.Point(103, 52);
            this.textBox_afiliado_apellido.Name = "textBox_afiliado_apellido";
            this.textBox_afiliado_apellido.Size = new System.Drawing.Size(140, 20);
            this.textBox_afiliado_apellido.TabIndex = 31;
            this.textBox_afiliado_apellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_profesional_apellido_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(563, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Apellido Prof.";
            // 
            // label_afiliado_apellido
            // 
            this.label_afiliado_apellido.AutoSize = true;
            this.label_afiliado_apellido.Location = new System.Drawing.Point(10, 55);
            this.label_afiliado_apellido.Name = "label_afiliado_apellido";
            this.label_afiliado_apellido.Size = new System.Drawing.Size(81, 13);
            this.label_afiliado_apellido.TabIndex = 30;
            this.label_afiliado_apellido.Text = "Apellido Afiliado";
            // 
            // textBox_profesional_nombre
            // 
            this.textBox_profesional_nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_profesional_nombre.Location = new System.Drawing.Point(340, 28);
            this.textBox_profesional_nombre.Name = "textBox_profesional_nombre";
            this.textBox_profesional_nombre.Size = new System.Drawing.Size(183, 20);
            this.textBox_profesional_nombre.TabIndex = 31;
            this.textBox_profesional_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_profesional_apellido_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nombre Prof.";
            // 
            // textBox_afiliado_nombre
            // 
            this.textBox_afiliado_nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_afiliado_nombre.Location = new System.Drawing.Point(103, 24);
            this.textBox_afiliado_nombre.Name = "textBox_afiliado_nombre";
            this.textBox_afiliado_nombre.Size = new System.Drawing.Size(140, 20);
            this.textBox_afiliado_nombre.TabIndex = 31;
            this.textBox_afiliado_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_profesional_apellido_KeyPress);
            // 
            // label_afiliado_nombre
            // 
            this.label_afiliado_nombre.AutoSize = true;
            this.label_afiliado_nombre.Location = new System.Drawing.Point(10, 27);
            this.label_afiliado_nombre.Name = "label_afiliado_nombre";
            this.label_afiliado_nombre.Size = new System.Drawing.Size(81, 13);
            this.label_afiliado_nombre.TabIndex = 30;
            this.label_afiliado_nombre.Text = "Nombre Afiliado";
            // 
            // button_Registrar
            // 
            this.button_Registrar.Enabled = false;
            this.button_Registrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Registrar.Location = new System.Drawing.Point(907, 423);
            this.button_Registrar.Name = "button_Registrar";
            this.button_Registrar.Size = new System.Drawing.Size(124, 67);
            this.button_Registrar.TabIndex = 24;
            this.button_Registrar.Text = "REGISTRAR LLEGADA";
            this.button_Registrar.UseVisualStyleBackColor = true;
            this.button_Registrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // combo_Bono
            // 
            this.combo_Bono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Bono.Enabled = false;
            this.combo_Bono.FormattingEnabled = true;
            this.combo_Bono.Location = new System.Drawing.Point(700, 472);
            this.combo_Bono.Name = "combo_Bono";
            this.combo_Bono.Size = new System.Drawing.Size(194, 21);
            this.combo_Bono.TabIndex = 25;
            this.combo_Bono.SelectedIndexChanged += new System.EventHandler(this.combo_Bono_SelectedIndexChanged);
            // 
            // dataGridView_resultados_filtros
            // 
            this.dataGridView_resultados_filtros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_resultados_filtros.Location = new System.Drawing.Point(2, 140);
            this.dataGridView_resultados_filtros.Name = "dataGridView_resultados_filtros";
            this.dataGridView_resultados_filtros.Size = new System.Drawing.Size(1034, 269);
            this.dataGridView_resultados_filtros.TabIndex = 30;
            this.dataGridView_resultados_filtros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_resultados_filtros_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(401, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Turnos Encontrados";
            // 
            // button_cancelar
            // 
            this.button_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancelar.Location = new System.Drawing.Point(361, 433);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(121, 62);
            this.button_cancelar.TabIndex = 31;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // label_Afiliado
            // 
            this.label_Afiliado.AutoSize = true;
            this.label_Afiliado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Afiliado.Location = new System.Drawing.Point(530, 475);
            this.label_Afiliado.Name = "label_Afiliado";
            this.label_Afiliado.Size = new System.Drawing.Size(0, 15);
            this.label_Afiliado.TabIndex = 32;
            // 
            // label_profesional
            // 
            this.label_profesional.AutoSize = true;
            this.label_profesional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_profesional.Location = new System.Drawing.Point(530, 428);
            this.label_profesional.Name = "label_profesional";
            this.label_profesional.Size = new System.Drawing.Size(0, 15);
            this.label_profesional.TabIndex = 32;
            // 
            // RegistrarLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 510);
            this.Controls.Add(this.label_profesional);
            this.Controls.Add(this.label_Afiliado);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.dataGridView_resultados_filtros);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combo_Bono);
            this.Controls.Add(this.button_Registrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label7);
            this.Name = "RegistrarLlegada";
            this.Text = "Registrar Llegada";
            this.Load += new System.EventHandler(this.RegistrarAtencion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados_filtros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboEspecialidades;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Button button_Registrar;
        private System.Windows.Forms.ComboBox combo_Bono;
        private System.Windows.Forms.TextBox textBox_afiliado_apellido;
        private System.Windows.Forms.Label label_afiliado_apellido;
        private System.Windows.Forms.TextBox textBox_afiliado_nombre;
        private System.Windows.Forms.Label label_afiliado_nombre;
        private System.Windows.Forms.DataGridView dataGridView_resultados_filtros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Label label_Afiliado;
        private System.Windows.Forms.TextBox textBox_profesional_apellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_profesional_nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_profesional;
    }
}