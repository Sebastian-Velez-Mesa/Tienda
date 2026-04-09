using System;
using System.Collections.Generic;

namespace CEntidad
{
    public class CEVentas
    {
        public int Id_Venta { get; set; }
        public int Id_Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        
        public CEClientes CEClientes { get; set; }
        public List<CEDetalleVentas> Detalles { get; set; }

        public CEVentas()
        {
            Detalles = new List<CEDetalleVentas>();
        }
    }
}

