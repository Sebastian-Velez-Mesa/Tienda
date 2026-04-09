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
            // Logica de validacion basica: si alguno es nulo o vacio, no se procede
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                // Retornamos null para indicar que el intento de ingreso es invalido
                return null;
            }
            // Delegacion de la responsabilidad de busqueda a la Capa de Datos correspondientes
            // Se realiza la llamada al metodo Login del objeto DAL instanciado arriba
            return dal.Login(username, password);
        }
    }
}
