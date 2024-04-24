namespace script_sql_generator_csharp;

public class SQL
{
    // Definimos las posibles combinaciones de números y letras
    private static readonly string[] LETRAS = "abcdefghijklmnopqrstuvwxyz".ToCharArray().Select(c => c.ToString()).ToArray();
    private static readonly string[] NUMEROS = "0123456789".ToCharArray().Select(c => c.ToString()).ToArray();

    public void GenerarSQL(string nombreTabla, Campo[] campos)
    {
        try
        {
            using (StreamWriter escritor = new StreamWriter($"{nombreTabla}.sql"))
            {
                // Crear tabla
                escritor.WriteLine($"CREATE TABLE {nombreTabla} (");

                for (int i = 0; i < campos.Length; i++)
                {
                    Campo campo = campos[i];
                    escritor.Write($"    {campo.Nombre} ");

                    switch (campo.Tipo)
                    {
                        case "texto":
                            escritor.Write("VARCHAR(255)");
                            break;
                        case "numérico":
                            escritor.Write("INT");
                            break;
                        case "fecha":
                            escritor.Write("DATE");
                            break;
                    }

                    if (i < campos.Length - 1)
                    {
                        escritor.WriteLine(",");
                    }
                    else
                    {
                        escritor.WriteLine();
                    }
                }

                escritor.WriteLine(");");
                escritor.WriteLine();

                // Insertar datos aleatorios
                Console.WriteLine("Cantidad de datos a generar:");
                int generador = int.Parse(Console.ReadLine());
                Random aleatorio = new Random();

                for (int i = 0; i < generador; i++)
                {
                    escritor.Write($"INSERT INTO {nombreTabla} VALUES (");

                    foreach (Campo campo in campos)
                    {
                        switch (campo.Tipo)
                        {
                            case "texto":
                                escritor.Write($"'{GenerarCadenaAleatoria(campo.Formato)}'");
                                break;
                            case "numérico":
                                int valorMinimo = (int)campo.Minimo;
                                int valorMaximo = (int)campo.Maximo;
                                escritor.Write(aleatorio.Next(valorMinimo, valorMaximo + 1));
                                break;
                            case "fecha":
                                string fechaInicio = (string)campo.Minimo;
                                string fechaFinal = (string)campo.Maximo;
                                long inicioMilisegundos = DateTime.Parse(fechaInicio).Ticks / TimeSpan.TicksPerMillisecond;
                                long finalMilisegundos = DateTime.Parse(fechaFinal).Ticks / TimeSpan.TicksPerMillisecond;
                                long milisegundosAleatorios = inicioMilisegundos + (long)(aleatorio.NextDouble() * (finalMilisegundos - inicioMilisegundos));
                                escritor.Write($"'{new DateTime(milisegundosAleatorios * TimeSpan.TicksPerMillisecond)}'");
                                break;
                        }

                        if (campo != campos[campos.Length - 1])
                        {
                            escritor.Write(", ");
                        }
                    }

                    escritor.WriteLine(");");
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }

    private static string GenerarCadenaAleatoria(string formato)
    {
        string resultado = "";
        Random aleatorio = new Random();

        foreach (char c in formato.ToCharArray())
        {
            switch (c)
            {
                case '#':
                    resultado += NUMEROS[aleatorio.Next(NUMEROS.Length)];
                    break;
                case '@':
                    resultado += LETRAS[aleatorio.Next(LETRAS.Length)];
                    break;
                default:
                    resultado += c;
                    break;
            }
        }

        return resultado;
    }
}
