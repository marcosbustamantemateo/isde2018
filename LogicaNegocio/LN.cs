using AccesoDatos;
using AccesoDatos.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class LN
    {
        #region Usuarios
        public UsuarioTableAdapter usuarioTableAdapter = new UsuarioTableAdapter();
        public DataSet1.UsuarioDataTable usuariosTabla = new DataSet1.UsuarioDataTable();

        public List<Usuario> ListadoUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            usuariosTabla = usuarioTableAdapter.GetData();

            foreach (DataSet1.UsuarioRow lineaUsu in usuariosTabla)
            {
                listaUsuarios.Add(new Usuario(lineaUsu));
            }

            return listaUsuarios;
        }

        public Usuario GetUsuario(int id)
        {
            List<Usuario> listaUsuarios = ListadoUsuarios();
            Usuario u = null;

            for (int i = 0; i < listaUsuarios.Count; i++)
                if (listaUsuarios[i].IdUsuario == id)
                    u = listaUsuarios[i];

            return u;
        }

        public void GuardaOActualizaUsuario(Usuario u)
        {
            usuariosTabla = usuarioTableAdapter.GetData();
            DataSet1.UsuarioRow lineaUsu;

            if (u.IdUsuario == -1)
            {
                lineaUsu = usuariosTabla.NewUsuarioRow();
            }
            else
            {
                lineaUsu = usuariosTabla.FindByIdUsuario(u.IdUsuario);
            }

            if (u.Nombre == "" || u.Nombre == null || u.Apellidos == "" || u.Apellidos == null || u.Alias == "" || u.Alias == null
                || u.NombreLogin == "" || u.NombreLogin == null || u.NombrePassword == "" || u.NombrePassword == null)
            {
                return;
            }

            lineaUsu.nombre = u.Nombre;
            lineaUsu.apellidos = u.Apellidos;
            lineaUsu.alias = u.Alias;
            lineaUsu.nombreLogin = u.NombreLogin;
            lineaUsu.nombrePassword = u.NombrePassword;

            if (u.IdUsuario == -1)
            {
                lineaUsu.tipoUsuario = u.TipoUsuario;
                usuariosTabla.AddUsuarioRow(lineaUsu);
            }
            else
            {
                lineaUsu.tipoUsuario = u.TipoUsuario;
            }

            usuarioTableAdapter.Update(lineaUsu);
            usuariosTabla.AcceptChanges();
        }

        public void EliminarUsuario(Usuario u)
        {
            usuariosTabla = usuarioTableAdapter.GetData();
            DataSet1.UsuarioRow lineaUsu = usuariosTabla.FindByIdUsuario(u.IdUsuario);
            lineaUsu.Delete();
            usuarioTableAdapter.Update(usuariosTabla);
            usuariosTabla.AcceptChanges();
        }

        public DataSet1.UsuarioDataTable TablaUsuario()
        {
            usuariosTabla = usuarioTableAdapter.GetData();
            return usuariosTabla;
        }

        #endregion

        #region Participantes
        public ParticipanteTableAdapter participanteTableAdapter = new ParticipanteTableAdapter();
        public DataSet1.ParticipanteDataTable participantesTabla = new DataSet1.ParticipanteDataTable();

        public List<Participante> ListadoParticipantes()
        {
            List<Participante> listaParticipantes = new List<Participante>();

            participantesTabla = participanteTableAdapter.GetData();

            foreach (DataSet1.ParticipanteRow lineaUsu in participantesTabla)
                listaParticipantes.Add(new Participante(lineaUsu));

            return listaParticipantes;
        }

        public Participante GetParticipante(int id)
        {
            List<Participante> listaParticipantes = ListadoParticipantes();
            Participante p = null;

            for (int i = 0; i < listaParticipantes.Count; i++)
                if (listaParticipantes[i].IdParticipante == id)
                    p = listaParticipantes[i];

            return p;
        }

        public void EliminarParticipante(Participante p)
        {
            participantesTabla = participanteTableAdapter.GetData();
            DataSet1.ParticipanteRow lineaUsu = participantesTabla.FindByIdParticipante(p.IdParticipante);
            lineaUsu.Delete();
            participanteTableAdapter.Update(lineaUsu);
            participantesTabla.AcceptChanges();
        }

        public void GuardaOActualizaParticipante(Participante p)
        {
            participantesTabla = participanteTableAdapter.GetData();
            DataSet1.ParticipanteRow lineaUsu;

            if (p.IdParticipante == -1)
            {
                lineaUsu = participantesTabla.NewParticipanteRow();
            }
            else
            {
                lineaUsu = participantesTabla.FindByIdParticipante(p.IdParticipante);
            }

            if (p.Nombre == "" || p.Nombre == null || p.Apellidos == "" || p.Apellidos == null)
            {
                return;
            }

            lineaUsu.nombre = p.Nombre;
            lineaUsu.apellidos = p.Apellidos;
            lineaUsu.idCategoria = p.IdCategoria;
            lineaUsu.dorsal = p.Dorsal;

            if (p.IdParticipante == -1)
            {
                participantesTabla.AddParticipanteRow(lineaUsu);
            }

            participanteTableAdapter.Update(lineaUsu);
            participantesTabla.AcceptChanges();
        }

        public DataSet1.ParticipanteDataTable TablaParticipantes()
        {
            participantesTabla = participanteTableAdapter.GetDataParticipantes();
            return participantesTabla;
        }

        public DataSet1.ParticipanteDataTable TablaParticipantesPorCategoria(int id)
        {
            participantesTabla = participanteTableAdapter.GetDataParticipantesByCategoria(id);
            return participantesTabla;
        }

        #endregion

        #region Categorias
        public CategoriaTableAdapter categoriaTableAdapter = new CategoriaTableAdapter();
        public DataSet1.CategoriaDataTable categoriasTabla = new DataSet1.CategoriaDataTable();
        
        public List<Categoria> ListadoCategorias()
        {
            List<Categoria> listaCategorias = new List<Categoria>();

            categoriasTabla = categoriaTableAdapter.GetData();

            foreach (DataSet1.CategoriaRow lineaUsu in categoriasTabla)
            {
                listaCategorias.Add(new Categoria(lineaUsu));
            }

            return listaCategorias;
        }

        public Categoria GetCategoria(int id)
        {
            List<Categoria> listaCategorias = ListadoCategorias();
            Categoria c = null;

            for (int i = 0; i < listaCategorias.Count; i++)
                if (listaCategorias[i].IdCategoria == id)
                    c = listaCategorias[i];

            return c;
        }

        #endregion
    }
}
