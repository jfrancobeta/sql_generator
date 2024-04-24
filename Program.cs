using script_sql_generator_csharp;

string nombreTabla = "mi_tabla";

SQL sql = new SQL();
Campo[] campos = {
    new Campo("direccion", "texto", "Cra. ## Numero ##@@-#"),
    new Campo("edad", "numérico", 1, 60),
    new Campo("creacion", "fecha", "2024-01-01", "2024-01-31"),
    // Agregar más campos aquí
};
//la cantidad de datos se preguntaran en consola

// la clase esta en domain

//script generador en Generator
sql.GenerarSQL(nombreTabla, campos);
