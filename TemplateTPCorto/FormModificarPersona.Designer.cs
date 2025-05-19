namespace TemplateTPCorto
{
    partial class FormModificarPersona
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
            this.rbFechaIngreso = new System.Windows.Forms.RadioButton();
            this.rbDni = new System.Windows.Forms.RadioButton();
            this.rbApellido = new System.Windows.Forms.RadioButton();
            this.rbNombre = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.txtNuevoValor = new System.Windows.Forms.TextBox();
            this.btnSolicitarModificacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbFechaIngreso
            // 
            this.rbFechaIngreso.AutoSize = true;
            this.rbFechaIngreso.Location = new System.Drawing.Point(151, 229);
            this.rbFechaIngreso.Margin = new System.Windows.Forms.Padding(4);
            this.rbFechaIngreso.Name = "rbFechaIngreso";
            this.rbFechaIngreso.Size = new System.Drawing.Size(133, 20);
            this.rbFechaIngreso.TabIndex = 25;
            this.rbFechaIngreso.TabStop = true;
            this.rbFechaIngreso.Text = "Fecha de ingreso";
            this.rbFechaIngreso.UseVisualStyleBackColor = true;
            // 
            // rbDni
            // 
            this.rbDni.AutoSize = true;
            this.rbDni.Location = new System.Drawing.Point(151, 201);
            this.rbDni.Margin = new System.Windows.Forms.Padding(4);
            this.rbDni.Name = "rbDni";
            this.rbDni.Size = new System.Drawing.Size(51, 20);
            this.rbDni.TabIndex = 24;
            this.rbDni.TabStop = true;
            this.rbDni.Text = "DNI";
            this.rbDni.UseVisualStyleBackColor = true;
            // 
            // rbApellido
            // 
            this.rbApellido.AutoSize = true;
            this.rbApellido.Location = new System.Drawing.Point(151, 173);
            this.rbApellido.Margin = new System.Windows.Forms.Padding(4);
            this.rbApellido.Name = "rbApellido";
            this.rbApellido.Size = new System.Drawing.Size(78, 20);
            this.rbApellido.TabIndex = 23;
            this.rbApellido.TabStop = true;
            this.rbApellido.Text = "Apellido";
            this.rbApellido.UseVisualStyleBackColor = true;
            // 
            // rbNombre
            // 
            this.rbNombre.AutoSize = true;
            this.rbNombre.Location = new System.Drawing.Point(151, 144);
            this.rbNombre.Margin = new System.Windows.Forms.Padding(4);
            this.rbNombre.Name = "rbNombre";
            this.rbNombre.Size = new System.Drawing.Size(77, 20);
            this.rbNombre.TabIndex = 22;
            this.rbNombre.TabStop = true;
            this.rbNombre.Text = "Nombre";
            this.rbNombre.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 40);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(231, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Solo puede modificar un dato a la vez";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 272);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nuevo Valor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Legajo (obligatorio)";
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(151, 89);
            this.txtLegajo.Margin = new System.Windows.Forms.Padding(4);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(296, 22);
            this.txtLegajo.TabIndex = 18;
            // 
            // txtNuevoValor
            // 
            this.txtNuevoValor.Location = new System.Drawing.Point(151, 292);
            this.txtNuevoValor.Margin = new System.Windows.Forms.Padding(4);
            this.txtNuevoValor.Name = "txtNuevoValor";
            this.txtNuevoValor.Size = new System.Drawing.Size(296, 22);
            this.txtNuevoValor.TabIndex = 17;
            // 
            // btnSolicitarModificacion
            // 
            this.btnSolicitarModificacion.Location = new System.Drawing.Point(151, 356);
            this.btnSolicitarModificacion.Margin = new System.Windows.Forms.Padding(4);
            this.btnSolicitarModificacion.Name = "btnSolicitarModificacion";
            this.btnSolicitarModificacion.Size = new System.Drawing.Size(297, 28);
            this.btnSolicitarModificacion.TabIndex = 16;
            this.btnSolicitarModificacion.Text = "Solicitar Modificacion";
            this.btnSolicitarModificacion.UseVisualStyleBackColor = true;
            this.btnSolicitarModificacion.Click += new System.EventHandler(this.btnSolicitarModificacion_Click);
            // 
            // FormModificarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rbFechaIngreso);
            this.Controls.Add(this.rbDni);
            this.Controls.Add(this.rbApellido);
            this.Controls.Add(this.rbNombre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLegajo);
            this.Controls.Add(this.txtNuevoValor);
            this.Controls.Add(this.btnSolicitarModificacion);
            this.Name = "FormModificarPersona";
            this.Text = "FormModificarPersona";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbFechaIngreso;
        private System.Windows.Forms.RadioButton rbDni;
        private System.Windows.Forms.RadioButton rbApellido;
        private System.Windows.Forms.RadioButton rbNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.TextBox txtNuevoValor;
        private System.Windows.Forms.Button btnSolicitarModificacion;
    }
}