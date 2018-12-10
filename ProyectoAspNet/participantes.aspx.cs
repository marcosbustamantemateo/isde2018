using AccesoDatos;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAspNet
{
    public partial class participantes : System.Web.UI.Page
    {
        Categoria c = new Categoria();
        Participante p = new Participante();
        LN logica = new LN();
        bool edita = false;
        int idUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                idUsuario = Convert.ToInt32(Session["tipoUsuario"]);

                if (idUsuario != 1)
                {
                    
                    if (idUsuario == 3) //usuario deshabilitado
                    {
                        gvParticipantes.Visible = false;
                    }

                    lbMenuAnadir.Visible = false;

                } else
                {
                    lbMenuAnadir.Visible = true;
                }

                int idCategoria = Convert.ToInt32(Request.QueryString["idCategoria"]);
                c = logica.GetCategoria(idCategoria);

                if (c != null)
                {
                    lbTitulo.Text += " " + c.Nombre;
                    lbMenuAnadir.Visible = false;
                    edita = true;
                }
               
                if (idCategoria == 1 || idCategoria == 2 || idCategoria == 3)
                    gvParticipantes.DataSource = logica.TablaParticipantesPorCategoria(idCategoria);

                else
                    gvParticipantes.DataSource = logica.TablaParticipantes();

                gvParticipantes.DataBind();
                CargaComboCategorias();
            }
        }

        protected void gvParticipantes_Load(object sender, EventArgs e)
        {
            if (gvParticipantes.Rows.Count == 0)
            {
                lbVacio.Visible = true;
            } else
            {
                gvParticipantes.HeaderRow.Cells[2].Visible = false;
                gvParticipantes.HeaderRow.Cells[6].Visible = false;
            }

            if (edita || idUsuario != 1)
            {
                gvParticipantes.Columns[0].Visible = false;
                gvParticipantes.Columns[1].Visible = false;
            }
  
            foreach (GridViewRow fila in gvParticipantes.Rows)
            {
                fila.Cells[2].Visible = false;
                fila.Cells[6].Visible = false;
            }
        }

        protected void gvParticipantes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int idParticipante = Convert.ToInt32(gvParticipantes.Rows[e.NewEditIndex].Cells[2].Text);
            p = logica.GetParticipante(idParticipante);

            txId.Text = p.IdParticipante.ToString();
            txNombre.Text = p.Nombre;
            txApellidos.Text = p.Apellidos;
            txDorsal.Text = p.Dorsal.ToString();
            cbCategorias.SelectedValue = p.IdCategoria.ToString();

            lbParticipante.Text = "Editar Participante";
            btnAnadirParticipante.Text = "Actualizar";

            gvParticipantes.Columns[0].Visible = false;
            gvParticipantes.Columns[1].Visible = false;
        }

        protected void gvParticipantes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lbConfirmarBorrado.Visible = true;
            btnConfirmarBorrado.Visible = true;
            btnCancelarBorrado.Visible = true;
            gvParticipantes.SelectedIndex = e.RowIndex;
        }

        protected void BtnConfirmarBorrado_Click1(object sender, EventArgs e)
        {
            int idParticipante = Convert.ToInt32(gvParticipantes.Rows[gvParticipantes.SelectedIndex].Cells[2].Text);
            logica.EliminarParticipante(logica.GetParticipante(idParticipante));

            gvParticipantes.DataSource = logica.TablaParticipantes();
            gvParticipantes.DataBind();

            Response.Redirect("participantes.aspx");
        }

        protected void btnCancelarBorrado_Click(object sender, EventArgs e)
        {
            Response.Redirect("participantes.aspx");
        }

        protected void btnAnadirParticipante_Click(object sender, EventArgs e)
        {
            if (btnAnadirParticipante.Text == "Actualizar")
                p.IdParticipante = Convert.ToInt32(txId.Text);

            try
            {
                p.Nombre = txNombre.Text;
                p.Apellidos = txApellidos.Text;
                p.Dorsal = Convert.ToInt32(txDorsal.Text);
                p.IdCategoria = Convert.ToInt32(cbCategorias.SelectedValue);

                logica.GuardaOActualizaParticipante(p);
            }
            catch (Exception)
            {               }

            gvParticipantes.DataSource = logica.TablaParticipantes();
            gvParticipantes.DataBind();

            txNombre.Text = "";
            txApellidos.Text = "";
            txDorsal.Text = "";
            CargaComboCategorias();

            Response.Redirect("participantes.aspx");
        }

        void CargaComboCategorias ()
        {
            cbCategorias.DataSource = logica.ListadoCategorias();
            cbCategorias.DataValueField = "idCategoria";
            cbCategorias.DataTextField = "nombre";
            cbCategorias.DataBind();
        }

    }
}