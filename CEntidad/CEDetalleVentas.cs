using System;

namespace CEntidad
{
    public class CEDetalleVentas
    {
        public int Id_Detalle { get; set; }
        public int Id_Venta { get; set; }
        public int Id_Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_Unitario { get; set; }

        public CEProductos CEProductos { get; set; }
    }
}

