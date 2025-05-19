using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace TemplateTPCorto
{
    public partial class FormAdministrador : Form
    {
        PerfilNegocio perfilNegocio = new PerfilNegocio();
        string legajoAdministrador;
        public FormAdministrador(string legajo)
        {
            InitializeComponent();
            legajoAdministrador = legajo;
        }
    }
}
