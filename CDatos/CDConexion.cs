using System.Configuration;
using System.Data.SqlClient;

namespace CDatos
{
    public class CDConexion
    {
        public static SqlConnection ObtenerConexion()
        {
            // Accedemos al administrador de configuracion para buscar la cadena de conexion
            string strConexion = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            // Creamos e instanciamos el objeto de conexion de SQL Client
            return new SqlConnection(strConexion);
        }
    }
}

