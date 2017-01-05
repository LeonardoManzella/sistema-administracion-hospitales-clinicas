namespace ClinicaFrba.Estadisticas
{
    partial class Estadisticas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbHasta = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDesde = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbQuienCancela = new System.Windows.Forms.ComboBox();
            this.lblCance = new System.Windows.Forms.Label();
            this.comboSemestre = new System.Windows.Forms.ComboBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboEspec = new System.Windows.Forms.ComboBox();
            this.comboTop5 = new System.Windows.Forms.ComboBox();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblPlan = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.dataGridEstadistico = new System.Windows.Forms.DataGridView();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfApe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AfdoNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AfdoApe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AfdoGpoFliar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEstadistico)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbHasta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbDesde);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbQuienCancela);
            this.groupBox1.Controls.Add(this.lblCance);
            this.groupBox1.Controls.Add(this.comboSemestre);
            this.groupBox1.Controls.Add(this.txtAnio);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.comboEspec);
            this.groupBox1.Controls.Add(this.comboTop5);
            this.groupBox1.Controls.Add(this.lblSemestre);
            this.groupBox1.Controls.Add(this.lblYear);
            this.groupBox1.Controls.Add(this.lblPlan);
            this.groupBox1.Controls.Add(this.lblEspecialidad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 179);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Busqueda";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Mes:";
            // 
            // cmbHasta
            // 
            this.cmbHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHasta.FormattingEnabled = true;
            this.cmbHasta.Location = new System.Drawing.Point(429, 152);
            this.cmbHasta.Name = "cmbHasta";
            this.cmbHasta.Size = new System.Drawing.Size(54, 21);
            this.cmbHasta.TabIndex = 16;
            this.cmbHasta.SelectedIndexChanged += new System.EventHandler(this.cmbHasta_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Hasta:";
            // 
            // cmbDesde
            // 
            this.cmbDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDesde.FormattingEnabled = true;
            this.cmbDesde.Location = new System.Drawing.Point(312, 152);
            this.cmbDesde.Name = "cmbDesde";
            this.cmbDesde.Size = new System.Drawing.Size(54, 21);
            this.cmbDesde.TabIndex = 14;
            this.cmbDesde.SelectedIndexChanged += new System.EventHandler(this.cmbDesde_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Desde:";
            // 
            // cmbQuienCancela
            // 
            this.cmbQuienCancela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuienCancela.FormattingEnabled = true;
            this.cmbQuienCancela.Location = new System.Drawing.Point(94, 67);
            this.cmbQuienCancela.Name = "cmbQuienCancela";
            this.cmbQuienCancela.Size = new System.Drawing.Size(172, 21);
            this.cmbQuienCancela.TabIndex = 12;
            this.cmbQuienCancela.SelectedIndexChanged += new System.EventHandler(this.cmbQuienCancela_SelectedIndexChanged);
            // 
            // lblCance
            // 
            this.lblCance.AutoSize = true;
            this.lblCance.Location = new System.Drawing.Point(8, 71);
            this.lblCance.Name = "lblCance";
            this.lblCance.Size = new System.Drawing.Size(80, 13);
            this.lblCance.TabIndex = 11;
            this.lblCance.Text = "Cancelado Por:";
            // 
            // comboSemestre
            // 
            this.comboSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSemestre.FormattingEnabled = true;
            this.comboSemestre.Location = new System.Drawing.Point(349, 107);
            this.comboSemestre.Name = "comboSemestre";
            this.comboSemestre.Size = new System.Drawing.Size(121, 21);
            this.comboSemestre.TabIndex = 10;
            this.comboSemestre.SelectedIndexChanged += new System.EventHandler(this.comboSemestre_SelectedIndexChanged);
            // 
            // txtAnio
            // 
            this.txtAnio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtAnio.Location = new System.Drawing.Point(349, 68);
            this.txtAnio.MaxLength = 4;
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAnio.Size = new System.Drawing.Size(121, 20);
            this.txtAnio.TabIndex = 9;
            this.txtAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnio_KeyPress);
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(94, 106);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(172, 21);
            this.comboBox3.TabIndex = 8;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboEspec
            // 
            this.comboEspec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEspec.FormattingEnabled = true;
            this.comboEspec.Location = new System.Drawing.Point(94, 66);
            this.comboEspec.Name = "comboEspec";
            this.comboEspec.Size = new System.Drawing.Size(172, 21);
            this.comboEspec.TabIndex = 7;
            this.comboEspec.SelectedIndexChanged += new System.EventHandler(this.comboEspec_SelectedIndexChanged);
            // 
            // comboTop5
            // 
            this.comboTop5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTop5.FormattingEnabled = true;
            this.comboTop5.Location = new System.Drawing.Point(94, 29);
            this.comboTop5.Name = "comboTop5";
            this.comboTop5.Size = new System.Drawing.Size(376, 21);
            this.comboTop5.TabIndex = 6;
            this.comboTop5.SelectedIndexChanged += new System.EventHandler(this.comboTop5_SelectedIndexChanged);
            // 
            // lblSemestre
            // 
            this.lblSemestre.AutoSize = true;
            this.lblSemestre.Location = new System.Drawing.Point(284, 110);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(54, 13);
            this.lblSemestre.TabIndex = 4;
            this.lblSemestre.Text = "Semestre:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(304, 74);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "Año:";
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(11, 110);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(31, 13);
            this.lblPlan.TabIndex = 2;
            this.lblPlan.Text = "Plan:";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(11, 70);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(73, 13);
            this.lblEspecialidad.TabIndex = 1;
            this.lblEspecialidad.Text = "Especialidad: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TOP 5:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 207);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(88, 45);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjecutar.Location = new System.Drawing.Point(393, 207);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(102, 45);
            this.btnEjecutar.TabIndex = 2;
            this.btnEjecutar.Text = "Ver Estadistica";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // dataGridEstadistico
            // 
            this.dataGridEstadistico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEstadistico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cantidad,
            this.Especialidad,
            this.ProfNom,
            this.ProfApe,
            this.AfdoNom,
            this.AfdoApe,
            this.AfdoGpoFliar});
            this.dataGridEstadistico.Location = new System.Drawing.Point(7, 258);
            this.dataGridEstadistico.Name = "dataGridEstadistico";
            this.dataGridEstadistico.Size = new System.Drawing.Size(499, 223);
            this.dataGridEstadistico.TabIndex = 4;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cant. (Desc.)";
            this.Cantidad.Name = "Cantidad";
            // 
            // Especialidad
            // 
            this.Especialidad.HeaderText = "Especialidad";
            this.Especialidad.Name = "Especialidad";
            // 
            // ProfNom
            // 
            this.ProfNom.HeaderText = "Prof. Nom.";
            this.ProfNom.Name = "ProfNom";
            // 
            // ProfApe
            // 
            this.ProfApe.HeaderText = "Prof. Apellido";
            this.ProfApe.Name = "ProfApe";
            // 
            // AfdoNom
            // 
            this.AfdoNom.HeaderText = "Afildo. Nom.";
            this.AfdoNom.Name = "AfdoNom";
            // 
            // AfdoApe
            // 
            this.AfdoApe.HeaderText = "Afild. Apellido";
            this.AfdoApe.Name = "AfdoApe";
            // 
            // AfdoGpoFliar
            // 
            this.AfdoGpoFliar.HeaderText = "Afild. Gpo. Fliar.";
            this.AfdoGpoFliar.Name = "AfdoGpoFliar";
            this.AfdoGpoFliar.Width = 104;
            // 
            // Estadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 486);
            this.Controls.Add(this.dataGridEstadistico);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Name = "Estadisticas";
            this.Text = "Listado Estadistico";
            this.Load += new System.EventHandler(this.Estadisticas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEstadistico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboSemestre;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboEspec;
        private System.Windows.Forms.ComboBox comboTop5;
        private System.Windows.Forms.Label lblSemestre;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.DataGridView dataGridEstadistico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Especialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfApe;
        private System.Windows.Forms.DataGridViewTextBoxColumn AfdoNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn AfdoApe;
        private System.Windows.Forms.DataGridViewTextBoxColumn AfdoGpoFliar;
        private System.Windows.Forms.ComboBox cmbQuienCancela;
        private System.Windows.Forms.Label lblCance;
        private System.Windows.Forms.ComboBox cmbHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}