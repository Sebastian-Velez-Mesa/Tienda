using CEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CDatos
{
    public class CDProductos
    {
        public List<CEProductos> Listar()
        {
            // Coleccion que almacenara todos los productos recuperados de la base de datos
            List<CEProductos> lista = new List<CEProductos>();
            // Bloque using para asegurar el cierre automatico de la conexion y liberar memoria
            using (SqlConnection con = CDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT id_producto, nombre, precio, stock, categoria FROM producto", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new CEProductos
                        {
                            Id_Producto = Convert.ToInt32(dr["id_producto"]),
                            Nombre = dr["nombre"].ToString(),
                            Precio = Convert.ToDecimal(dr["precio"]),
                            Stock = Convert.ToInt32(dr["stock"]),
                            Categoria = dr["categoria"]?.ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public int Insertar(CEProductos producto)
        {
            // Variable para verificar si la operacion fue exitosa en la base de datos
            int resultado = 0;
            using (SqlConnection con = CDConexion.ObtenerConexion())
            {
                // Definicion del INSERT con los campos requeridos por la tabla producto
                SqlCommand cmd = new SqlCommand("INSERT INTO producto (nombre, precio, stock, categoria) VALUES (@nombre, @precio, @stock, @categoria)", con);
                // Mapeo seguro del nombre del producto
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                
                // Configuracion explicita del parametro Decimal para asegurar precision y escala correctas
                SqlParameter pPrecio = new SqlParameter("@precio", SqlDbType.Decimal);
                pPrecio.Precision = 10;
                pPrecio.Scale = 2;
                pPrecio.Value = producto.Precio;
                cmd.Parameters.Add(pPrecio);

                // Mapeo del stock y la categoria (con manejo de nulos)
                cmd.Parameters.AddWithValue("@stock", producto.Stock);
                cmd.Parameters.AddWithValue("@categoria", (object)producto.Categoria ?? DBNull.Value);
                
                // Apertura de conexion y ejecucion del comando de accion
                con.Open();
                resultado = cmd.ExecuteNonQuery();
            }
            return resultado;
        }

        // Metodo para actualizar datos de un producto existente usando su ID unico
        public int Actualizar(CEProductos producto)
        {
            int resultado = 0;
            using (SqlConnection con = CDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("UPDATE producto SET nombre = @nombre, precio = @precio, stock = @stock, categoria = @categoria WHERE id_producto = @id_producto", con);
                cmd.Parameters.AddWithValue("@id_producto", producto.Id_Producto);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                
                SqlParameter pPrecio = new SqlParameter("@precio", SqlDbType.Decimal);
                pPrecio.Precision = 10;
                pPrecio.Scale = 2;
                pPrecio.Value = producto.Precio;
                cmd.Parameters.Add(pPrecio);

                cmd.Parameters.AddWithValue("@stock", producto.Stock);
                cmd.Parameters.AddWithValue("@categoria", (object)producto.Categoria ?? DBNull.Value);
                
                con.Open();
                resultado = cmd.ExecuteNonQuery();
            }
            return resultado;
        }

        public int Eliminar(int idProducto)
        {
            // Ejecucion de borrado fisico en la base de datos
            int resultado = 0;
            using (SqlConnection con = CDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM producto WHERE id_producto = @id_producto", con);
                cmd.Parameters.AddWithValue("@id_producto", idProducto);
                
                con.Open();
                resultado = cmd.ExecuteNonQuery();
            }
            return resultado;
        }
    }
}

