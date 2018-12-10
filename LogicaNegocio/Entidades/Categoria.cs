using AccesoDatos;

public class Categoria {

	int idCategoria;
	string nombre;

    public Categoria ()
    {
        this.idCategoria = -1;
        this.nombre = string.Empty;
    }

	public Categoria (int idCategoria, string nombre) {

		this.idCategoria = idCategoria;
		this.nombre = nombre;
	}

    public Categoria (DataSet1.CategoriaRow reg)
    {
        this.idCategoria = reg.IdCategoria;
        this.nombre = reg.nombre;
    }

    #region Propiedades
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
    #endregion
}