using Datos.Ventas;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public partial class FormOperador : Form
    {
        public FormOperador()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {

            CargarClientes();
            CargarCategoriasProductos();
            IniciarTotales();
        }

        private void IniciarTotales()
        {
            lblSubTotal.Text = "0";
            lblTotal.Text = "0";
        }

        private void CargarCategoriasProductos()
        {

            VentasNegocio ventasNegocio = new VentasNegocio();

            List<CategoriaProductos> categoriaProductos = ventasNegocio.obtenerCategoriaProductos();

            foreach (CategoriaProductos categoriaProducto in categoriaProductos)
            {
                cboCategoriaProductos.Items.Add(categoriaProducto);
            }
        }

        private void CargarClientes()
        {
            VentasNegocio ventasNegocio = new VentasNegocio();

            List<Cliente> listadoClientes = ventasNegocio.obtenerClientes();

            foreach (Cliente cliente in listadoClientes)
            {
                cmbClientes.Items.Add(cliente);
            }
        }

        private void btnListarProductos_Click(object sender, EventArgs e)
        {
            VentasNegocio ventasNegocio = new VentasNegocio();
            if (cboCategoriaProductos.SelectedItem != null)
            {
                string categoria = cboCategoriaProductos.SelectedItem.ToString();
                List<Producto> listaProductos = ventasNegocio.DevolverListaProductosPorCategoria(categoria);
                foreach (Producto producto in listaProductos)
                {
                    lstProducto.Items.Add(producto);
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna opcion de categoria de productos...");
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            VentasNegocio ventasNegocio = new VentasNegocio();
            if (ValidacionesAgregarCarrito() == false)
            {
                Producto productoSeleccionado = (Producto)lstProducto.SelectedItem;
                SumarTotales(productoSeleccionado.Precio);
                ProductoCarrito productoCarrito = ventasNegocio.DevolverProductoCarrito(productoSeleccionado, txtCantidad.Text);
                lstCarrito.Items.Add(productoCarrito);
                MessageBox.Show("Se ha agregado con exito el producto al carrito!");
            }
        }

        public void SumarTotales(int precio)
        {
            VentasNegocio ventasNegocio = new VentasNegocio();
            int subTotal = ventasNegocio.SumarSubTotal(precio, txtCantidad.Text, lblSubTotal.Text);
            lblSubTotal.Text = subTotal.ToString();
            int total = ventasNegocio.DevolverTotal(subTotal);
            lblTotal.Text = total.ToString();
        }

        public bool ValidacionesAgregarCarrito()
        {
            bool error = false;
            VentasNegocio ventasNegocio = new VentasNegocio();
            string errorSeleccionProducto = ventasNegocio.ValidarSeleccionProducto(txtCantidad.Text, (Producto)lstProducto.SelectedItem);
            List<ProductoCarrito> productosCarrito = DevolverProductosCarrito();
            if (errorSeleccionProducto != "")
            {
                MessageBox.Show(errorSeleccionProducto);
                error = true;
            }
            else if (cmbClientes.SelectedItem == null)
            {
                MessageBox.Show("No ha seleccionado ningun cliente...");
                error = true;
            }
            else if (ventasNegocio.ValidarProductoCarrito((Producto)lstProducto.SelectedItem, productosCarrito) == true)
            {
                MessageBox.Show("El producto seleccionado ya se encuentra en el carrito...");
                error = true;
            }
            return error;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (lstCarrito.SelectedItem == null)
            {
                MessageBox.Show("No ha seleccionado ninguna producto del carrito...");
            }
            else
            {
                ProductoCarrito productoCarrito = (ProductoCarrito)lstCarrito.SelectedItem;
                RestarTotales(productoCarrito.Precio, productoCarrito.Cantidad);
                lstCarrito.Items.Remove(productoCarrito);
                MessageBox.Show("Se ha eliminado con exito el producto del carrito!");
            }
        }

        public void RestarTotales(int precio, int cantidad)
        {
            VentasNegocio ventasNegocio = new VentasNegocio();
            int subTotal = ventasNegocio.RestarSubTotal(precio, cantidad, lblSubTotal.Text);
            lblSubTotal.Text = subTotal.ToString();
            int total = ventasNegocio.DevolverTotal(subTotal);
            lblTotal.Text = total.ToString();
        }


        private void btnCargar_Click(object sender, EventArgs e)
        {
            VentasNegocio ventasNegocio = new VentasNegocio();
            if (lstCarrito.Items.Count == 0)
            {
                MessageBox.Show("Error, no puede cargar la venta ya que no hay productos en el carrito...");
            }
            else
            {
                List<ProductoCarrito> productosCarrito = DevolverProductosCarrito();
                if (ventasNegocio.CargarVenta((Cliente)cmbClientes.SelectedItem, productosCarrito) == false)
                {
                    MessageBox.Show("Se ha cargado con exito la venta!");
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al momento de cargar la venta...");
                }
                lstCarrito.Items.Clear();
            }
        }

        public List<ProductoCarrito> DevolverProductosCarrito()
        {
            List<ProductoCarrito> productosCarrito = new List<ProductoCarrito>();
            foreach (ProductoCarrito producto in lstCarrito.Items)
            {
                productosCarrito.Add(producto);
            }
            return productosCarrito;
        }
    }

}
