using AccesoDatos;
using LogicaNegocio;

public class Participante {

	int idParticipante;
    int dorsal;
	string nombre;
	string apellidos;
	int idCategoria;

    public Participante ()
    {
        this.idParticipante = -1;
        this.dorsal = -1;
        this.nombre = string.Empty;
        this.apellidos = string.Empty;
        this.idCategoria = -1;
    }

	public Participante (int idParticipante, int dorsal, string nombre, string apellidos, int idCategoria) {

        this.idParticipante = idParticipante;
        this.dorsal = dorsal;
		this.nombre = nombre;
		this.apellidos = apellidos;
		this.idCategoria = idCategoria;
	}

    public Participante (DataSet1.ParticipanteRow reg)
    {
        this.idParticipante = reg.IdParticipante;
        this.dorsal = reg.dorsal;
        this.nombre = reg.nombre;
        this.apellidos = reg.apellidos;
        this.idCategoria = reg.idCategoria;
    }

    #region Propiedades
	public int IdParticipante
	{
		get
		{
			return idParticipante;
		}
		set
		{
			idParticipante = value;
		}
	}

    public int Dorsal
    {
        get
        {
            return dorsal;
        }
        set
        {
            dorsal = value;
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
	public int IdCategoria
	{
		get
		{
			return idCategoria;
		}
		set
		{
			idCategoria = value;
		}
	}

    #endregion
}