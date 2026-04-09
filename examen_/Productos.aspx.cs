using CNegocios;
using CEntidad;
using System;
using System.Web.UI;

namespace examen_
{
    public partial class Productos : Page
    {
        protected global::System.Web.UI.WebControls.Label lblMensaje;
        CNProductos bll = new CNProductos();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Validacion de seguridad: solo el rol 'Admin' puede acceder a la gestion de productos
            if (Session["Rol"] == null || Session["Rol"].ToString() != "Admin")
            {
                Response.Redirect("Login.aspx");
            }
            // Garantiza que la carga inicial de datos solo ocurra la primera vez (no en postbacks)
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            // Asignamos la lista de objetos recuperada del BLL como origen de datos del GridView
            gvProductos.DataSource = bll.Listar();
            // Ejecutamos la vinculacion para transformar los datos en filas HTML
            gvProductos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Conversion del texto de precio a decimal, manejando vacios como 0
                decimal precio = string.IsNullOrEmpty(txtPrecio.Text) ? 0 : Convert.ToDecimal(txtPrecio.Text);
                // Validacion de rango para evitar desbordamiento en la columna Decimal(10,2) de SQL
                if (precio > 99999999.99m)
                {
                    lblMensaje.Text = "El precio es demasiado alto (max 99,999,999.99)";
                    lblMensaje.CssClass = "text-danger d-block mt-3";
                    return;
                }

                // Poblamiento de la entidad con los valores sanitizados de la interfaz
                CEProductos p = new CEProductos
                {
                    Nombre = txtNombre.Text,
                    Precio = precio,
                    // Conversion segura del stock
                    Stock = string.IsNullOrEmpty(txtStock.Text) ? 0 : Convert.ToInt32(txtStock.Text),
                    Categoria = txtCategoria.Text
                };

                int res = 0;
                // Logica de decision: ¿Actualizar un registro viejo o insertar uno nuevo?
                if (Session["EditId"] != null)
                {
                    // Modo edicion: Recuperamos el ID tecnico almacenado en la sesion del servidor
                    p.Id_Producto = (int)Session["EditId"];
                    res = bll.Actualizar(p);
                    // Importante: Limpiar el ID de edicion tras el guardado exitoso
                    Session["EditId"] = null;
                    // Restauramos el texto original del boton de accion
                    btnGuardar.Text = "Guardar CEProductos";
                }
                else
                {
                    // Modo insercion: Delegamos la creacion a la capa de negocios
                    res = bll.Insertar(p);
                }

                if (res > 0)
                {
                    // Mostramos mensaje de exito en un Label y via Popup SweetAlert2
                    lblMensaje.Text = "Operacion realizada con exito!";
                    lblMensaje.CssClass = "text-success d-block mt-3";
                    string script = "Swal.fire({ title: 'Exito', text: 'Operacion realizada con exito', icon: 'success', confirmButtonColor: '#00d2ff' });";
                    // Inyectamos el script de JavaScript en el cliente desde el servidor
                    ScriptManager.RegisterStartupScript(this, GetType(), "SwalSuccess", script, true);
                    
                    // Limpieza de campos para permitir una nueva entrada de datos
                    txtNombre.Text = "";
                    txtPrecio.Text = "";
                    txtStock.Text = "";
                    txtCategoria.Text = "";
                    // Refrescamos la tabla de productos para mostrar los cambios
                    CargarProductos();
                }
                else
                {
                    // Feedback en caso de que la capa de datos devuelva un error silencioso
                    lblMensaje.Text = "Error al procesar el producto.";
                    lblMensaje.CssClass = "text-danger d-block mt-3";
                }
            }
            catch (Exception ex)
            {
                // Gestion global de excepciones para evitar que la aplicacion explote en el cliente
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.CssClass = "text-danger d-block mt-3";
            }
        }

        protected void gvProductos_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            // Para simplificar vamos a cargar los datos en los campos de arriba para "editar"
            int id = Convert.ToInt32(gvProductos.DataKeys[e.NewEditIndex].Value);
            var prod = bll.Listar().Find(p => p.Id_Producto == id);
            if (prod != null)
            {
                txtNombre.Text = prod.Nombre;
                txtPrecio.Text = prod.Precio.ToString();
                txtStock.Text = prod.Stock.ToString();
                txtCategoria.Text = prod.Categoria;
                
                // Cambiamos el texto del boton
                btnGuardar.Text = "Actualizar CEProductos";
                Session["EditId"] = id;
            }
            e.Cancel = true; // Evitamos el modo edicion interno del grid
        }

        protected void gvProductos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gvProductos.DataKeys[e.RowIndex].Value);
                bll.Eliminar(id);
                CargarProductos();
                lblMensaje.Text = "CEProductos eliminado con exito.";
                lblMensaje.CssClass = "text-success d-block mt-3";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar: " + ex.Message;
                lblMensaje.CssClass = "text-danger d-block mt-3";
            }
        }
    }
}

