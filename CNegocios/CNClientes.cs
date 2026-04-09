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
            return dal.Listar();
        }

        public int Insertar(CEClientes cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nombre)) return 0;
            return dal.Insertar(cliente);
        }

        public int Actualizar(CEClientes cliente)
        {
            if (cliente.Id_Cliente <= 0) return 0;
            if (string.IsNullOrEmpty(cliente.Nombre)) return 0;
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

