using Datos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// punto 1 inicio
namespace Negocio
{
    public class LoginNegocio
    { UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
        public Credencial login(String usuario, String password)
        {
            List<Credencial> listaCredenciales = usuarioPersistencia.login("credenciales.csv");
            foreach (Credencial credencial in listaCredenciales)
            {
                if (credencial.Contrasena.Equals(password) && credencial.NombreUsuario.Equals(usuario))
                {
                    return credencial;
                }
            }
            return null;
        }
        public bool UsuarioBloqueado(string legajo)
        {
            bool bloqueado = false;
            List<string> bloqueados = usuarioPersistencia.DevolverLista("usuario_bloqueado.csv");
            if (bloqueados.Contains(legajo))
            {
                bloqueado = true;
            }
            return bloqueado;
        }
        public void ValidarUsuarioBloqueado(string legajo)
        {
            List<string> intentosFallidos = usuarioPersistencia.DevolverLista("login_intentos.csv");
            int totalIntentos = 0;
            foreach (string registro in intentosFallidos)
            {
                string[] registro1 = registro.Split(';');
                if (registro1[0] == legajo)
                {
                    totalIntentos++;
                }
            }
            if (totalIntentos == 3)
            {
                usuarioPersistencia.AgregarUsuarioBloqueado(legajo);
            }
        }
        public void IntentosFallidos(string usuario)
        {
            string legajo = DevolverLegajo(usuario);
            if (legajo != "")
            {
                usuarioPersistencia.AgregarIntentoFallido(legajo);
                ValidarUsuarioBloqueado(legajo);
            }
        }
        public string DevolverLegajo(string usuario)
        {
            string legajo = "";
            List<Credencial> credenciales = usuarioPersistencia.login("credenciales.csv");
            foreach (Credencial credencial in credenciales)
            {
                if (credencial.NombreUsuario == usuario)
                {
                    legajo = credencial.Legajo;
                }
            }
            return legajo;
        }
        public void BorrarIntentosFallidos(string legajo)  // fin punto 1 tp
        {
            usuarioPersistencia.BorrarDatos(legajo, "login_intentos.csv");
        }
    }
}