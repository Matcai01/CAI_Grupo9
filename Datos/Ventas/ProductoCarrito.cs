using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Ventas
{
    public class ProductoCarrito
    {
        Guid _id;
        String _nombre;
        int _precio;
        int _cantidad;

        public Guid Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Precio { get => _precio; set => _precio = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }

        public override string ToString()
        {
            return Nombre + ", " + Precio + ", " + Cantidad;
        }
    }
}
