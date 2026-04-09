using CEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CDatos
{
    public class CDVentas
    {
        public int RegistrarVenta(CEVentas venta)
        {
            // Variable para almacenar el ID autogenerado tras la insercion de la cabecera
            int idVentaGenerado = 0;
            using (SqlConnection con = CDConexion.ObtenerConexion())
            {
                con.Open();
                // Inicio de una transaccion SQL para asegurar la atomicidad de la venta y el ajuste de stock
                using (SqlTransaction tr = con.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar la cabecera de la venta y recuperar el ID generado con OUTPUT INSERTED
                        SqlCommand cmdVenta = new SqlCommand("INSERT INTO venta (id_cliente, fecha, total) OUTPUT INSERTED.id_venta VALUES (@id_cliente, @fecha, @total)", con, tr);
                        // Pasamos el ID del cliente que realiza la compra
                        cmdVenta.Parameters.AddWithValue("@id_cliente", venta.Id_Cliente);
                        // Capturamos la fecha actual en la que se procesa la operacion
                        cmdVenta.Parameters.AddWithValue("@fecha", venta.Fecha);
                        // Almacenamos el monto final calculado previamente en la capa BLL
                        cmdVenta.Parameters.AddWithValue("@total", venta.Total);
                        
                        // ExecuteScalar ejecuta la consulta y devuelve la primera columna de la primera fila (id_venta)
                        idVentaGenerado = (int)cmdVenta.ExecuteScalar();
                        
                        // 2. Iteracion sobre los detalles para insercion de productos y actualizacion de inventario
                        foreach (CEDetalleVentas detalle in venta.Detalles)
                        {
                            // Se crea el comando para insertar el renglon del detalle asociado a la venta principal
                            SqlCommand cmdDetalle = new SqlCommand("INSERT INTO detalle_venta (id_venta, id_producto, cantidad, precio_unitario) VALUES (@id_venta, @id_producto, @cantidad, @precio_unitario)", con, tr);
                            cmdDetalle.Parameters.AddWithValue("@id_venta", idVentaGenerado);
                            cmdDetalle.Parameters.AddWithValue("@id_producto", detalle.Id_Producto);
                            cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdDetalle.Parameters.AddWithValue("@precio_unitario", detalle.Precio_Unitario);
                            // Se ejecuta el insert del detalle
                            cmdDetalle.ExecuteNonQuery();
                            
                            // Comando critico para reducir el inventario disponible del producto vendido
                            SqlCommand cmdStock = new SqlCommand("UPDATE producto SET stock = stock - @cantidad WHERE id_producto = @id_producto", con, tr);
                            // Definimos cuanto se resta y a que producto especifico
                            cmdStock.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdStock.Parameters.AddWithValue("@id_producto", detalle.Id_Producto);
                            // Se ejecuta la actualizacion del stock dentro de la misma transaccion
                            cmdStock.ExecuteNonQuery();
                        }
                        
                        // Si todas las operaciones fueron exitosas, se confirman los cambios en la base de datos
                        tr.Commit();
                    }
                    catch (Exception)
                    {
                        // En caso de error, se deshacen todos los cambios (rollback) para mantener la integridad
                        tr.Rollback();
                        idVentaGenerado = 0;
                        throw;
                    }
                }
            }
            return idVentaGenerado;
        }

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = CDConexion.ObtenerConexion())
            {
                string query = "SELECT v.id_venta, c.nombre as cliente, v.fecha, v.total " +
                               "FROM venta v INNER JOIN cliente c ON v.id_cliente = c.id_cliente " +
                               "ORDER BY v.id_venta DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}

