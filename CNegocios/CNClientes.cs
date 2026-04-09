using CDatos;
using CEntidad;
using System.Collections.Generic;

namespace CNegocios
{
    public class CNClientes
    {
        // Instancia de la capa de datos para gestion de la persistencia de clientes
        private CDClientes dal = new CDClientes();

        public List<CEClientes> Listar()
        {
            // Retorno directo de la coleccion generada en la capa de persistencia
            return dal.Listar();
        }

        public int Insertar(CEClientes cliente)
        {
            // Regla: No se permite registrar clientes sin un nombre comercial/personal
            if (string.IsNullOrEmpty(cliente.Nombre)) return 0;
            // Si la validacion es exitosa, se procede a guardar el registro
            return dal.Insertar(cliente);
        }

        public int Actualizar(CEClientes cliente)
        {
            // Validamos que el ID sea valido para una operacion de actualizacion
            if (cliente.Id_Cliente <= 0) return 0;
            // Validamos que el nombre no haya sido borrado accidentalmente en la edicion
            if (string.IsNullOrEmpty(cliente.Nombre)) return 0;
            // Ejecutamos la actualizacion via DAL
            return dal.Actualizar(cliente);
        }

        public int Eliminar(int idCliente)
        {
            // Validacion basica del ID antes de proceder con el borrado en la base de datos
            if (idCliente <= 0) return 0;
            return dal.Eliminar(idCliente);
        }
    }
}

