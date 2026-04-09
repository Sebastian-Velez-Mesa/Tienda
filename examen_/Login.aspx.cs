using System;
using System.Web.UI;
using CNegocios;

namespace examen_
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Rol"] != null)
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        // Metodo que se activa al hacer clic en el boton de ingreso
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                CNUsuarios bll = new CNUsuarios();
                // Llamada a la Capa de Negocios para validar las credenciales del usuario
                var user = bll.Login(txtUsername.Text.Trim(), txtPassword.Text.Trim());

                if (user != null)
                {
                    // Almacenamiento de informacion clave del usuario en la Sesion para persistencia global
                    Session["Username"] = user.Username;
                    Session["Rol"] = user.Rol;
                    // Redireccion a la pagina principal tras una autenticacion exitosa
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    lblMensaje.Text = "Usuario o contrasena incorrectos.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error interno: " + ex.Message;
            }
        }
    }
}
