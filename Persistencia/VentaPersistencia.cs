using Datos.Ventas;
using Newtonsoft.Json;
using Persistencia.WebService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class VentaPersistencia
    {
        public bool AgregarVenta(List<Venta> ventaProductos)
        {
            foreach (Venta venta in ventaProductos)
            {
                var jsonRequest = JsonConvert.SerializeObject(venta);

                HttpResponseMessage response = WebHelper.Post("/api/Venta/AgregarVenta", jsonRequest);

                if (!response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
