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
                // Esta validacion previene errores de logica que podrian 'sumar' stock en lugar de restar
                if (det.Cantidad <= 0) return 0;
                // Sumatoria del subtotal (precio * cantidad) de cada item de la lista
                totalCalculado += (det.Precio_Unitario * det.Cantidad);
            }
            // Asignamos el total final a la entidad antes de enviarla a la capa de datos
            // Esto asegura que la base de datos almacene el monto verificado por negocio
            venta.Total = totalCalculado;
            
            // Invocamos el metodo transaccional del DAL para persistir la operacion completa
            return dal.RegistrarVenta(venta);
        }

        public System.Data.DataTable Listar()
        {
            // Pasarela simple para exponer las ventas registradas a la interfaz de usuario
            return dal.Listar();
        }
    }
}

