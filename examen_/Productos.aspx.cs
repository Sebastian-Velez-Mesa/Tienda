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
            gvProductos.DataSource = bll.Listar();
            gvProductos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal precio = string.IsNullOrEmpty(txtPrecio.Text) ? 0 : Convert.ToDecimal(txtPrecio.Text);
                if (precio > 99999999.99m)
                {
                    lblMensaje.Text = "El precio es demasiado alto (max 99,999,999.99)";
                    lblMensaje.CssClass = "text-danger d-block mt-3";
                    return;
                }

                // Creamos la instancia de la entidad Producto
                CEProductos p = new CEProductos
                {
                    // Asignamos el nombre directamente desde el TextBox
                    Nombre = txtNombre.Text,
                    // El precio se valida previamente para asegurar que este en el rango decimal de SQL
                    Precio = precio,
                    // Convertimos el stock a entero (si esta vacio se asigna 0)
                    Stock = string.IsNullOrEmpty(txtStock.Text) ? 0 : Convert.ToInt32(txtStock.Text),
                    // Asignamos la categoria (opcional)
                    Categoria = txtCategoria.Text
                };

                int res = 0;
                // Verificamos si la sesion indica que estamos editando un producto existente
                if (Session["EditId"] != null)
                {
                    // Recuperamos el ID original para que SQL sepa cual registro actualizar
                    p.Id_Producto = (int)Session["EditId"];
                    res = bll.Actualizar(p);
                    // Limpiamos la variable de edicion tras el guardado
                    Session["EditId"] = null;
                    btnGuardar.Text = "Guardar CEProductos";
                }
                else
                {
                    // Si no hay ID en sesion, se procede como una nueva insercion
                    res = bll.Insertar(p);
                }

                if (res > 0)
                {
                    lblMensaje.Text = "Operacion realizada con exito!";
                    lblMensaje.CssClass = "text-success d-block mt-3";
                    string script = "Swal.fire({ title: 'Exito', text: 'Operacion realizada con exito', icon: 'success', confirmButtonColor: '#00d2ff' });";
                    ScriptManager.RegisterStartupScript(this, GetType(), "SwalSuccess", script, true);
                    txtNombre.Text = "";
                    txtPrecio.Text = "";
                    txtStock.Text = "";
                    txtCategoria.Text = "";
                    CargarProductos();
                }
                else
                {
                    lblMensaje.Text = "Error al procesar el producto.";
                    lblMensaje.CssClass = "text-danger d-block mt-3";
                }
            }
            catch (Exception ex)
            {
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

