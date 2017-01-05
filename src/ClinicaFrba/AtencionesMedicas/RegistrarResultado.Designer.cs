namespace ClinicaFrba.AtencionesMedicas
{
    partial class RegistrarResultado
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
            this.buscarTurnosButton = new System.Windows.Forms.Button();
            this.apellidoTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_apellido = new System.Windows.Forms.Label();
            this.documentoTextbox = new System.Windows.Forms.TextBox();
            this.nombreTextbox = new System.Windows.Forms.TextBox();
            this.label_Id_Usuario = new System.Windows.Forms.Label();
            this.label_Usuario = new System.Windows.Forms.Label();
            this.groupBox_filtros = new System.Windows.Forms.GroupBox();
            this.turnosDatagrid = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sintomasTextbox = new System.Windows.Forms.TextBox();
            this.diagnosticoTextbox = new System.Windows.Forms.TextBox();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.registrarAtencionButton = new System.Windows.Forms.Button();
            this.limpiarDataGrid = new System.Windows.Forms.Button();
            this.groupBox_filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.turnosDatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // buscarTurnosButton
            // 
            this.buscarTurnosButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarTurnosButton.Location = new System.Drawing.Point(626, 18);
            this.buscarTurnosButton.Name = "buscarTurnosButton";
            this.buscarTurnosButton.Size = new System.Drawing.Size(96, 55);
            this.buscarTurnosButton.TabIndex = 19;
            this.buscarTurnosButton.Text = "Buscar Turnos";
            this.buscarTurnosButton.UseVisualStyleBackColor = true;
            this.buscarTurnosButton.Click += new System.EventHandler(this.button_Buscar_Click);
            // 
            // apellidoTextbox
            // 
            this.apellidoTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.apellidoTextbox.Location = new System.Drawing.Point(299, 23);
            this.apellidoTextbox.Name = "apellidoTextbox";
            this.apellidoTextbox.Size = new System.Drawing.Size(100, 20);
            this.apellidoTextbox.TabIndex = 8;
            this.apellidoTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Nombre_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(428, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Documento";
            // 
            // label_apellido
            // 
            this.label_apellido.AutoSize = true;
            this.label_apellido.Location = new System.Drawing.Point(212, 26);
            this.label_apellido.Name = "label_apellido";
            this.label_apellido.Size = new System.Drawing.Size(81, 13);
            this.label_apellido.TabIndex = 7;
            this.label_apellido.Text = "Apellido Afiliado";
            // 
            // documentoTextbox
            // 
            this.documentoTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.documentoTextbox.Location = new System.Drawing.Point(496, 23);
            this.documentoTextbox.Name = "documentoTextbox";
            this.documentoTextbox.Size = new System.Drawing.Size(100, 20);
            this.documentoTextbox.TabIndex = 9;
            this.documentoTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Documento_KeyPress);
            // 
            // nombreTextbox
            // 
            this.nombreTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nombreTextbox.Location = new System.Drawing.Point(96, 23);
            this.nombreTextbox.Name = "nombreTextbox";
            this.nombreTextbox.Size = new System.Drawing.Size(100, 20);
            this.nombreTextbox.TabIndex = 6;
            this.nombreTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Nombre_KeyPress);
            // 
            // label_Id_Usuario
            // 
            this.label_Id_Usuario.AutoSize = true;
            this.label_Id_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Id_Usuario.Location = new System.Drawing.Point(25, 22);
            this.label_Id_Usuario.Name = "label_Id_Usuario";
            this.label_Id_Usuario.Size = new System.Drawing.Size(0, 18);
            this.label_Id_Usuario.TabIndex = 13;
            // 
            // label_Usuario
            // 
            this.label_Usuario.AutoSize = true;
            this.label_Usuario.Location = new System.Drawing.Point(9, 27);
            this.label_Usuario.Name = "label_Usuario";
            this.label_Usuario.Size = new System.Drawing.Size(81, 13);
            this.label_Usuario.TabIndex = 5;
            this.label_Usuario.Text = "Nombre Afiliado";
            // 
            // groupBox_filtros
            // 
            this.groupBox_filtros.Controls.Add(this.label_Usuario);
            this.groupBox_filtros.Controls.Add(this.label_Id_Usuario);
            this.groupBox_filtros.Controls.Add(this.nombreTextbox);
            this.groupBox_filtros.Controls.Add(this.documentoTextbox);
            this.groupBox_filtros.Controls.Add(this.label_apellido);
            this.groupBox_filtros.Controls.Add(this.label1);
            this.groupBox_filtros.Controls.Add(this.apellidoTextbox);
            this.groupBox_filtros.Location = new System.Drawing.Point(13, 13);
            this.groupBox_filtros.Name = "groupBox_filtros";
            this.groupBox_filtros.Size = new System.Drawing.Size(607, 60);
            this.groupBox_filtros.TabIndex = 20;
            this.groupBox_filtros.TabStop = false;
            this.groupBox_filtros.Text = "Filtros de Busqueda";
            // 
            // turnosDatagrid
            // 
            this.turnosDatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.turnosDatagrid.Location = new System.Drawing.Point(14, 79);
            this.turnosDatagrid.Name = "turnosDatagrid";
            this.turnosDatagrid.Size = new System.Drawing.Size(740, 204);
            this.turnosDatagrid.TabIndex = 21;
            this.turnosDatagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.turnosDatagrid_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "Diagnostico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Sintomas";
            // 
            // sintomasTextbox
            // 
            this.sintomasTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sintomasTextbox.Location = new System.Drawing.Point(109, 304);
            this.sintomasTextbox.Multiline = true;
            this.sintomasTextbox.Name = "sintomasTextbox";
            this.sintomasTextbox.Size = new System.Drawing.Size(627, 50);
            this.sintomasTextbox.TabIndex = 25;
            this.sintomasTextbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.detalleAtencionTextboxValidate);
            // 
            // diagnosticoTextbox
            // 
            this.diagnosticoTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.diagnosticoTextbox.Location = new System.Drawing.Point(109, 360);
            this.diagnosticoTextbox.Multiline = true;
            this.diagnosticoTextbox.Name = "diagnosticoTextbox";
            this.diagnosticoTextbox.Size = new System.Drawing.Size(627, 50);
            this.diagnosticoTextbox.TabIndex = 26;
            this.diagnosticoTextbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.detalleAtencionTextboxValidate);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButton.Location = new System.Drawing.Point(326, 425);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(96, 55);
            this.cancelarButton.TabIndex = 27;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // registrarAtencionButton
            // 
            this.registrarAtencionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrarAtencionButton.Location = new System.Drawing.Point(597, 425);
            this.registrarAtencionButton.Name = "registrarAtencionButton";
            this.registrarAtencionButton.Size = new System.Drawing.Size(139, 55);
            this.registrarAtencionButton.TabIndex = 28;
            this.registrarAtencionButton.Text = "Registrar Atencion";
            this.registrarAtencionButton.UseVisualStyleBackColor = true;
            this.registrarAtencionButton.Click += new System.EventHandler(this.registrarAtencionButton_Click);
            // 
            // limpiarDataGrid
            // 
            this.limpiarDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limpiarDataGrid.Location = new System.Drawing.Point(25, 425);
            this.limpiarDataGrid.Name = "limpiarDataGrid";
            this.limpiarDataGrid.Size = new System.Drawing.Size(96, 55);
            this.limpiarDataGrid.TabIndex = 29;
            this.limpiarDataGrid.Text = "Limpiar";
            this.limpiarDataGrid.UseVisualStyleBackColor = true;
            this.limpiarDataGrid.Click += new System.EventHandler(this.limpiarDataGrid_Click);
            // 
            // RegistrarResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 502);
            this.Controls.Add(this.limpiarDataGrid);
            this.Controls.Add(this.registrarAtencionButton);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.diagnosticoTextbox);
            this.Controls.Add(this.sintomasTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.turnosDatagrid);
            this.Controls.Add(this.groupBox_filtros);
            this.Controls.Add(this.buscarTurnosButton);
            this.Name = "RegistrarResultado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Atencion";
            this.Load += new System.EventHandler(this.RegistrarResultado_Load);
            this.groupBox_filtros.ResumeLayout(false);
            this.groupBox_filtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.turnosDatagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buscarTurnosButton;
        private System.Windows.Forms.TextBox apellidoTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_apellido;
        private System.Windows.Forms.TextBox documentoTextbox;
        private System.Windows.Forms.TextBox nombreTextbox;
        private System.Windows.Forms.Label label_Id_Usuario;
        private System.Windows.Forms.Label label_Usuario;
        private System.Windows.Forms.GroupBox groupBox_filtros;
        private System.Windows.Forms.DataGridView turnosDatagrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sintomasTextbox;
        private System.Windows.Forms.TextBox diagnosticoTextbox;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button registrarAtencionButton;
        private System.Windows.Forms.Button limpiarDataGrid;
    }
}