namespace TemplateTPCorto
{
    partial class FormCambioPass
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
            this.btnCambioPass = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassNueva = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCambioPass
            // 
            this.btnCambioPass.Location = new System.Drawing.Point(42, 196);
            this.btnCambioPass.Name = "btnCambioPass";
            this.btnCambioPass.Size = new System.Drawing.Size(100, 23);
            this.btnCambioPass.TabIndex = 0;
            this.btnCambioPass.Text = "Cambiar Pass";
            this.btnCambioPass.UseVisualStyleBackColor = true;
            this.btnCambioPass.Click += new System.EventHandler(this.btnCambioPass_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Igrese la nueva contraseña";
            // 
            // txtPassNueva
            // 
            this.txtPassNueva.Location = new System.Drawing.Point(42, 148);
            this.txtPassNueva.Name = "txtPassNueva";
            this.txtPassNueva.Size = new System.Drawing.Size(100, 20);
            this.txtPassNueva.TabIndex = 2;
            // 
            // FormCambioPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtPassNueva);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCambioPass);
            this.Name = "FormCambioPass";
            this.Text = "FormCambioPass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCambioPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassNueva;
    }
}