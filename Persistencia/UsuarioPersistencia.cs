using Datos;
using Datos.Login;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class UsuarioPersistencia
    {
        DataBaseUtils dataBaseUtils = new DataBaseUtils();
        public List<Credencial> login(String nombreArchivo)
        {
            List<Credencial> listaCredenciales = new List<Credencial>();
            List<String> registros = dataBaseUtils.BuscarRegistro(nombreArchivo);
            int contador = 0;
            foreach (string registro in registros)
            {
                if (contador != 0)
                {
                    Credencial credencial = new Credencial(registro);
                    listaCredenciales.Add(credencial);
                }
                contador = 1;
            }
            return listaCredenciales;
        }
        public void AgregarUsuarioBloqueado(string legajo)
        {
            dataBaseUtils.AgregarRegistro("usuario_bloqueado.csv", legajo);
        }
        public List<string> DevolverLista(string nombreArchivo)   //funcion para todos los puntos
        {
            List<string> lista = dataBaseUtils.BuscarRegistro(nombreArchivo);
            return lista;
        }
        public void AgregarIntentoFallido(string legajo)
        {
            dataBaseUtils.AgregarRegistro("login_intentos.csv", legajo + ";" + DateTime.Now.ToShortDateString());
        }
        public void BorrarDatos(string id, string nombreArchivo)
        {
            dataBaseUtils.BorrarRegistro(id, nombreArchivo);
        }
        public void ModificarDatos(string nuevoRegistro, Credencial credencialUsuario)  
        {
            dataBaseUtils.BorrarRegistro(credencialUsuario.Legajo, "credenciales.csv");
            dataBaseUtils.AgregarRegistro("credenciales.csv", nuevoRegistro);
        }

        public List<Persona> DevolverPersonas()
        {
            List<Persona> listaPersonas = new List<Persona>();
            List<String> registros = dataBaseUtils.BuscarRegistro("persona.csv");
            int contador = 0;
            foreach (string registro in registros)
            {
                if (contador != 0)
                {
                    Persona persona = new Persona(registro);
                    listaPersonas.Add(persona);
                }
                contador++;
            }
            return listaPersonas;
        }

        public void AgregarDatos(string nombreArchivo, string nuevoRegistro)  //GLOBAL
        {
            dataBaseUtils.AgregarRegistro(nombreArchivo, nuevoRegistro);
        }

        public List<Operacion_cambio_credencial> DevolverListaCambioCredencial()
        {
            List<Operacion_cambio_credencial> listaCambioCredencial = new List<Operacion_cambio_credencial>();
            List<String> registros = dataBaseUtils.BuscarRegistro("operacion_cambio_credencial.csv");
            int contador = 0;
            foreach (string registro in registros)
            {
                if (contador != 0)
                {
                    Operacion_cambio_credencial operacion = new Operacion_cambio_credencial(registro);
                    listaCambioCredencial.Add(operacion);
                }
                contador++;
            }
            return listaCambioCredencial;
        }

        public List<Operacion_cambio_persona> DevolverListaCambioPersona()
        {
            List<Operacion_cambio_persona> listaCambioPersona = new List<Operacion_cambio_persona>();
            List<String> registros = dataBaseUtils.BuscarRegistro("operacion_cambio_persona.csv");
            int contador = 0;
            foreach (string registro in registros)
            {
                if (contador != 0)
                {
                    Operacion_cambio_persona operacion = new Operacion_cambio_persona(registro);
                    listaCambioPersona.Add(operacion);
                }
                contador++;
            }
            return listaCambioPersona;
        }
        public List<Autorizacion> DevolverListaAutorizacion()
        {
            List<Autorizacion> listaAutorizacion = new List<Autorizacion>();
            List<String> registros = dataBaseUtils.BuscarRegistro("autorizacion.csv");
            int contador = 0;
            foreach (string registro in registros)
            {
                if (contador != 0)
                {
                    Autorizacion autorizacion = new Autorizacion(registro);
                    listaAutorizacion.Add(autorizacion);
                }
                contador++;
            }
            return listaAutorizacion;
        }

    }
}