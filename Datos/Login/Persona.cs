using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Login
{
    public class Persona
    {
        private String _legajo;
        private String _nombre;
        private String _apellido;
        private int _dni;
        private DateTime _fechaIngreso;

        public string Legajo { get => _legajo; set => _legajo = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public int Dni { get => _dni; set => _dni = value; }
        public DateTime FechaIngreso { get => _fechaIngreso; set => _fechaIngreso = value; }


        public Persona(String registro)
        {
            String[] datos = registro.Split(';');
            this._legajo = datos[0];
            this._nombre = datos[1];
            this._apellido = datos[2];
            this._dni = Convert.ToInt32(datos[3]);
            this._fechaIngreso = DateTime.ParseExact(datos[4], "d/M/yyyy", CultureInfo.InvariantCulture);

        }

        public Persona()
        {

        }
    }
}