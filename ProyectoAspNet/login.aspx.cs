using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAspNet
{
    public partial class login : System.Web.UI.Page
    {
        List<Usuario> usuarios;
        Usuario u = new Usuario();
        LN logica = new LN();

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("lbMenuLogin").Visible = false;
            if (Request.QueryString["mensaje"] != null)
            {
                lbMensajeInicio.Visible = true;
                lbMensaje.Text = Request.QueryString["mensaje"];
                lbMensaje.Visible = true;
                lbMensajeFinal.Visible = true;
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            bool login = false;
            usuarios = logica.ListadoUsuarios();

            for (int i = 0; i < usuarios.Count; i++)
            {
                if ((txLogin.Text == usuarios[i].NombreLogin) && (txPass.Text == usuarios[i].NombrePassword))
                {
                    u = usuarios[i];
                    login = true;
                }
            }

            if (login)
            {
                Session["nombreUsuario"] = u.Nombre;
                Session["idUsuario"] = u.IdUsuario;
                Session["tipoUsuario"] = u.TipoUsuario;
                Response.Redirect("loggedHome.aspx");
            }
            else
            {
                lbMensajeInicio.Visible = true;
                lbMensaje.Text = "Usuario y/o Password Incorrecto";
                lbMensaje.Visible = true;
                lbMensajeFinal.Visible = true;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            u.Nombre = txNombre.Text;
            u.Apellidos = txApellidos.Text;
            u.Alias = txAlias.Text;
            u.NombreLogin = txLoginReg.Text;
            u.NombrePassword = txPassReg.Text;
            u.TipoUsuario = 3;

            logica.GuardaOActualizaUsuario(u);

            lbMensajeInicio.Visible = true;
            lbMensaje.Text = "Usuario registrado";
            lbMensaje.Visible = true;
            lbMensajeFinal.Visible = true;

            txNombre.Text = "";
            txApellidos.Text = "";
            txAlias.Text = "";
            txLoginReg.Text = "";
            txPassReg.Text = "";
            txPassRepetir.Text = "";
        }
    }
}