using CEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CDatos
{
    public class CDClientes
    {
        public List<CEClientes> Listar()
        {
            // Lista para almacenar los resultados del mapeo de la base de datos
            List<CEClientes> lista = new List<CEClientes>();
            // Bloque using que garantiza la liberacion de la conexion al finalizar
            using (SqlConnection con = CDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT id_cliente, nombre, email, telefono, direccion FROM cliente", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    // Recorremos el flujo de resultados del DataReader fila por fila
                    while (dr.Read())
                    {
                        // Agregamos un nuevo objeto cliente mapeado desde el registro actual
                        lista.Add(new CEClientes
                        {
                            // Mapeo detallado de identificador y campos de contacto
                            Id_Cliente = Convert.ToInt32(dr["id_cliente"]),
                            Nombre = dr["nombre"].ToString(),
                            // El operador ?. previene excepciones nulas si el correo es opcional
                            Email = dr["email"]?.ToString(),
                            Telefono = dr["telefono"]?.ToString(),
                            Direccion = dr["direccion"]?.ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public int Insertar(CEClientes cliente)
        {
            // Variable de control para el exito de la operacion
            int resultado = 0;
            using (SqlConnection con = CDConexion.ObtenerConexion())
            {
                // Definicion de la sentencia SQL para insertar un nuevo registro en la tabla de clientes
                SqlCommand cmd = new SqlCommand("INSERT INTO cliente (nombre, email, telefono, direccion) VALUES (@nombre, @email, @telefono, @direccion)", con);
                // Vinculacion del parametro Nombre (obligatorio por diseno de tabla)
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                // Gestion de campos opcionales convirtiendo nulos de C# a DBNull de SQL
                cmd.Parameters.AddWithValue("@email", (object)cliente.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@telefono", (object)cliente.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@direccion", (object)cliente.Direccion ?? DBNull.Value);
                
                // Apertura manual de la conexion antes de la ejecucion
                con.Open();
                // Ejecutamos y capturamos la cantidad de filas persistidas (resultado > 0 es exito)
                resultado = cmd.ExecuteNonQuery();
            }
            return resultado;
        }

        public int Actualizar(CEClientes cliente)
        {
            int resultado = 0;
            using (SqlConnection con = CDConexion.ObtenerConexion())
            {
                // Comando UPDATE que requiere el ID para localizar la fila a modificar
                SqlCommand cmd = new SqlCommand("UPDATE cliente SET nombre=@nombre, email=@email, telefono=@telefono, direccion=@direccion WHERE id_cliente=@id_cliente", con);
                // Asignación de la clave primaria para el filtro WHERE
                cmd.Parameters.AddWithValue("@id_cliente", cliente.Id_Cliente);
                // Actualizacion de los campos editables
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@email", (object)cliente.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@telefono", (object)cliente.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@direccion", (object)cliente.Direccion ?? DBNull.Value);

                // Ejecutamos la actualizacion en el servidor SQL
                con.Open();
                resultado = cmd.ExecuteNonQuery();
            }
            return resultado;
        }

        public int Eliminar(int idCliente)
        {
            int resultado = 0;
            using (SqlConnection con = CDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM cliente WHERE id_cliente=@id_cliente", con);
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);

                con.Open();
                resultado = cmd.ExecuteNonQuery();
            }
            return resultado;
        }
    }
}

