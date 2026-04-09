using CDatos;
using CEntidad;
using System.Collections.Generic;

namespace CNegocios
{
    public class CNProductos
    {
        // Enlace directo con la Capa de Datos para persistencia de informacion
        private CDProductos dal = new CDProductos();

        // Metodo que sirve como pasarela hacia la lista global de productos
        public List<CEProductos> Listar()
        {
            return dal.Listar();
        }

        // Valida la integridad del producto antes de solicitar la insercion en datos
        public int Insertar(CEProductos producto)
        {
            if (producto.Precio <= 0) return 0;
            if (string.IsNullOrEmpty(producto.Nombre)) return 0;
            return dal.Insertar(producto);
        }

        // Orquesta la actualizacion tras validar que el ID y precio sean correctos
        public int Actualizar(CEProductos producto)
        {
            if (producto.Id_Producto <= 0) return 0;
            if (producto.Precio <= 0) return 0;
            return dal.Actualizar(producto);
        }

        // Gestiona la eliminacion delegando el ID validado a la capa DAL
        public int Eliminar(int idProducto)
        {
            return dal.Eliminar(idProducto);
        }
    }
}

