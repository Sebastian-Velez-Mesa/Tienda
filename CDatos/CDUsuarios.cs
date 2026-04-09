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
                // Parametro para el nombre de usuario (limpio y seguro)
                cmd.Parameters.AddWithValue("@username", username);
                // Parametro para la contrasena (mapeado de forma directa para comparacion)
                cmd.Parameters.AddWithValue("@password", password);
                // Especificamos que se trata de una consulta de texto plano
                cmd.CommandType = CommandType.Text;
                
                // Establece la conexion con el servidor de base de datos
                con.Open();
                // ExecuteReader devuelve un flujo de datos optimizado para una sola lectura
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    // Intentamos leer el primer registro devuelto por la consulta
                    if (dr.Read())
                    {
                        // Instanciamos el objeto con los datos obtenidos de la fila leida
                        usuario = new CEUsuarios
                        {
                            // Conversion explicita a entero para el identificador de usuario
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            // Casting o conversion a string para el nombre de usuario
                            Username = dr["Username"].ToString(),
                            // Recuperacion de la contrasena almacenada en la DB
                            Password = dr["Password"].ToString(),
                            // Asignacion del rol (Admin o Cliente) para control de acceso
                            Rol = dr["Rol"].ToString()
                        };
                    }
                }
            }
            return usuario;
        }
    }
}
