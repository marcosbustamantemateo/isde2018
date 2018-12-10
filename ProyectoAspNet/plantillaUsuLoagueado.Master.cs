using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAspNet
{
    public partial class plantillaUsuLoagueado : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["nombreUsuario"] == null) && (Session["tipoUsuario"] == null))
                Response.Redirect("login.aspx?mensaje=ERROR: Inicie Sesión");

        }

        protected void EnlaceParticipante(object sender, EventArgs e)
        {
            int tipoUsu = Convert.ToInt32(Session["tipoUsuario"]);

            if (tipoUsu != 3)
                Response.Redirect("participantes.aspx");
        }

        protected void EnlaceCategoria(object sender, EventArgs e)
        {
            int tipoUsu = Convert.ToInt32(Session["tipoUsuario"]);

            if (tipoUsu != 3)
                Response.Redirect("categorias.aspx");
        }

        protected void CierraSesion(object sender, EventArgs e)
        {
            Session["nombreUsuario"] = null;
            Session["tipoUsuario"] = null;

            Response.Redirect("login.aspx?mensaje=Sesión Cerrada");
        }
    }
}