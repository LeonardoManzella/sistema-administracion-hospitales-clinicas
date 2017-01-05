namespace ClinicaFrba.CancelarTurno
{
    partial class CancelarTurnoAfiliado
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboCancelarTurno = new System.Windows.Forms.ComboBox();
            this.cancelarTurnoButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.motivoCancelacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione el turno a cancelar:";
            // 
            // comboCancelarTurno
            // 
            this.comboCancelarTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCancelarTurno.FormattingEnabled = true;
            this.comboCancelarTurno.Location = new System.Drawing.Point(21, 65);
            this.comboCancelarTurno.Name = "comboCancelarTurno";
            this.comboCancelarTurno.Size = new System.Drawing.Size(447, 21);
            this.comboCancelarTurno.TabIndex = 1;
            // 
            // cancelarTurnoButton
            // 
            this.cancelarTurnoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarTurnoButton.Location = new System.Drawing.Point(338, 244);
            this.cancelarTurnoButton.Name = "cancelarTurnoButton";
            this.cancelarTurnoButton.Size = new System.Drawing.Size(130, 53);
            this.cancelarTurnoButton.TabIndex = 2;
            this.cancelarTurnoButton.Text = "Cancelar Turno";
            this.cancelarTurnoButton.UseVisualStyleBackColor = true;
            this.cancelarTurnoButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButton.Location = new System.Drawing.Point(22, 244);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(103, 53);
            this.cancelarButton.TabIndex = 3;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // motivoCancelacion
            // 
            this.motivoCancelacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.motivoCancelacion.Location = new System.Drawing.Point(21, 132);
            this.motivoCancelacion.MaxLength = 250;
            this.motivoCancelacion.Multiline = true;
            this.motivoCancelacion.Name = "motivoCancelacion";
            this.motivoCancelacion.Size = new System.Drawing.Size(447, 106);
            this.motivoCancelacion.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(18, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Especifique el motivo:";
            // 
            // CancelarTurnoAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 369);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.motivoCancelacion);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.cancelarTurnoButton);
            this.Controls.Add(this.comboCancelarTurno);
            this.Controls.Add(this.label1);
            this.Name = "CancelarTurnoAfiliado";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.CancelarAtencion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboCancelarTurno;
        private System.Windows.Forms.Button cancelarTurnoButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.TextBox motivoCancelacion;
        private System.Windows.Forms.Label label2;
    }
}