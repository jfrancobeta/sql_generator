namespace script_sql_generator_csharp;

public class Campo
{
    private string nombre;
    private string tipo;
    private object minimo;
    private object maximo;
    private string formato;

    public Campo(string nombre, string tipo, object minimo, object maximo)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.minimo = minimo;
        this.maximo = maximo;
    }

    public Campo(string nombre, string tipo, string formato)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.formato = formato;
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }

    public object Minimo
    {
        get { return minimo; }
        set { minimo = value; }
    }

    public object Maximo
    {
        get { return maximo; }
        set { maximo = value; }
    }

    public string Formato
    {
        get { return formato; }
        set { formato = value; }
    }
}
