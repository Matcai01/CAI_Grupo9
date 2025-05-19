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
    public partial class FormDesbloquearCredenciales : Form
    {
        string legajoSupervisor;
        PerfilNegocio perfilNegocio = new PerfilNegocio();
        public FormDesbloquearCredenciales(string legajo)
        {
            InitializeComponent();
            legajoSupervisor = legajo;
        }

        private void btnDesbloquearUsuario_Click(object sender, EventArgs e)
        {
            string legajoBloqueado = txtLegajo.Text;
            if (perfilNegocio.ValidarLegajo(legajoBloqueado) == true)
            {
                MessageBox.Show("No ha ingresado un legajo valido o no ha ingresado nada...");
            }
            else if (perfilNegocio.ValidarLegajoBloqueado(legajoBloqueado) == true)
            {
                MessageBox.Show("El legajo ingresado no se encuentra bloqueado....");
            }
            else
            {
                perfilNegocio.SolicitarDesbloquearUsuario(legajoBloqueado, legajoSupervisor);
                MessageBox.Show("La solicitud de desbloquear al usuario ha sido cargada con exito!");
            }
        }
    }
}
