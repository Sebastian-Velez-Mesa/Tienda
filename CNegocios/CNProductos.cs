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
            // Retornamos directamente lo que la capa de datos (DAL) recupera de SQL
            return dal.Listar();
        }

        // Valida la integridad del producto antes de solicitar la insercion en datos
        public int Insertar(CEProductos producto)
        {
            // Regla de Negocio: Se impide registrar productos con precio gratuito o negativo
            if (producto.Precio <= 0) return 0;
            // Regla de Negocio: El nombre es obligatorio para cualquier producto
            if (string.IsNullOrEmpty(producto.Nombre)) return 0;
            // Una vez superadas las validaciones, se envia la entidad a la Capa de Datos
            return dal.Insertar(producto);
        }

        // Orquesta la actualizacion tras validar que el ID y precio sean correctos
        public int Actualizar(CEProductos producto)
        {
            // Validacion: Garantizamos que el producto tenga un ID positivo (registro existente)
            if (producto.Id_Producto <= 0) return 0;
            // Validacion: Mantenemos la consistencia del precio minimo aceptado
            if (producto.Precio <= 0) return 0;
            // Si todo esta en orden, delegamos la persistencia al metodo de actualizacion del DAL
            return dal.Actualizar(producto);
        }

        // Gestiona la eliminacion delegando el ID validado a la capa DAL
        public int Eliminar(int idProducto)
        {
            // Aqui podrian agregarse validaciones extra (ej: no eliminar si tiene ventas asociadas)
            return dal.Eliminar(idProducto);
        }
    }
}

