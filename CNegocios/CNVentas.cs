using CDatos;
using CEntidad;

namespace CNegocios
{
    public class CNVentas
    {
        private CDVentas dal = new CDVentas();

        public int RegistrarVenta(CEVentas venta)
        {
            // Validacion de requisitos minimos: cliente asignado y al menos un producto en el carrito
            if (venta.Id_Cliente <= 0 || venta.Detalles.Count == 0) return 0;
            
            // Calculo dinamico del total acumulado recorriendo cada item del detalle
            decimal totalCalculado = 0;
            foreach (var det in venta.Detalles)
            {
                // Seguridad: no se permiten productos con cantidad negativa o cero
                if (det.Cantidad <= 0) return 0;
                // Sumatoria del subtotal (precio * cantidad) de cada item
                totalCalculado += (det.Precio_Unitario * det.Cantidad);
            }
            // Asignamos el total final a la entidad antes de enviarla a la base de datos
            venta.Total = totalCalculado;
            
            return dal.RegistrarVenta(venta);
        }

        public System.Data.DataTable Listar()
        {
            return dal.Listar();
        }
    }
}

