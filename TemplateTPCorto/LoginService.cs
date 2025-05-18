using System;

namespace Servicios
{
    public class LoginService
    {
        private const int DIAS_EXPIRACION = 30;

        public bool EsPasswordValida(string pass)
        {
            return pass.Length >= 8;
        }

        public bool EstaExpirada(DateTime fechaUltimoLogin)
        {
            if (fechaUltimoLogin == DateTime.MinValue)
            {
                Console.WriteLine("Es el primer login, se requiere cambio de contraseña.");
                return true;
            }

            TimeSpan diferencia = DateTime.Now - fechaUltimoLogin;
            return diferencia.Days >= DIAS_EXPIRACION;
        }
    }
}
