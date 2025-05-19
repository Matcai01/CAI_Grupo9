using Datos;
using Negocio;
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
    public partial class FormCambioPass : Form
    {
        Credencial credencialUsuario;
        public FormCambioPass(Credencial credencial)
        {
            InitializeComponent();
            credencialUsuario = credencial;
        }

        private void btnCambioPass_Click(object sender, EventArgs e)
        {
            string passNueva = txtPassNueva.Text;
            LoginNegocio loginNegocio = new LoginNegocio();
            bool igualdadPass = loginNegocio.ValidarIgualdadPass(passNueva, credencialUsuario);
            bool cantidadCaracteres = loginNegocio.ValidarCantidadCaracteres(passNueva);
            if (igualdadPass == false)
            {
                MessageBox.Show("La contraseña debe ser difente a su contraseña actual....");
            }
            else if (cantidadCaracteres == false)
            {
                MessageBox.Show("La contraseña nueva debe tener al menos 8 caracteres...");
            }
            else
            {
                loginNegocio.CambiarPass(passNueva, credencialUsuario);
                MessageBox.Show("La contraseña fue cambiada con exito!");
                this.Hide();
            }
        }
    }

}