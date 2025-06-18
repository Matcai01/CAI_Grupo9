using Datos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public bool BuscarUsuarioBloqueado(string usuario) 
        {
            string legajo = DevolverLegajo(usuario);
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

        public bool VerificarUltimoIngreso(DateTime fechaUltimoIngreso)
        {
            bool cambiarPass = false;
            if (fechaUltimoIngreso == DateTime.MinValue)   // punto 3
            {
                return true;
            }
            if (fechaUltimoIngreso < DateTime.Today.AddDays(-30))  //punto 2
            {
                cambiarPass = true;
            }
            return cambiarPass;
        }
        public bool ValidarIgualdadPass(string passNueva, Credencial credencialUsuario)
        {
            if (credencialUsuario.Contrasena == "contraseña123")   //punto 4
            {
                return true;
            }
            else if (passNueva == credencialUsuario.Contrasena)
            {
                return false;
            }
            return true;
        }
        public bool ValidarCantidadCaracteres(string passNueva)
        {
            if (passNueva.Length < 8)
            {
                return false;
            }
            return true;
        }

        public void CambiarPass(string passNueva, Credencial credencialUsuario)
        {
            string registro = credencialUsuario.Legajo + ";" + credencialUsuario.NombreUsuario + ";"
                + passNueva + ";" + credencialUsuario.FechaAlta.ToShortDateString() + ";"
                + DateTime.Now.ToShortDateString();
            usuarioPersistencia.ModificarDatos(registro, credencialUsuario);

        }

        public string DevolverPerfilUsuario(string legajo)
        {
            List<string> perfilUsuarios = usuarioPersistencia.DevolverLista("usuario_perfil.csv");
            string perfil = "";
            foreach (string perfilUsario in perfilUsuarios)
            {
                string[] perfilUsuarioVector = perfilUsario.Split(';');
                if (perfilUsuarioVector[0] == legajo)
                {
                    return perfilUsuarioVector[1];
                }
            }
            return perfil;
        }



    }
}