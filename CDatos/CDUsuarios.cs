using CEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CDatos
{
    public class CDUsuarios
    {
        public CEUsuarios Login(string username, string password)
        {
            // Entidad que contendra los resultados, se inicializa en null por si no hay coincidencias
            CEUsuarios usuario = null;
            // Bloque using para asegurar que la conexion se cierre y libere recursos al terminar el proceso
            using (SqlConnection con = CDConexion.ObtenerConexion())
            {
                // Definicion de la consulta SELECT filtrando por credenciales de usuario
                SqlCommand cmd = new SqlCommand("SELECT IdUsuario, Username, Password, Rol FROM Usuario WHERE Username=@username AND Password=@password", con);
                // Parametros que sustituyen los placeholders por los valores reales del usuario
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.CommandType = CommandType.Text;
                
                // Establece la conexion con el servidor de base de datos
                con.Open();
                // ExecuteReader devuelve un flujo de datos optimizado para una sola lectura
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    // Intentamos leer el primer registro devuelto por la consulta
                    if (dr.Read())
                    {
                        // Instanciamos la entidad y mapeamos las columnas a sus propiedades respectivas
                        usuario = new CEUsuarios
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            Username = dr["Username"].ToString(),
                            Password = dr["Password"].ToString(),
                            Rol = dr["Rol"].ToString()
                        };
                    }
                }
            }
            return usuario;
        }
    }
}
