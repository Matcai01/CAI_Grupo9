using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Login;
using Datos;
using Persistencia;

namespace Negocio
{
    public class PerfilNegocio  //decia partial class y puse public class porque no me dejaba acceder sino
    {
        UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
        public bool ValidarDni(string dni)
        {
            if (string.IsNullOrEmpty(dni))
            {
                return true;
            }
            else if (!int.TryParse(dni, out int salida))
            {
                return true;
            }
            else if (dni.Length > 8)
            {
                return true;
            }
            return false;
        }
        public bool ValidarVacio(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return true;
            }
            return false;
        }
        public bool ValidarLegajo(string legajo)
        {
            if (string.IsNullOrEmpty(legajo))
            {
                return true;
            }
            else if (!int.TryParse(legajo, out int salida))
            {
                return true;
            }
            List<Credencial> credenciales = usuarioPersistencia.login("credenciales.csv");
            foreach (Credencial credencial in credenciales)
            {
                if (credencial.Legajo == legajo)
                {
                    return false;
                }
            }
            return false;
        }



        public bool ValidarFecha(string fecha)
        {
            if (string.IsNullOrEmpty(fecha))
            {
                return true;
            }
            else if (!DateTime.TryParse(fecha, out DateTime salida))
            {
                return true;
            }
            else if (salida > DateTime.Now || salida < DateTime.Now.AddYears(-150))
            {
                return true;
            }
            return false;
        }

        public void CambiarDatosPersona(string legajo, string nuevoValor, string datoModificar, string legajoSupervisor)
        {
            List<Persona> listaPersonas = usuarioPersistencia.DevolverPersonas();
            Persona personaModificar = DevolverPersona(listaPersonas, legajo);

            if (datoModificar == "Nombre")
            {
                personaModificar.Nombre = nuevoValor;
            }
            else if (datoModificar == "Apellido")
            {
                personaModificar.Apellido = nuevoValor;
            }
            else if (datoModificar == "Dni")
            {
                personaModificar.Dni = Convert.ToInt32(nuevoValor);
            }
            else if (datoModificar == "Fecha ingreso")
            {
                personaModificar.FechaIngreso = Convert.ToDateTime(nuevoValor);
            }
            string idOperacion = DevolverIdOperacion();
            AgregarSolicitudCambioPersona(personaModificar, idOperacion);
            AgregarSolicitudAutorizacion(idOperacion, legajoSupervisor, "Modificar persona");

        }

        public Persona DevolverPersona(List<Persona> listaPersonas, string legajo)
        {
            Persona personaBuscada = new Persona();
            foreach (Persona persona in listaPersonas)
            {
                if (persona.Legajo == legajo)
                {
                    personaBuscada = persona;
                }
            }
            return personaBuscada;
        }

        public string DevolverIdOperacion()
        {
            int numRegistrosAutorizaciones = usuarioPersistencia.DevolverLista("autorizacion.csv").Count() - 1;//resto uno para que no me cuente los nombres de la columna
            int numeroOperacion = numRegistrosAutorizaciones + 1;  //sumo porque si hay 3 operaciones ya, yo quiero el numero 4
            return numeroOperacion.ToString();
        }

        public void AgregarSolicitudCambioPersona(Persona personaModificar, string idOperacion)
        {
            string registro = idOperacion + ";" + personaModificar.Legajo + ";" + personaModificar.Nombre + ";" + personaModificar.Apellido +
                ";" + personaModificar.Dni.ToString() + ";" + personaModificar.FechaIngreso.ToShortDateString();
            usuarioPersistencia.AgregarDatos("operacion_cambio_persona.csv", registro);
        }

        public void AgregarSolicitudAutorizacion(string idOperacion, string legajoSolicitante, string tipoOperacion)
        {
            string registro = idOperacion + ";" + tipoOperacion + ";" + "Pendiente" + ";"
                + legajoSolicitante + ";" + DateTime.Now.ToShortDateString();
            usuarioPersistencia.AgregarDatos("autorizacion.csv", registro);
        }

        public bool ValidarLegajoBloqueado(string legajoBloqueado)
        {
            List<string> usuariosBloqueados = usuarioPersistencia.DevolverLista("usuario_bloqueado.csv");
            if (usuariosBloqueados.Contains(legajoBloqueado))
            {
                return false;
            }
            return true;
        }
        public void SolicitarDesbloquearUsuario(string legajoBloqueado, string legajoSupervisor)
        {
            string idOperacion = DevolverIdOperacion();
            List<Credencial> listaCredenciales = usuarioPersistencia.login("credenciales.csv");
            Credencial credencialBloqueado = DevolverCredencial(listaCredenciales, legajoBloqueado);
            string idPerfilBloqueado = DevolverIdPerfil(legajoBloqueado);
            string registroCambioCredencial = idOperacion + ";" + legajoBloqueado + ";" + credencialBloqueado.NombreUsuario.ToString() +
                ";" + "contraseña123" + ";" + idPerfilBloqueado + ";" + credencialBloqueado.FechaAlta.ToShortDateString();
            usuarioPersistencia.AgregarDatos("operacion_cambio_credencial.csv", registroCambioCredencial);
            AgregarSolicitudAutorizacion(idOperacion, legajoSupervisor, "Modificar credencial");
        }

