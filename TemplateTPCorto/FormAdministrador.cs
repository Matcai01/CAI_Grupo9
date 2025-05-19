using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            List<string> listaSolicutdCambioCredencial = perfilNegocio.DevolverLista("operacion_cambio_credencial.csv");
            List<string> listaSolicutdCambioPersona = perfilNegocio.DevolverLista("operacion_cambio_persona.csv");
            foreach (string registro in listaSolicutdCambioPersona)
            {
                lstOperacionesCambioPersona.Items.Add(registro);
            }
            foreach (string registro in listaSolicutdCambioCredencial)
            {
               lstOperacionesCambioCredencial.Items.Add(registro);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string idOperacion = txtIdOperacion.Text;
            if (Validaciones(idOperacion) == false)
            {
                if (perfilNegocio.DevolverTipoOperacion(idOperacion) == "Modificar persona")
                {
                    string operacion = perfilNegocio.DevolverOperacion(idOperacion, "operacion_cambio_persona.csv");
                    if (rbAutorizar.Checked)
                    {
                        perfilNegocio.CambiarEstadoOperacion(operacion, legajoAdministrador, "Autorizada");
                    }
                    else
                    {
                        perfilNegocio.CambiarEstadoOperacion(operacion, legajoAdministrador, "Rechazada");
                    }
                    BorrarOperacionesLista(operacion, lstOperacionesCambioPersona);
                }
                else
                {
                    string operacion = perfilNegocio.DevolverOperacion(idOperacion, "operacion_cambio_credencial.csv");
                    if (rbAutorizar.Checked)
                    {
                        perfilNegocio.CambiarEstadoOperacion(operacion, legajoAdministrador, "Autorizada");
                    }
                    else
                    {
                        perfilNegocio.CambiarEstadoOperacion(operacion, legajoAdministrador, "Rechazada");
                    }
                    BorrarOperacionesLista(operacion, lstOperacionesCambioCredencial);
                }               
                MessageBox.Show("Se ha realizado con exito la operacion!");
            }
            
        }

        public bool Validaciones(string idOperacion)
        {
            bool error = false;        
            if (perfilNegocio.ValidarIdOperacion(idOperacion) == true)
            {
                MessageBox.Show("No se ha podido validar el id ingresado...");
                error = true;
            }
            else if (!rbAutorizar.Checked && !rbRechazar.Checked)
            {
                MessageBox.Show("No ha seleccionado si quiere autorizar o rechazar la operacion...");
                error = true;
            }
            return error;
        }

        public void BorrarOperacionesLista(string operacion, ListView lista)
        {
            foreach (ListViewItem item in lista.Items)
            {
                if (item.Text == operacion)
                {
                    lista.Items.Remove(item);

                }
            }
        }

    }
}

