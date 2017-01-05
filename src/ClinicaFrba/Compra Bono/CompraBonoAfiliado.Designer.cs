namespace ClinicaFrba.Compra_Bono
{
    partial class CompraBonoAfiliado
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
            this.textBox_precio = new System.Windows.Forms.TextBox();
            this.label_precio = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label_Id_Usuario = new System.Windows.Forms.Label();
            this.groupBox_plan = new System.Windows.Forms.GroupBox();
            this.groupBox_plan.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_plan
            // 
            this.label_plan.AutoSize = true;
            this.label_plan.Location = new System.Drawing.Point(6, 25);
            this.label_plan.Name = "label_plan";
            this.label_plan.Size = new System.Drawing.Size(68, 13);
            this.label_plan.TabIndex = 0;
            this.label_plan.Text = "Nombre Plan";
            // 
            // textBox_Plan
            // 
            this.textBox_Plan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_Plan.Enabled = false;
            this.textBox_Plan.Location = new System.Drawing.Point(88, 22);
            this.textBox_Plan.Name = "textBox_Plan";
            this.textBox_Plan.ReadOnly = true;
            this.textBox_Plan.Size = new System.Drawing.Size(177, 20);
            this.textBox_Plan.TabIndex = 1;
            // 
            // textBox_Cantidad
            // 
            this.textBox_Cantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_Cantidad.Location = new System.Drawing.Point(88, 87);
            this.textBox_Cantidad.Name = "textBox_Cantidad";
            this.textBox_Cantidad.Size = new System.Drawing.Size(177, 20);
            this.textBox_Cantidad.TabIndex = 11;
            this.textBox_Cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Cantidad_KeyPress);
            // 
            // label_Cantidad
            // 
            this.label_Cantidad.AutoSize = true;
            this.label_Cantidad.Location = new System.Drawing.Point(25, 87);
            this.label_Cantidad.Name = "label_Cantidad";
            this.label_Cantidad.Size = new System.Drawing.Size(49, 13);
            this.label_Cantidad.TabIndex = 2;
            this.label_Cantidad.Text = "Cantidad";
            // 
            // button_Comprar
            // 
            this.button_Comprar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Comprar.Location = new System.Drawing.Point(230, 137);
            this.button_Comprar.Name = "button_Comprar";
            this.button_Comprar.Size = new System.Drawing.Size(81, 45);
            this.button_Comprar.TabIndex = 12;
            this.button_Comprar.Text = "Comprar Bonos";
            this.button_Comprar.UseVisualStyleBackColor = true;
            this.button_Comprar.Click += new System.EventHandler(this.button_Comprar_Click);
            // 
            // textBox_precio
            // 
            this.textBox_precio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_precio.Enabled = false;
            this.textBox_precio.Location = new System.Drawing.Point(88, 53);
            this.textBox_precio.Name = "textBox_precio";
            this.textBox_precio.ReadOnly = true;
            this.textBox_precio.Size = new System.Drawing.Size(177, 20);
            this.textBox_precio.TabIndex = 11;
            // 
            // label_precio
            // 
            this.label_precio.AutoSize = true;
            this.label_precio.Location = new System.Drawing.Point(13, 56);
            this.label_precio.Name = "label_precio";
            this.label_precio.Size = new System.Drawing.Size(61, 13);
            this.label_precio.TabIndex = 10;
            this.label_precio.Text = "Precio Plan";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 45);
            this.button1.TabIndex = 13;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_Id_Usuario
            // 
            this.label_Id_Usuario.AutoSize = true;
            this.label_Id_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Id_Usuario.Location = new System.Drawing.Point(311, 31);
            this.label_Id_Usuario.Name = "label_Id_Usuario";
            this.label_Id_Usuario.Size = new System.Drawing.Size(0, 18);
            this.label_Id_Usuario.TabIndex = 13;
            // 
            // groupBox_plan
            // 
            this.groupBox_plan.Controls.Add(this.label_plan);
            this.groupBox_plan.Controls.Add(this.textBox_Plan);
            this.groupBox_plan.Controls.Add(this.label_Cantidad);
            this.groupBox_plan.Controls.Add(this.textBox_Cantidad);
            this.groupBox_plan.Controls.Add(this.textBox_precio);
            this.groupBox_plan.Controls.Add(this.label_precio);
            this.groupBox_plan.Location = new System.Drawing.Point(12, 12);
            this.groupBox_plan.Name = "groupBox_plan";
            this.groupBox_plan.Size = new System.Drawing.Size(277, 117);
            this.groupBox_plan.TabIndex = 16;
            this.groupBox_plan.TabStop = false;
            this.groupBox_plan.Text = "Plan Seleccionado";
            // 
            // CompraBonoAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 194);
            this.Controls.Add(this.label_Id_Usuario);
            this.Controls.Add(this.groupBox_plan);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_Comprar);
            this.Name = "CompraBonoAfiliado";
            this.Text = "Comprar Bonos";
            this.Load += new System.EventHandler(this.CompraBono_Load);
            this.groupBox_plan.ResumeLayout(false);
            this.groupBox_plan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_plan;
        private System.Windows.Forms.TextBox textBox_Plan;
        private System.Windows.Forms.TextBox textBox_Cantidad;
        private System.Windows.Forms.Label label_Cantidad;
        private System.Windows.Forms.Button button_Comprar;
        private System.Windows.Forms.TextBox textBox_precio;
        private System.Windows.Forms.Label label_precio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_Id_Usuario;
        private System.Windows.Forms.GroupBox groupBox_plan;
    }
}