        public Credencial DevolverCredencial(List<Credencial> listaCredenciales, string legajoBloqueado)
        {

            foreach (Credencial credencial in listaCredenciales)
            {
                if (credencial.Legajo == legajoBloqueado)
                {
                    return credencial;
                }
            }
            return null;
        }

        public string DevolverIdPerfil(string legajo)
        {
            List<string> listaUsuarioPerfil = usuarioPersistencia.DevolverLista("usuario_perfil.csv");
            foreach (string registro in listaUsuarioPerfil)
            {
                string[] registroVector = registro.Split(';');
                if (registroVector[0] == legajo)
                {
                    return registroVector[1];
                }
            }
            return null;
        }
        public List<string> DevolverLista(string nombreArchivo)
        {
            List<string> listaRegistros = usuarioPersistencia.DevolverLista(nombreArchivo);
            listaRegistros.RemoveAt(0);
            return listaRegistros;
        }

        public void CambiarEstadoOperacion(string operacion, string legajoAdministrador, string estado) //estado = true aprobada
        {
            List<string> listaSolicitudCambioCredencial = DevolverLista("operacion_cambio_credencial.csv");
            if (listaSolicitudCambioCredencial.Contains(operacion))
            {
                ModificarAutorizacion(operacion, legajoAdministrador, "operacion_cambio_credencial.csv", estado);
                ModificarCredencial(operacion);

            }
            else
            {
                ModificarAutorizacion(operacion, legajoAdministrador, "operacion_cambio_persona.csv", estado);
                ModificarPersona(operacion);
            }
        }
        public void ModificarAutorizacion(string operacion, string legajoAdministrador, string nombreArchivo, string estado)
        {
            List<Autorizacion> listaAutorizaciones = usuarioPersistencia.DevolverListaAutorizacion();
            string[] operacionVector = operacion.Split(';');
            foreach (Autorizacion autorizacion in listaAutorizaciones)
            {
                if (operacionVector[0] == autorizacion.IdOperacion)
                {
                    string nuevoRegistro = autorizacion.IdOperacion + ";" + autorizacion.TipoOperacion + ";" +
                    estado + ";" + autorizacion.LegajoSolicitante + ";" + autorizacion.FechaSolicitud.ToShortDateString() + ";" +
                    legajoAdministrador + ";" + DateTime.Now.ToShortDateString();
                    usuarioPersistencia.BorrarDatos(autorizacion.IdOperacion, "autorizacion.csv");
                    usuarioPersistencia.BorrarDatos(autorizacion.IdOperacion, nombreArchivo);
                    usuarioPersistencia.AgregarDatos("autorizacion.csv", nuevoRegistro);

                }
            }

        }

        public void ModificarCredencial(string operacion)
        {
            string[] operacionVector = operacion.Split(';');
            string legajo = operacionVector[1];
            string registroNuevo = operacionVector[1] + ";" + operacionVector[2] + ";" + operacionVector[3] +
            ";" + operacionVector[5];
            usuarioPersistencia.BorrarDatos(legajo, "credenciales.csv");
            usuarioPersistencia.AgregarDatos("credenciales.csv", registroNuevo);
            usuarioPersistencia.BorrarDatos(legajo, "usuario_bloqueado.csv");
        }

        public void ModificarPersona(string operacion)
        {
            string[] operacionVector = operacion.Split(';');
            string legajo = operacionVector[1];
            string registroNuevo = operacionVector[1] + ";" + operacionVector[2] + ";" + operacionVector[3] +
            ";" + operacionVector[4] + ";" + operacionVector[5];
            usuarioPersistencia.BorrarDatos(legajo, "persona.csv");
            usuarioPersistencia.AgregarDatos("persona.csv", registroNuevo);
        }

        public bool ValidarIdOperacion(string idOperacion)
        {
            if (string.IsNullOrEmpty(idOperacion))
            {
                return true;
            }
            else if (!int.TryParse(idOperacion, out int salida))
            {
                return true;
            }
            else if (DevolverOperacion(idOperacion, "operacion_cambio_persona.csv") == "" &&
            DevolverOperacion(idOperacion, "operacion_cambio_credencial.csv") == "")
            {
                return true;
            }
            return false;
        }

        public string DevolverOperacion(string idOperacion, string nombreArchivo)
        {
            string operacionEncontrada = "";
            List<string> operaciones = DevolverLista(nombreArchivo);
            foreach (string operacion in operaciones)
            {
                string[] operacionVector = operacion.Split(';');
                if (operacionVector[0] == idOperacion)
                {
                    operacionEncontrada = operacion;
                }
            }
            return operacionEncontrada;
        }

        public string DevolverTipoOperacion(string idOperacion)
        {
            string tipoOperacion = "";
            List<Autorizacion> operaciones = usuarioPersistencia.DevolverListaAutorizacion();
            foreach (Autorizacion operacion in operaciones)
            {
                if (operacion.IdOperacion == idOperacion)
                {
                    tipoOperacion = operacion.TipoOperacion;
                }
            }
            return tipoOperacion;
        }

    }


}

