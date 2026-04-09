using System;
using System.Web.UI;
using CNegocios;

namespace examen_
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificamos si es la primera carga de la pagina para evitar redirecciones infinitas
            if (!IsPostBack)
            {
                // Si el usuario ya tiene un rol activo en la sesion, lo enviamos al inicio
                if (Session["Rol"] != null)
                {
                    // La redireccion previene que un usuario ya logueado vea el formulario de login
                    Response.Redirect("Default.aspx");
                }
            }
        }

        // Metodo que se activa al hacer clic en el boton de ingreso
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Instanciamos el controlador de negocio para usuarios
                CNUsuarios bll = new CNUsuarios();
                // Capturamos y sanitizamos los campos de texto eliminando espacios laterales
                string userIn = txtUsername.Text.Trim();
                string passIn = txtPassword.Text.Trim();
                
                // Llamada a la Capa de Negocios para validar las credenciales del usuario
                var user = bll.Login(userIn, passIn);

                if (user != null)
                {
                    // Almacenamiento de informacion clave del usuario en la Sesion para persistencia global
                    Session["Username"] = user.Username;
                    // El rol definira que funcionalidades estaran visibles en la aplicacion
                    Session["Rol"] = user.Rol;
                    // Redireccion a la pagina principal tras una autenticacion exitosa
                    // El segundo parametro 'false' evita lanzar excepciones de fin de hilo
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    // Feedback visual en caso de que las credenciales no coincidan con la DB
                    lblMensaje.Text = "Usuario o contrasena incorrectos.";
                }
            }
            catch (Exception ex)
            {
                // Captura de errores inesperados (ej: perdida de conexion a DB)
                lblMensaje.Text = "Error interno: " + ex.Message;
            }
        }
    }
}
