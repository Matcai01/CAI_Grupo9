using Datos.Ventas;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentasNegocio
    {
        public List<Cliente> obtenerClientes()
        {

            ClientePersistencia clientePersistencia = new ClientePersistencia();

            List<Cliente> clientes = clientePersistencia.obtenerClientes();

            return clientes;
        }

        public List<CategoriaProductos> obtenerCategoriaProductos()
        {
            List<CategoriaProductos> categoriaProductos = new List<CategoriaProductos>();

            CategoriaProductos p1 = new CategoriaProductos("1", "Audio");
            categoriaProductos.Add(p1);

            CategoriaProductos p2 = new CategoriaProductos("2", "Celulares");
            categoriaProductos.Add(p2);

            CategoriaProductos p3 = new CategoriaProductos("3", "Electro Hogar");
            categoriaProductos.Add(p3);

            CategoriaProductos p4 = new CategoriaProductos("4", "Informática");
            categoriaProductos.Add(p4);

            CategoriaProductos p5 = new CategoriaProductos("5", "Smart TV");
            categoriaProductos.Add(p5);

            return categoriaProductos;
        }

        public List<Producto> DevolverListaProductosPorCategoria(string categoria)
        {
            ProductoPersistencia productoPersistencia = new ProductoPersistencia();
            List<Producto> listaProductos = new List<Producto>();
            if (categoria == "Audio")
            {
                listaProductos = productoPersistencia.obtenerProductosPorCategoria("1");
            }
            else if (categoria == "Celulares")
            {
                listaProductos = productoPersistencia.obtenerProductosPorCategoria("2");
            }
            else if (categoria == "Electro Hogar")
            {
                listaProductos = productoPersistencia.obtenerProductosPorCategoria("3");
            }
            else if (categoria == "Informática")
            {
                listaProductos = productoPersistencia.obtenerProductosPorCategoria("4");
            }
            else if (categoria == "Smart TV")
            {
                listaProductos = productoPersistencia.obtenerProductosPorCategoria("5");
            }
            List<Producto> listaProductosConStock = DevolverListaProductosConStock(listaProductos);
            return listaProductosConStock;
        }

        public List<Producto> DevolverListaProductosConStock(List<Producto> listaProductos)
        {
            List<Producto> listaProductosConStock = new List<Producto>();
            foreach (Producto producto in listaProductos)
            {
                if (producto.Stock > 0)
                {
                    listaProductosConStock.Add(producto);
                }
            }
            return listaProductosConStock;
        }

        public string ValidarSeleccionProducto(string cantidad, Producto productoSeleccionado)
        {

            string error = "";
            if (productoSeleccionado == null)
            {
                error = "No ha seleccionado ningun producto para agregar al carrito...";
            }
            else if (string.IsNullOrEmpty(cantidad))
            {
                error = "No ha ingresado ninguna cantidad del producto...";
            }
            else if (!int.TryParse(cantidad, out int cantidadInt))
            {
                error = "No ha ingresado una cantidad valida....";
            }
            else if (productoSeleccionado.Stock < cantidadInt)
            {
                error = "No puede ingresar esa cantidad ya que supera al stock actual...";
            }
            return error;
        }

        public int SumarSubTotal(int precio, string cantidad, string subTotal)
        {
            int cantidadInt = Convert.ToInt32(cantidad);
            int totalProductoSeleccionado = precio * cantidadInt;
            int subTotalInt = Convert.ToInt32(subTotal);
            subTotalInt += totalProductoSeleccionado;
            return subTotalInt;
        }

        public int DevolverTotal(int subTotal)
        {
            int total;
            if (subTotal > 1000000)
            {
                float descuento = subTotal * 0.15f;
                total = subTotal - Convert.ToInt32(descuento);
            }
            else
            {
                total = subTotal;
            }
            return total;
        }

        public ProductoCarrito DevolverProductoCarrito(Producto productoSeleccionado, string cantidad)
        {
            ProductoCarrito productoCarrito = new ProductoCarrito();
            productoCarrito.Id = productoSeleccionado.Id;
            productoCarrito.Nombre = productoSeleccionado.Nombre;
            productoCarrito.Precio = productoSeleccionado.Precio;
            productoCarrito.Cantidad = Convert.ToInt32(cantidad);
            return productoCarrito;
        }

        public int RestarSubTotal(int precio, int cantidad, string subTotal)
        {
            int totalProductoCarrito = precio * cantidad;
            int subTotalInt = Convert.ToInt32(subTotal);
            subTotalInt -= totalProductoCarrito;
            return subTotalInt;
        }

        public bool ValidarProductoCarrito(Producto productoSeleccionado, List<ProductoCarrito> productosCarrito)
        {

            foreach (ProductoCarrito productoCarrito in productosCarrito)
            {
                if (productoCarrito.Id == productoSeleccionado.Id)
                {
                    return true;
                }
            }
            return false;

        }
        public bool CargarVenta(Cliente cliente, List<ProductoCarrito> productosCarrito)
        {
            VentaPersistencia ventaPersistencia = new VentaPersistencia();
            List<Venta> productosVenta = new List<Venta>();
            foreach (ProductoCarrito productoCarrito in productosCarrito)
            {
                Venta venta = new Venta(productoCarrito.Id, productoCarrito.Cantidad, cliente.Id);
                productosVenta.Add(venta);
            }
            bool error = ventaPersistencia.AgregarVenta(productosVenta);
            return error;
        }

    }
}
