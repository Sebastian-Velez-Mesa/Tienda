using CNegocios;
using CEntidad;
using System;
using System.Web.UI;

namespace examen_
{
    public partial class Clientes : Page
    {
        protected global::System.Web.UI.WebControls.Label lblMensaje;
        CNClientes bll = new CNClientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null || Session["Rol"].ToString() != "Admin")
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        private void CargarClientes()
        {
            // Vinculacion de datos del GridView con la lista obtenida de la capa de negocios
            gvClientes.DataSource = bll.Listar();
            gvClientes.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Estructuramos el objeto Cliente con la informacion capturada
            CEClientes c = new CEClientes
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                Direccion = txtDireccion.Text
            };

            int res = 0;
            // Determinamos si es una actualización basándonos en la persistencia de la Sesión
            if (Session["EditIdCliente"] != null)
            {
                // Inyectamos el ID guardado durante el evento 'RowEditing'
                c.Id_Cliente = (int)Session["EditIdCliente"];
                res = bll.Actualizar(c);
                Session["EditIdCliente"] = null;
                btnGuardar.Text = "Guardar CEClientes";
            }
            else
            {
                // Si es un cliente nuevo, ejecutamos el metodo de insercion
                res = bll.Insertar(c);
            }

            if (res > 0)
            {
                lblMensaje.Text = "Operacion realizada con exito!";
                lblMensaje.CssClass = "text-success d-block mt-3";
                string script = "Swal.fire({ title: 'Exito', text: 'Operacion realizada con exito', icon: 'success', confirmButtonColor: '#00d2ff' });";
                ScriptManager.RegisterStartupScript(this, GetType(), "SwalSuccess", script, true);
                txtNombre.Text = "";
                txtTelefono.Text = "";
                txtEmail.Text = "";
                txtDireccion.Text = "";
                CargarClientes();
            }
            else
            {
                lblMensaje.Text = "Error al procesar el cliente.";
                lblMensaje.CssClass = "text-danger d-block mt-3";
            }
        }

        protected void gvClientes_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(gvClientes.DataKeys[e.NewEditIndex].Value);
            var cliente = bll.Listar().Find(c => c.Id_Cliente == id);
            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtTelefono.Text = cliente.Telefono;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
                
                btnGuardar.Text = "Actualizar CEClientes";
                Session["EditIdCliente"] = id;
            }
            e.Cancel = true;
        }

        protected void gvClientes_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gvClientes.DataKeys[e.RowIndex].Value);
                bll.Eliminar(id);
                CargarClientes();
                lblMensaje.Text = "CEClientes eliminado con exito.";
                lblMensaje.CssClass = "text-success d-block mt-3";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "No se puede eliminar: " + ex.Message;
                lblMensaje.CssClass = "text-danger d-block mt-3";
            }
        }
    }
}

