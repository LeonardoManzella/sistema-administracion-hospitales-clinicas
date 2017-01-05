namespace ClinicaFrba.AgendaMedico
{
    partial class AgendaMedico
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
            this.horariosPorDiaList = new System.Windows.Forms.ListBox();
            this.agregarHorarioButton = new System.Windows.Forms.Button();
            this.borrarHorarioButton = new System.Windows.Forms.Button();
            this.diasSemanaCombo = new System.Windows.Forms.ComboBox();
            this.horarioDesdeCombo = new System.Windows.Forms.ComboBox();
            this.horarioHastaCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.especialidadCombo = new System.Windows.Forms.ComboBox();
            this.fechaDesdePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fechaHastaPicker = new System.Windows.Forms.DateTimePicker();
            this.aceptarAgendaMedicaButton = new System.Windows.Forms.Button();
            this.cancelarAgendaMedicaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // horariosPorDiaList
            // 
            this.horariosPorDiaList.FormattingEnabled = true;
            this.horariosPorDiaList.Location = new System.Drawing.Point(21, 172);
            this.horariosPorDiaList.Name = "horariosPorDiaList";
            this.horariosPorDiaList.Size = new System.Drawing.Size(246, 121);
            this.horariosPorDiaList.TabIndex = 0;
            // 
            // agregarHorarioButton
            // 
            this.agregarHorarioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregarHorarioButton.Location = new System.Drawing.Point(273, 129);
            this.agregarHorarioButton.Name = "agregarHorarioButton";
            this.agregarHorarioButton.Size = new System.Drawing.Size(84, 50);
            this.agregarHorarioButton.TabIndex = 3;
            this.agregarHorarioButton.Text = "Agregar Horario";
            this.agregarHorarioButton.UseVisualStyleBackColor = true;
            this.agregarHorarioButton.Click += new System.EventHandler(this.agregarHorarioButton_Click);
            // 
            // borrarHorarioButton
            // 
            this.borrarHorarioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borrarHorarioButton.Location = new System.Drawing.Point(273, 216);
            this.borrarHorarioButton.Name = "borrarHorarioButton";
            this.borrarHorarioButton.Size = new System.Drawing.Size(84, 53);
            this.borrarHorarioButton.TabIndex = 4;
            this.borrarHorarioButton.Text = "Borrar Horario";
            this.borrarHorarioButton.UseVisualStyleBackColor = true;
            this.borrarHorarioButton.Click += new System.EventHandler(this.borrarHorarioButton_Click);
            // 
            // diasSemanaCombo
            // 
            this.diasSemanaCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diasSemanaCombo.FormattingEnabled = true;
            this.diasSemanaCombo.Location = new System.Drawing.Point(21, 94);
            this.diasSemanaCombo.Name = "diasSemanaCombo";
            this.diasSemanaCombo.Size = new System.Drawing.Size(246, 21);
            this.diasSemanaCombo.TabIndex = 5;
            this.diasSemanaCombo.SelectedIndexChanged += new System.EventHandler(this.diasSemanaCombo_SelectedIndexChanged);
            // 
            // horarioDesdeCombo
            // 
            this.horarioDesdeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.horarioDesdeCombo.FormattingEnabled = true;
            this.horarioDesdeCombo.Location = new System.Drawing.Point(21, 145);
            this.horarioDesdeCombo.Name = "horarioDesdeCombo";
            this.horarioDesdeCombo.Size = new System.Drawing.Size(121, 21);
            this.horarioDesdeCombo.TabIndex = 7;
            // 
            // horarioHastaCombo
            // 
            this.horarioHastaCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.horarioHastaCombo.FormattingEnabled = true;
            this.horarioHastaCombo.Location = new System.Drawing.Point(146, 145);
            this.horarioHastaCombo.Name = "horarioHastaCombo";
            this.horarioHastaCombo.Size = new System.Drawing.Size(121, 21);
            this.horarioHastaCombo.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(17, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Seleccione el dia de la semana:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(17, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Seleccione el rango horario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(17, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Seleccione el rango de fechas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(17, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Seleccione la especialidad:";
            // 
            // especialidadCombo
            // 
            this.especialidadCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.especialidadCombo.FormattingEnabled = true;
            this.especialidadCombo.Location = new System.Drawing.Point(21, 43);
            this.especialidadCombo.Name = "especialidadCombo";
            this.especialidadCombo.Size = new System.Drawing.Size(246, 21);
            this.especialidadCombo.TabIndex = 13;
            // 
            // fechaDesdePicker
            // 
            this.fechaDesdePicker.Location = new System.Drawing.Point(72, 332);
            this.fechaDesdePicker.Name = "fechaDesdePicker";
            this.fechaDesdePicker.Size = new System.Drawing.Size(195, 20);
            this.fechaDesdePicker.TabIndex = 14;
            this.fechaDesdePicker.ValueChanged += new System.EventHandler(this.fechaDesdePicker_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(17, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Desde";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(17, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Hasta";
            // 
            // fechaHastaPicker
            // 
            this.fechaHastaPicker.Location = new System.Drawing.Point(72, 358);
            this.fechaHastaPicker.Name = "fechaHastaPicker";
            this.fechaHastaPicker.Size = new System.Drawing.Size(195, 20);
            this.fechaHastaPicker.TabIndex = 17;
            // 
            // aceptarAgendaMedicaButton
            // 
            this.aceptarAgendaMedicaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarAgendaMedicaButton.Location = new System.Drawing.Point(255, 384);
            this.aceptarAgendaMedicaButton.Name = "aceptarAgendaMedicaButton";
            this.aceptarAgendaMedicaButton.Size = new System.Drawing.Size(102, 53);
            this.aceptarAgendaMedicaButton.TabIndex = 19;
            this.aceptarAgendaMedicaButton.Text = "Aceptar";
            this.aceptarAgendaMedicaButton.UseVisualStyleBackColor = true;
            this.aceptarAgendaMedicaButton.Click += new System.EventHandler(this.aceptarAgendaMedicaButton_Click);
            // 
            // cancelarAgendaMedicaButton
            // 
            this.cancelarAgendaMedicaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarAgendaMedicaButton.Location = new System.Drawing.Point(12, 388);
            this.cancelarAgendaMedicaButton.Name = "cancelarAgendaMedicaButton";
            this.cancelarAgendaMedicaButton.Size = new System.Drawing.Size(109, 49);
            this.cancelarAgendaMedicaButton.TabIndex = 20;
            this.cancelarAgendaMedicaButton.Text = "Cancelar";
            this.cancelarAgendaMedicaButton.UseVisualStyleBackColor = true;
            this.cancelarAgendaMedicaButton.Click += new System.EventHandler(this.cancelarAgendaMedicaButton_Click);
            // 
            // AgendaMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 466);
            this.Controls.Add(this.cancelarAgendaMedicaButton);
            this.Controls.Add(this.aceptarAgendaMedicaButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fechaHastaPicker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.fechaDesdePicker);
            this.Controls.Add(this.especialidadCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.horarioHastaCombo);
            this.Controls.Add(this.horarioDesdeCombo);
            this.Controls.Add(this.diasSemanaCombo);
            this.Controls.Add(this.borrarHorarioButton);
            this.Controls.Add(this.agregarHorarioButton);
            this.Controls.Add(this.horariosPorDiaList);
            this.Name = "AgendaMedico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Agenda";
            this.Load += new System.EventHandler(this.AgendaMedico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox horariosPorDiaList;
        private System.Windows.Forms.Button agregarHorarioButton;
        private System.Windows.Forms.Button borrarHorarioButton;
        private System.Windows.Forms.ComboBox diasSemanaCombo;
        private System.Windows.Forms.ComboBox horarioDesdeCombo;
        private System.Windows.Forms.ComboBox horarioHastaCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox especialidadCombo;
        private System.Windows.Forms.DateTimePicker fechaDesdePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker fechaHastaPicker;
        private System.Windows.Forms.Button aceptarAgendaMedicaButton;
        private System.Windows.Forms.Button cancelarAgendaMedicaButton;
    }
}