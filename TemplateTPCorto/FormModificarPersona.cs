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
    public partial class FormModificarPersona : Form
    {
        PerfilNegocio perfilNegocio = new PerfilNegocio(); //modifique el nombre de la clase decia partial y puse public
        string legajoSupervisor;
        public FormModificarPersona(string legajo)
        {
            InitializeComponent();
            legajoSupervisor = legajo;
        }

        private void btnSolicitarModificacion_Click(object sender, EventArgs e)
        {
            string legajo = txtLegajo.Text;
            string nuevoValor = txtNuevoValor.Text;
            if (!rbNombre.Checked && !rbApellido.Checked && !rbDni.Checked && !rbFechaIngreso.Checked)
            {
                MessageBox.Show("Debe seleccionar que dato quiere modificar..."); //.checked devuelve true si esta selccionado o false sino.
            }
            else
            {
                if (ValidarDatoIngresado(nuevoValor) == false && ValidarLegajo(legajo) == false)
                {
                    string datoModificar = DatoModificar();
                    perfilNegocio.CambiarDatosPersona(legajo, nuevoValor, datoModificar, legajoSupervisor);
                    MessageBox.Show("La solicitud de cambiar los datos de la persona ha sido cargada con exito!");
                }
            }
        }
        public bool ValidarLegajo(string legajo)
        {

            if (perfilNegocio.ValidarLegajo(legajo) == true)
            {
                MessageBox.Show("No ha ingresado un legajo valido o no ha ingresado nada...");
                return true;
            }
            return false;
        }

        public string DatoModificar()
        {
            string datoModificar = "";
            if (rbNombre.Checked)
            {
                datoModificar = "Nombre";
            }
            else if (rbApellido.Checked)
            {
                datoModificar = "Apellido";
            }
            else if (rbDni.Checked)
            {
                datoModificar = "Dni";
            }
            else if (rbFechaIngreso.Checked)
            {
                datoModificar = "Fecha ingreso";
            }
            return datoModificar;
        }
        public bool ValidarDatoIngresado(string nuevoValor)
        {
            bool error = false;
            if (rbNombre.Checked && perfilNegocio.ValidarVacio(nuevoValor) == true)
            {
                MessageBox.Show("No ha ingresado nada...");
                error = true;
            }
            else if (rbApellido.Checked && perfilNegocio.ValidarVacio(nuevoValor) == true)
            {
                MessageBox.Show("No ha ingresado nada...");
                error = true;
            }
            else if (rbDni.Checked == true && perfilNegocio.ValidarDni(nuevoValor) == true)
            {
                MessageBox.Show("No ha ingresado un dni valido o no ha ingresado nada...");
                error = true;
            }
            else if (rbFechaIngreso.Checked == true && perfilNegocio.ValidarFecha(nuevoValor) == true)
            {
                MessageBox.Show("No ha ingresado una fecha valida o no ha ingresado nada...");
                error = true;
            }
            return error;
        }
    }
}
