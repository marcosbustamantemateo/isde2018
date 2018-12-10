using AccesoDatos;
using LogicaNegocio;

public class Usuario {

	int idUsuario;
	string nombre;
	string apellidos;
	string alias;
	string nombreLogin;
	string nombrePassword;
	int tipoUsuario;

    public Usuario ()
    {
        this.idUsuario = -1;
        this.nombre = string.Empty;
        this.apellidos = string.Empty;
        this.alias = string.Empty;
        this.nombreLogin = string.Empty;
        this.nombrePassword = string.Empty;
        this.tipoUsuario = 2;
    }

	public Usuario (int idUsuario, string nombre, string apellidos, string alias, string nombreLogin, string nombrePassword, int tipoUsuario) {

        this.idUsuario = idUsuario;
		this.nombre = nombre;
		this.apellidos = apellidos;
		this.alias = alias;
		this.nombreLogin = nombreLogin;
		this.nombrePassword = nombrePassword;
		this.tipoUsuario = tipoUsuario;
	}

    public Usuario (DataSet1.UsuarioRow reg)
    {
        this.idUsuario = reg.IdUsuario;
        this.nombre = reg.nombre;
        this.apellidos = reg.apellidos;
        this.alias = reg.alias;
        this.nombreLogin = reg.nombreLogin;
        this.nombrePassword = reg.nombrePassword;
        this.tipoUsuario = reg.tipoUsuario;
    }

    #region Propiedades
    public int IdUsuario
	{
		get
		{
			return idUsuario;
		}
		set
		{
			idUsuario = value;
		}
	}
	public string Nombre
	{
		get
		{
			return nombre;
		}
		set
		{
			nombre = value;
		}
	}
	public string Apellidos
	{
		get
		{
			return apellidos;
		}
		set
		{
			apellidos = value;
		}
	}
	public string Alias
	{
		get
		{
			return alias;
		}
		set
		{
			alias = value;
		}
	}
	public string NombreLogin
	{
		get
		{
			return nombreLogin;
		}
		set
		{
			nombreLogin = value;
		}
	}
	public string NombrePassword
	{
		get
		{
			return nombrePassword;
		}
		set
		{
			nombrePassword = value;
		}
	}
	public int TipoUsuario
	{
		get
		{
			return tipoUsuario;
		}
		set
		{
			tipoUsuario = value;
		}
	}
    #endregion
}