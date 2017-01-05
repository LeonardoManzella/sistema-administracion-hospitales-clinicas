namespace ClinicaFrba.Compra_Bono
{
    partial class CompraBonoAdmin
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
            this.label_plan = new System.Windows.Forms.Label();
            this.textBox_Plan = new System.Windows.Forms.TextBox();
            this.textBox_Cantidad = new System.Windows.Forms.TextBox();
            this.label_Cantidad = new System.Windows.Forms.Label();
            this.button_Comprar = new System.Windows.Forms.Button();
            this.label_Usuario = new System.Windows.Forms.Label();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.textBox_Apellido = new System.Windows.Forms.TextBox();
            this.label_apellido = new System.Windows.Forms.Label();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.textBox_precio = new System.Windows.Forms.TextBox();
            this.label_precio = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label_Id_Usuario = new System.Windows.Forms.Label();
            this.textBox_Documento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_filtros = new System.Windows.Forms.GroupBox();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.groupBox_plan = new System.Windows.Forms.GroupBox();
            this.dataGridView_resultados_filtros = new System.Windows.Forms.DataGridView();
            this.label_afiliados = new System.Windows.Forms.Label();
            this.groupBox_filtros.SuspendLayout();
            this.groupBox_plan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados_filtros)).BeginInit();
            this.SuspendLayout();
            // 
            // label_plan
            // 
            this.label_plan.AutoSize = true;
            this.label_plan.Location = new System.Drawing.Point(6, 32);
            this.label_plan.Name = "label_plan";
            this.label_plan.Size = new System.Drawing.Size(68, 13);
            this.label_plan.TabIndex = 0;
            this.label_plan.Text = "Nombre Plan";
            // 
            // textBox_Plan
            // 
            this.textBox_Plan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_Plan.Enabled = false;
            this.textBox_Plan.Location = new System.Drawing.Point(88, 29);
            this.textBox_Plan.Name = "textBox_Plan";
            this.textBox_Plan.ReadOnly = true;
            this.textBox_Plan.Size = new System.Drawing.Size(187, 20);
            this.textBox_Plan.TabIndex = 1;
            this.textBox_Plan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Nombre_KeyPress);
            // 
            // textBox_Cantidad
            // 
            this.textBox_Cantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_Cantidad.Location = new System.Drawing.Point(572, 29);
            this.textBox_Cantidad.Name = "textBox_Cantidad";
            this.textBox_Cantidad.Size = new System.Drawing.Size(148, 20);
            this.textBox_Cantidad.TabIndex = 6;
            this.textBox_Cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Cantidad_KeyPress);
            // 
            // label_Cantidad
            // 
            this.label_Cantidad.AutoSize = true;
            this.label_Cantidad.Location = new System.Drawing.Point(517, 32);
            this.label_Cantidad.Name = "label_Cantidad";
            this.label_Cantidad.Size = new System.Drawing.Size(49, 13);
            this.label_Cantidad.TabIndex = 2;
            this.label_Cantidad.Text = "Cantidad";
            // 
            // button_Comprar
            // 
            this.button_Comprar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Comprar.Location = new System.Drawing.Point(625, 376);
            this.button_Comprar.Name = "button_Comprar";
            this.button_Comprar.Size = new System.Drawing.Size(107, 61);
            this.button_Comprar.TabIndex = 7;
            this.button_Comprar.Text = "Comprar Bonos";
            this.button_Comprar.UseVisualStyleBackColor = true;
            this.button_Comprar.Click += new System.EventHandler(this.button_Comprar_Click);
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
            // textBox_Nombre
            // 
            this.textBox_Nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_Nombre.Location = new System.Drawing.Point(96, 23);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(100, 20);
            this.textBox_Nombre.TabIndex = 1;
            this.textBox_Nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Nombre_KeyPress);
            // 
            // textBox_Apellido
            // 
            this.textBox_Apellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_Apellido.Location = new System.Drawing.Point(299, 23);
            this.textBox_Apellido.Name = "textBox_Apellido";
            this.textBox_Apellido.Size = new System.Drawing.Size(100, 20);
            this.textBox_Apellido.TabIndex = 2;
            this.textBox_Apellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Nombre_KeyPress);
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
            // button_Buscar
            // 
            this.button_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Buscar.Location = new System.Drawing.Point(625, 17);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(96, 55);
            this.button_Buscar.TabIndex = 4;
            this.button_Buscar.Text = "Buscar Afiliado";
            this.button_Buscar.UseVisualStyleBackColor = true;
            this.button_Buscar.Click += new System.EventHandler(this.button_Buscar_Click);
            // 
            // textBox_precio
            // 
            this.textBox_precio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_precio.Enabled = false;
            this.textBox_precio.Location = new System.Drawing.Point(356, 29);
            this.textBox_precio.Name = "textBox_precio";
            this.textBox_precio.ReadOnly = true;
            this.textBox_precio.Size = new System.Drawing.Size(148, 20);
            this.textBox_precio.TabIndex = 11;
            // 
            // label_precio
            // 
            this.label_precio.AutoSize = true;
            this.label_precio.Location = new System.Drawing.Point(281, 32);
            this.label_precio.Name = "label_precio";
            this.label_precio.Size = new System.Drawing.Size(61, 13);
            this.label_precio.TabIndex = 10;
            this.label_precio.Text = "Precio Plan";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(338, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 60);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_Id_Usuario
            // 
            this.label_Id_Usuario.AutoSize = true;
            this.label_Id_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Id_Usuario.Location = new System.Drawing.Point(282, 52);
            this.label_Id_Usuario.Name = "label_Id_Usuario";
            this.label_Id_Usuario.Size = new System.Drawing.Size(129, 18);
            this.label_Id_Usuario.TabIndex = 13;
            this.label_Id_Usuario.Text = "labe_ID_usuario";
            // 
            // textBox_Documento
            // 
            this.textBox_Documento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_Documento.Location = new System.Drawing.Point(496, 23);
            this.textBox_Documento.Name = "textBox_Documento";
            this.textBox_Documento.Size = new System.Drawing.Size(100, 20);
            this.textBox_Documento.TabIndex = 3;
            this.textBox_Documento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Documento_KeyPress);
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
            // groupBox_filtros
            // 
            this.groupBox_filtros.Controls.Add(this.label_Usuario);
            this.groupBox_filtros.Controls.Add(this.textBox_Nombre);
            this.groupBox_filtros.Controls.Add(this.textBox_Documento);
            this.groupBox_filtros.Controls.Add(this.label_apellido);
            this.groupBox_filtros.Controls.Add(this.label1);
            this.groupBox_filtros.Controls.Add(this.textBox_Apellido);
            this.groupBox_filtros.Location = new System.Drawing.Point(12, 12);
            this.groupBox_filtros.Name = "groupBox_filtros";
            this.groupBox_filtros.Size = new System.Drawing.Size(607, 60);
            this.groupBox_filtros.TabIndex = 14;
            this.groupBox_filtros.TabStop = false;
            this.groupBox_filtros.Text = "Filtros de Busqueda";
            // 
            // button_limpiar
            // 
            this.button_limpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_limpiar.Location = new System.Drawing.Point(24, 376);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(99, 58);
            this.button_limpiar.TabIndex = 9;
            this.button_limpiar.Text = "Limpiar Filtros";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // groupBox_plan
            // 
            this.groupBox_plan.Controls.Add(this.label_plan);
            this.groupBox_plan.Controls.Add(this.label_Id_Usuario);
            this.groupBox_plan.Controls.Add(this.textBox_Plan);
            this.groupBox_plan.Controls.Add(this.label_Cantidad);
            this.groupBox_plan.Controls.Add(this.textBox_Cantidad);
            this.groupBox_plan.Controls.Add(this.textBox_precio);
            this.groupBox_plan.Controls.Add(this.label_precio);
            this.groupBox_plan.Location = new System.Drawing.Point(12, 295);
            this.groupBox_plan.Name = "groupBox_plan";
            this.groupBox_plan.Size = new System.Drawing.Size(741, 74);
            this.groupBox_plan.TabIndex = 16;
            this.groupBox_plan.TabStop = false;
            this.groupBox_plan.Text = "Plan Seleccionado";
            // 
            // dataGridView_resultados_filtros
            // 
            this.dataGridView_resultados_filtros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_resultados_filtros.Location = new System.Drawing.Point(13, 108);
            this.dataGridView_resultados_filtros.Name = "dataGridView_resultados_filtros";
            this.dataGridView_resultados_filtros.Size = new System.Drawing.Size(740, 181);
            this.dataGridView_resultados_filtros.TabIndex = 5;
            this.dataGridView_resultados_filtros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_resultados_filtros_CellContentClick);
            // 
            // label_afiliados
            // 
            this.label_afiliados.AutoSize = true;
            this.label_afiliados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_afiliados.Location = new System.Drawing.Point(288, 83);
            this.label_afiliados.Name = "label_afiliados";
            this.label_afiliados.Size = new System.Drawing.Size(78, 20);
            this.label_afiliados.TabIndex = 18;
            this.label_afiliados.Text = "Afiliados";
            // 
            // CompraBonoAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 446);
            this.Controls.Add(this.label_afiliados);
            this.Controls.Add(this.dataGridView_resultados_filtros);
            this.Controls.Add(this.groupBox_plan);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.groupBox_filtros);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_Buscar);
            this.Controls.Add(this.button_Comprar);
            this.Name = "CompraBonoAdmin";
            this.Text = "Comprar Bonos";
            this.Load += new System.EventHandler(this.CompraBono_Load);
            this.groupBox_filtros.ResumeLayout(false);
            this.groupBox_filtros.PerformLayout();
            this.groupBox_plan.ResumeLayout(false);
            this.groupBox_plan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados_filtros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_plan;
        private System.Windows.Forms.TextBox textBox_Plan;
        private System.Windows.Forms.TextBox textBox_Cantidad;
        private System.Windows.Forms.Label label_Cantidad;
        private System.Windows.Forms.Button button_Comprar;
        private System.Windows.Forms.Label label_Usuario;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.TextBox textBox_Apellido;
        private System.Windows.Forms.Label label_apellido;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.TextBox textBox_precio;
        private System.Windows.Forms.Label label_precio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_Id_Usuario;
        private System.Windows.Forms.TextBox textBox_Documento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_filtros;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.GroupBox groupBox_plan;
        private System.Windows.Forms.DataGridView dataGridView_resultados_filtros;
        private System.Windows.Forms.Label label_afiliados;
    }
}