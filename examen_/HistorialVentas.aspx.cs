using CNegocios;
using System;
using System.Web.UI;

namespace examen_
{
    public partial class HistorialVentas : Page
    {
        CNVentas bll = new CNVentas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null || Session["Rol"].ToString() != "Admin")
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                CargarHistorial();
            }
        }

        private void CargarHistorial()
        {
            gvHistorial.DataSource = bll.Listar();
            gvHistorial.DataBind();
        }
    }
}

