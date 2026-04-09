using CDatos;
using CEntidad;

namespace CNegocios
{
    public class CNUsuarios
    {
        // Instancia de la Capa de Datos para delegar las operaciones de persistencia
        private CDUsuarios dal = new CDUsuarios();

        // Metodo de negocio para validar el ingreso, actua como intermediario entre la UI y el DAL
        public CEUsuarios Login(string username, string password)
        {
            // Logica de validacion basica antes de intentar la comunicacion con la base de datos
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            // Delegacion de la responsabilidad de busqueda a la Capa de Datos correspondientes
            return dal.Login(username, password);
        }
    }
}
