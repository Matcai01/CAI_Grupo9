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
            if (loginNegocio.BuscarUsuarioBloqueado(usuario) == false)
            {
                Credencial credencial = loginNegocio.login(usuario, password);
                ValidarUsuario(credencial, usuario);
            }
            else
            {
                MessageBox.Show("El usuario ingresado se encuentra bloqueado...");
            }

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
                if (loginNegocio.VerificarUltimoIngreso(credencial.FechaUltimoLogin) == true) //punto 2 y 3
                {
                    MessageBox.Show("Debe cambiar su contraseña");
                    RedirigirCambioPass(credencial);    
                    IdentificarPerfilUsuario(credencial);
                }
                else
                {
                    loginNegocio.ModificarUltimoIngreso(credencial);
                    RedirigirPreguntarCambioPass(credencial);
                    IdentificarPerfilUsuario(credencial);
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

        public void IdentificarPerfilUsuario(Credencial credencial)   //punto 4
        {
            string perfilUsuario = loginNegocio.DevolverPerfilUsuario(credencial.Legajo);
            if (perfilUsuario == "1")
            {
                RedirigirOperador();
            }
            else if (perfilUsuario == "2")
            {
                RedirigirSupervisor(credencial.Legajo);
            }
            else if (perfilUsuario == "3")
            {
                RedirigirAdministrador(credencial.Legajo);
            }
        }

        public void RedirigirSupervisor(string legajo)  //PUNTO 4
        {
            this.Hide();
            FormSupervisor formSupervisor = new FormSupervisor(legajo);
            formSupervisor.ShowDialog();
        }

        public void RedirigirAdministrador(string legajo) //PUNTO 4
        {
            this.Hide();
            FormAdministrador formAdministrador = new FormAdministrador(legajo);
            formAdministrador.ShowDialog();
        }

        public void RedirigirOperador()
        {
            this.Hide();
            FormOperador formVentas = new FormOperador();
            formVentas.ShowDialog();
        }

    }
}