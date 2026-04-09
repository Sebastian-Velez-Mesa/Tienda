using CNegocios;
using CEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace examen_
{
    public partial class Ventas : Page
    {
        CNClientes clienteBLL = new CNClientes();
        CNProductos productoBLL = new CNProductos();
        CNVentas ventaBLL = new CNVentas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                CargarCombos();
                Session["Carrito"] = new List<CECarritoItems>();
            }
        }

        private void CargarCombos()
        {
            ddlClientes.DataSource = clienteBLL.Listar();
            ddlClientes.DataValueField = "Id_Cliente";
            ddlClientes.DataTextField = "Nombre";
            ddlClientes.DataBind();

            ddlProductos.DataSource = productoBLL.Listar();
            ddlProductos.DataValueField = "Id_Producto";
            ddlProductos.DataTextField = "Nombre";
            ddlProductos.DataBind();
        }

        // Maneja la adicion de productos al carrito temporal almacenado en la Sesion
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtenemos los valores de entrada desde los controles del formulario
            int idProd = Convert.ToInt32(ddlProductos.SelectedValue);
            int cant = Convert.ToInt32(txtCantidad.Text);
            
            // Buscamos el producto en la lista para validar el stock disponible
            var prod = productoBLL.Listar().FirstOrDefault(p => p.Id_Producto == idProd);
            if (prod != null)
            {
                // Verificacion de inventario antes de permitir la adicion al carrito
                if (prod.Stock < cant)
                {
                    lblMensaje.Text = $"Stock insuficiente. Disponibles: {prod.Stock}";
                    lblMensaje.CssClass = "text-warning d-block text-end";
                    return;
                }

                // Recuperamos el carrito actual de la sesion del usuario
                var carrito = (List<CECarritoItems>)Session["Carrito"];
                decimal subtotal = prod.Precio * cant;
                
                // Agregamos una nueva linea de detalle al carrito temporal
                carrito.Add(new CECarritoItems {
                    Id_Producto = prod.Id_Producto,
                    Nombre = prod.Nombre,
                    Cantidad = cant,
                    Precio_Unitario = prod.Precio,
                    Subtotal = subtotal
                });
                
                // Actualizamos la sesion y refrescamos la grilla
                Session["Carrito"] = carrito;
                ActualizarCarrito();
                lblMensaje.Text = "";
            }
        }

        private void ActualizarCarrito()
        {
            var carrito = (List<CECarritoItems>)Session["Carrito"];
            gvCarrito.DataSource = carrito;
            gvCarrito.DataBind();
            lblTotal.Text = carrito.Sum(c => c.Subtotal).ToString("0.00");
        }

        // Procesa la venta definitiva persistiendo la cabecera y el detalle en la base de datos
        protected void btnProcesarVenta_Click(object sender, EventArgs e)
        {
            // Validacion: no se permite procesar ventas si no hay productos seleccionados
            var carrito = (List<CECarritoItems>)Session["Carrito"];
            if (carrito == null || carrito.Count == 0)
            {
                lblMensaje.Text = "El carrito esta vacio.";
                lblMensaje.CssClass = "text-warning d-block text-end";
                return;
            }

            // Creamos la cabecera de la venta con los datos del cliente seleccionado
            CEVentas v = new CEVentas
            {
                Id_Cliente = Convert.ToInt32(ddlClientes.SelectedValue),
                // Se asigna la estampa de tiempo del servidor
                Fecha = DateTime.Now
            };

            // Mapeamos los items del carrito a la lista de detalles de la entidad de venta
            foreach (var item in carrito)
            {
                v.Detalles.Add(new CEDetalleVentas
                {
                    Id_Producto = item.Id_Producto,
                    Cantidad = item.Cantidad,
                    Precio_Unitario = item.Precio_Unitario
                });
            }

            // Llamada transaccional a la capa de negocios
            int idx = ventaBLL.RegistrarVenta(v);
            if (idx > 0)
            {
                // Mensaje en pantalla y disparo de popup estetico SweetAlert
                lblMensaje.Text = "CEVentas registrada con exito!";
                lblMensaje.CssClass = "text-success d-block text-end";
                string script = "Swal.fire({ title: 'Exito', text: 'Venta registrada correctamente', icon: 'success', confirmButtonColor: '#00d2ff' });";
                ScriptManager.RegisterStartupScript(this, GetType(), "SwalSuccess", script, true);
                
                // Reseteamos el carrito tras la venta exitosa
                Session["Carrito"] = new List<CECarritoItems>();
                ActualizarCarrito();
            }
            else
            {
                lblMensaje.Text = "Error al registrar la venta.";
                lblMensaje.CssClass = "text-danger d-block text-end";
            }
        }
    }
}

