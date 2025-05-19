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
    public partial class FormSupervisor : Form
    {
        string legajoSupervisor;
        public FormSupervisor(string legajo)
        {
            InitializeComponent();
            legajoSupervisor = legajo;
        }
        private void btnModificarPersona_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormModificarPersona formModificarPersona = new FormModificarPersona(legajoSupervisor);
            formModificarPersona.ShowDialog();
        }

        private void btnDesbloquearUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDesbloquearCredenciales formDesbloquearCredenciales = new FormDesbloquearCredenciales(legajoSupervisor);
            formDesbloquearCredenciales.ShowDialog();
        }

    }
}
