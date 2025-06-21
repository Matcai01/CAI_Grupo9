using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Ventas
{
    public class Venta
    {
        Guid _idCliente;
        Guid _idUsuario;
        Guid _idProducto;
        int _cantidad;

        public Guid IdCliente { get => _idCliente; set => _idCliente = value; }
        public Guid IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public Guid IdProducto { get => _idProducto; set => _idProducto = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }

        public Venta(Guid idProducto, int cantidad, Guid idCliente)
        {
            this._idCliente = idCliente;
            this._idUsuario = Guid.Parse("784c07f2-2b26-4973-9235-4064e94832b5"); //hardcodeado
            this._idProducto = idProducto;
            this._cantidad = cantidad;
        }
    }
}
