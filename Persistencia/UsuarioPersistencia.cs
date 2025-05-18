using Datos;
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
    }
}