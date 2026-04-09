using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace examen_
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Este metodo se ejecuta cada vez que la pagina se carga en el navegador
        }

        // Evento que se dispara al presionar el boton de 'Salir' en la barra de navegacion
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Limpia todas las variables almacenadas en el objeto Session actual
            Session.Clear();
            // Finaliza la sesion actual del servidor de forma inmediata
            Session.Abandon();
            // Redirige al usuario de vuelta a la pantalla de Login tras cerrar sesion
            Response.Redirect("Login.aspx");
        }
    }
}
