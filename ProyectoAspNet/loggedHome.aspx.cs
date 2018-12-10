using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAspNet
{
    public partial class loggedHome : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        LN logica = new LN();
        List<string> listaTipoUsuario = new List<string>(){ "Administrador", "Estandar", "Deshabilitado"};

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    lbNombreUsu.Text += "Bienvenido, " + Session["nombreUsuario"].ToString();
                }
                catch (Exception) { }

                int idUsuario = Convert.ToInt32(Session["idUsuario"]);

                Usuario u = logica.GetUsuario(idUsuario);

                txId.Text = u.IdUsuario.ToString();
                txNombre.Text = u.Nombre;
                txApellidos.Text = u.Apellidos;
                txAlias.Text = u.Alias;
                txLoginReg.Text = u.NombreLogin;
                txPassReg.Text = u.NombrePassword;   

                if (u.IdUsuario == 3)
                {
                    btnActualizar.Enabled = false;
                    btnActualizar.CssClass = "btn btn-primary btn-lg btn-block";
                }


                if (u.TipoUsuario == 1)
                {
                    gvUsuarios.DataSource = logica.TablaUsuario();
                    gvUsuarios.DataBind();
                }
                else
                {
                    abreCol.Visible = false;
                    gv.Visible = false;
                    cierraCol.Visible = false;
                }

                int idTipo = Convert.ToInt32(Session["tipoUsuario"]);

                if (idTipo != 1)
                {
                    lbTipoUsu.Visible = false;

                    if (idTipo == 3)
                    {
                        lbDeshabilitado.Visible = true;
                    }

                } else 
                {
                    cargaComboTipoUsuario(u.TipoUsuario);
                }
            }
        }

        protected void gvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int idUsuario = Convert.ToInt32(gvUsuarios.Rows[e.NewEditIndex].Cells[8].Text);
            u = logica.GetUsuario(idUsuario);

            txId.Text = u.IdUsuario.ToString();
            txNombre.Text = u.Nombre;
            txApellidos.Text = u.Apellidos;
            txAlias.Text = u.Alias;
            txLoginReg.Text = u.NombreLogin;
            txPassReg.Text = u.NombrePassword;

            if (Convert.ToInt32(Session["idUsuario"]) == 1)
            {
                cargaComboTipoUsuario(u.TipoUsuario);
            }

            lbNombreUsu.Text = "Editar a ";
            lbNombreEdit.Text = txNombre.Text;

            gvUsuarios.Columns[0].Visible = false;
            gvUsuarios.Columns[1].Visible = false;
        }

        protected void gvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lbConfirmarBorrado.Visible = true;
            btnConfirmarBorrado.Visible = true;
            btnCancelarBorrado.Visible = true;
            gvUsuarios.SelectedIndex = e.RowIndex;
        }

        protected void btnConfirmarBorrado_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(gvUsuarios.Rows[gvUsuarios.SelectedIndex].Cells[8].Text);
            u = logica.GetUsuario(idUsuario);

            logica.EliminarUsuario(u);

            gvUsuarios.DataSource = logica.TablaUsuario();
            gvUsuarios.DataBind();

            Response.Redirect("loggedHome.aspx");
        }

        protected void btnCancelarBorrado_Click(object sender, EventArgs e)
        {
            Response.Redirect("loggedHome.aspx");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            lbEdit.Text = "true";

            u.IdUsuario = Convert.ToInt32(txId.Text);
            u.Nombre = txNombre.Text;
            u.Apellidos = txApellidos.Text;
            u.Alias = txAlias.Text;
            u.NombreLogin = txLoginReg.Text;
            u.NombrePassword = txPassReg.Text;

            if (cbTipoUsuario.SelectedValue == "Administrador")
            {
                u.TipoUsuario = 1;
            } else if (cbTipoUsuario.SelectedValue == "Estandar") {
                u.TipoUsuario = 2;
            } else if (cbTipoUsuario.SelectedValue == "Deshabilitado")
            {
                u.TipoUsuario = 3;
            }

            logica.GuardaOActualizaUsuario(u);

            gvUsuarios.DataSource = logica.TablaUsuario();
            gvUsuarios.DataBind();

            txId.Text = "";
            txNombre.Text = "";
            txApellidos.Text = "";
            txAlias.Text = "";
            txLoginReg.Text = "";
            txPassReg.Text = "";

            Response.Redirect("loggedHome.aspx");
        }

        protected void gvUsuarios_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    switch (Convert.ToInt32(e.Row.Cells[7].Text))
                    {

                        case 1:
                            e.Row.Cells[7].Text = "Usuario Administrador";
                            break;

                        case 2:
                            e.Row.Cells[7].Text = "Usuario estandar";
                            break;
                        case 3:
                            e.Row.Cells[7].Text = "Usuario deshabilitado";
                            break;

                    }
                }
                catch (Exception)
                {               }
            }
        }

        protected void gvUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                gvUsuarios.HeaderRow.Cells[8].Visible = false;

                foreach (GridViewRow fila in gvUsuarios.Rows)
                {
                    fila.Cells[8].Visible = false;

                    if (fila.Cells[7].Text == "Usuario Administrador")
                    {
                        fila.Cells[1].Text = "";
                    }

                }
            }
            catch (Exception)
            {               }

        }

        void cargaComboTipoUsuario (int id)
        {
            cbTipoUsuario.DataSource = listaTipoUsuario;
            cbTipoUsuario.DataBind();

            switch (id)
            {
                case 1:
                    cbTipoUsuario.SelectedIndex = 0;
                    break;
                case 2:
                    cbTipoUsuario.SelectedIndex = 1;
                    break;
                case 3:
                    cbTipoUsuario.SelectedIndex = 2;
                    break;
            }
        }

    }
}