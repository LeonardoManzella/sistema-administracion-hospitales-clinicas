namespace ClinicaFrba.CancelarTurno
{
    partial class CancelarTurnoProfesional
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
            this.fechaDesdePicker = new System.Windows.Forms.DateTimePicker();
            this.cancelarTurnoProButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fechaHastaPicker = new System.Windows.Forms.DateTimePicker();
            this.motivoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fechaDesdePicker
            // 
            this.fechaDesdePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaDesdePicker.Location = new System.Drawing.Point(42, 68);
            this.fechaDesdePicker.MinDate = new System.DateTime(1970, 11, 29, 0, 0, 0, 0);
            this.fechaDesdePicker.Name = "fechaDesdePicker";
            this.fechaDesdePicker.Size = new System.Drawing.Size(369, 20);
            this.fechaDesdePicker.TabIndex = 1;
            this.fechaDesdePicker.Value = new System.DateTime(2016, 11, 29, 0, 0, 0, 0);
            this.fechaDesdePicker.ValueChanged += new System.EventHandler(this.fechaDesdePicker_ValueChanged);
            // 
            // cancelarTurnoProButton
            // 
            this.cancelarTurnoProButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarTurnoProButton.Location = new System.Drawing.Point(289, 235);
            this.cancelarTurnoProButton.Name = "cancelarTurnoProButton";
            this.cancelarTurnoProButton.Size = new System.Drawing.Size(142, 52);
            this.cancelarTurnoProButton.TabIndex = 5;
            this.cancelarTurnoProButton.Text = "Cancelar turnos";
            this.cancelarTurnoProButton.UseVisualStyleBackColor = true;
            this.cancelarTurnoProButton.Click += new System.EventHandler(this.cancelarTurnoProButton_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(25, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 52);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Seleccione la(s) fecha(s):";
            // 
            // fechaHastaPicker
            // 
            this.fechaHastaPicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaHastaPicker.Location = new System.Drawing.Point(42, 94);
            this.fechaHastaPicker.Name = "fechaHastaPicker";
            this.fechaHastaPicker.Size = new System.Drawing.Size(369, 20);
            this.fechaHastaPicker.TabIndex = 8;
            // 
            // motivoTextBox
            // 
            this.motivoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.motivoTextBox.Location = new System.Drawing.Point(42, 151);
            this.motivoTextBox.MaxLength = 250;
            this.motivoTextBox.Multiline = true;
            this.motivoTextBox.Name = "motivoTextBox";
            this.motivoTextBox.Size = new System.Drawing.Size(369, 78);
            this.motivoTextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Especifique el motivo:";
            // 
            // CancelarTurnoProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 314);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.motivoTextBox);
            this.Controls.Add(this.fechaHastaPicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cancelarTurnoProButton);
            this.Controls.Add(this.fechaDesdePicker);
            this.Name = "CancelarTurnoProfesional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.CancelarTurnoProfesional_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker fechaDesdePicker;
        private System.Windows.Forms.Button cancelarTurnoProButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fechaHastaPicker;
        private System.Windows.Forms.TextBox motivoTextBox;
        private System.Windows.Forms.Label label1;
    }
}
