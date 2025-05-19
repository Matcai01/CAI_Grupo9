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
    public partial class SistemaLogin : Form
            {
        LoginNegocio loginNegocio = new LoginNegocio();
        public SistemaLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            String usuario = txtUsuario.Text;
            String password = txtPassword.Text;
            Credencial credencial = loginNegocio.login(usuario, password);
            ValidarUsuario(credencial, usuario);

        }
        public void ValidarUsuario(Credencial credencial, string usuario)
        {
            if (credencial == null)
            {
                MessageBox.Show("No se encontro ningun usuario con esas credenciales");
                loginNegocio.IntentosFallidos(usuario);
            }
            else
            {
                loginNegocio.BorrarIntentosFallidos(credencial.Legajo);
                MessageBox.Show("Credenciales validas!");
                if (loginNegocio.UsuarioBloqueado(credencial.Legajo) == true)
                {
                    MessageBox.Show("El usuario se encuentra bloqueado");           //PUNTO 1 HASTA ACA
                }
                else if (loginNegocio.VerificarUltimoIngreso(credencial.FechaUltimoLogin) == true) //punto 2 y 3
                {
                    MessageBox.Show("Debe cambiar su contraseña");
                    RedirigirCambioPass(credencial);    //falta poner una opcion de si quiere cambiar la pass
                }
                else
                {
                    RedirigirPreguntarCambioPass(credencial);
                }

            }
        }

        public void RedirigirCambioPass(Credencial credencial)   //PUNTO 2
        {
          this.Hide();
          FormCambioPass formCambioPass = new FormCambioPass(credencial);
          formCambioPass.ShowDialog();
        }

        public void RedirigirPreguntarCambioPass(Credencial credencial)
        {
            this.Hide();
            FormPreguntarCambioPass formPreguntarCambioPass = new FormPreguntarCambioPass(credencial);
            formPreguntarCambioPass.ShowDialog();
        }
    }
}