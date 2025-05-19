namespace TemplateTPCorto
{
    partial class FormAdministrador
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
            this.lstOperacionesCambioPersona = new System.Windows.Forms.ListView();
            this.lstOperacionesCambioCredencial = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtIdOperacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rbRechazar = new System.Windows.Forms.RadioButton();
            this.rbAutorizar = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 267);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Escriba el ID de la operacion que quiera autorizar o rechazar";
            // 
            // lstOperacionesCambioPersona
            // 
            this.lstOperacionesCambioPersona.HideSelection = false;
            this.lstOperacionesCambioPersona.Location = new System.Drawing.Point(584, 36);
            this.lstOperacionesCambioPersona.Name = "lstOperacionesCambioPersona";
            this.lstOperacionesCambioPersona.Size = new System.Drawing.Size(446, 200);
            this.lstOperacionesCambioPersona.TabIndex = 2;
            this.lstOperacionesCambioPersona.UseCompatibleStateImageBehavior = false;
            this.lstOperacionesCambioPersona.View = System.Windows.Forms.View.List;
            // 
            // lstOperacionesCambioCredencial
            // 
            this.lstOperacionesCambioCredencial.HideSelection = false;
            this.lstOperacionesCambioCredencial.Location = new System.Drawing.Point(18, 36);
            this.lstOperacionesCambioCredencial.Name = "lstOperacionesCambioCredencial";
            this.lstOperacionesCambioCredencial.Size = new System.Drawing.Size(469, 200);
            this.lstOperacionesCambioCredencial.TabIndex = 3;
            this.lstOperacionesCambioCredencial.UseCompatibleStateImageBehavior = false;
            this.lstOperacionesCambioCredencial.View = System.Windows.Forms.View.List;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Operaciones cambio credencial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(581, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Operaciones cambio persona";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(18, 416);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(157, 45);
            this.btnConfirmar.TabIndex = 6;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtIdOperacion
            // 
            this.txtIdOperacion.Location = new System.Drawing.Point(16, 300);
            this.txtIdOperacion.Name = "txtIdOperacion";
            this.txtIdOperacion.Size = new System.Drawing.Size(157, 22);
            this.txtIdOperacion.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 343);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Seleccione que quiere hacer";
            // 
            // rbRechazar
            // 
            this.rbRechazar.AutoSize = true;
            this.rbRechazar.Location = new System.Drawing.Point(167, 375);
            this.rbRechazar.Name = "rbRechazar";
            this.rbRechazar.Size = new System.Drawing.Size(86, 20);
            this.rbRechazar.TabIndex = 19;
            this.rbRechazar.TabStop = true;
            this.rbRechazar.Text = "Rechazar";
            this.rbRechazar.UseVisualStyleBackColor = true;
            // 
            // rbAutorizar
            // 
            this.rbAutorizar.AutoSize = true;
            this.rbAutorizar.Location = new System.Drawing.Point(16, 375);
            this.rbAutorizar.Name = "rbAutorizar";
            this.rbAutorizar.Size = new System.Drawing.Size(80, 20);
            this.rbAutorizar.TabIndex = 20;
            this.rbAutorizar.TabStop = true;
            this.rbAutorizar.Text = "Autorizar";
            this.rbAutorizar.UseVisualStyleBackColor = true;
            // 
            // FormAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.rbAutorizar);
            this.Controls.Add(this.rbRechazar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIdOperacion);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstOperacionesCambioCredencial);
            this.Controls.Add(this.lstOperacionesCambioPersona);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAdministrador";
            this.Text = "FormAdministrador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstOperacionesCambioPersona;
        private System.Windows.Forms.ListView lstOperacionesCambioCredencial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtIdOperacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbRechazar;
        private System.Windows.Forms.RadioButton rbAutorizar;
    }
}