using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public partial class FormPreguntarCambioPass : Form
    {
        Credencial credencialUsuario;
        public FormPreguntarCambioPass(Credencial credencial)
        {
            InitializeComponent();
            credencialUsuario = credencial;
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCambioPass formCambioPass = new FormCambioPass(credencialUsuario);
            formCambioPass.ShowDialog();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
