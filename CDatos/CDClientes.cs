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
                    while (dr.Read())
                    {
                        lista.Add(new CEClientes
                        {
                            Id_Cliente = Convert.ToInt32(dr["id_cliente"]),
                            Nombre = dr["nombre"].ToString(),
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
                // Asignacion de parametros utilizando placeholders para neutralizar inyecciones SQL
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                // Se utiliza DBNull.Value en campos opcionales para manejar correctamente los nulos en SQL
                cmd.Parameters.AddWithValue("@email", (object)cliente.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@telefono", (object)cliente.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@direccion", (object)cliente.Direccion ?? DBNull.Value);
                
                // Abrimos la conexion antes de ejecutar el comando
                con.Open();
                // Ejecuta la sentencia y captura el numero de filas afectadas (habitualmente 1)
                resultado = cmd.ExecuteNonQuery();
            }
            return resultado;
        }

        public int Actualizar(CEClientes cliente)
        {
            int resultado = 0;
            using (SqlConnection con = CDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("UPDATE cliente SET nombre=@nombre, email=@email, telefono=@telefono, direccion=@direccion WHERE id_cliente=@id_cliente", con);
                cmd.Parameters.AddWithValue("@id_cliente", cliente.Id_Cliente);
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@email", (object)cliente.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@telefono", (object)cliente.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@direccion", (object)cliente.Direccion ?? DBNull.Value);

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

