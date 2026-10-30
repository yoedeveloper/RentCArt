using rentcart.models;
using rentcart.service;
using Spectre.Console;

class Program
{

    //Menu
    public static bool running = true;

    public static String[] choices = [
                "1. ver carros",
                "2. agregar carros",
                "3. eliminar carros",
                "4. salir"
                ];
    public static VehiculosService vehiculosService = new();
    
    
    public static void Main()
    {
        //bucle
        while (running)
           
        {
            // estilos en el menu
            Console.WriteLine();
            Console.WriteLine("================= * RENT CART * =================");
            var selections = new SelectionPrompt<String>()
            .Title("[blue]:[/]")
            .HighlightStyle("Darkgoldenrod")
            .AddChoices(choices);

            var option = AnsiConsole.Prompt(selections);

            //Importa los vehiculos guardados en service
            List<Vehiculo> vehiculos = vehiculosService.FindAll();

            //swicht(option) nos permite darle vida al menu podiendo darle funciones a cada opcion que decidamos utilizar
            switch (option){
                case "1. ver carros":
                    //aqui se forma una tabla con sus categorias
                    var table = new Table();
                    table.AddColumn("Id");
                    table.AddColumns("Tipo");
                    table.AddColumns("MarcaNombre");
                    table.AddColumns("Placa");
                    table.AddColumns("Lanzamiento");

                    //con esto se inyectan los valores de Vehiculo guardados en service
                    foreach (Vehiculo vehiculo in vehiculos)
                    {
                        table.AddRow(
                            vehiculo.Id.ToString(),
                            vehiculo.Tipo,
                            vehiculo.MarcaNombre,
                            vehiculo.Placa,
                            vehiculo.Lanzamiento.ToString()
                            );
                    }

                    AnsiConsole.Write(table);
                    break;

                    //aqui se toman los valores para agregar un nuevo vehiculo
                case "2. agregar carros":
                    AnsiConsole.Clear();
                    string tipo = AnsiConsole.Ask<string>("[DarkGoldenrod]Indica el típo de carro: [/]");
                    string marcanombre = AnsiConsole.Ask<string>("[DarkGoldenrod]Indica la marca o nombre: [/]");
                    string placa = AnsiConsole.Ask<string>("[DarkGoldenrod]Indica la placa de vehiculo: [/]");
                    int lanzamiento = AnsiConsole.Ask<int>("[DarkGoldenrod]Indica el lanzamiento: [/]");

                    var maxId = vehiculos.Max((b) => b.Id);
                    //aqui se toman los datos necesarios para la lista vehiculo
                    Vehiculo newVehiculo = new()
                    {
                        Id = maxId + 1,
                        Tipo = tipo,
                        MarcaNombre = marcanombre,
                        Placa = placa,
                        Lanzamiento = lanzamiento
                    };
                    //con esto se intruce un nuevo vehiculo
                    vehiculosService.Create(newVehiculo);
                    AnsiConsole.MarkupLine("\n[DarkOliveGreen1_1]vehiculo agregado![/]\n");
                    break;

                    
                case "3. eliminar carros":
                    AnsiConsole.Clear();
                    int id = AnsiConsole.Ask<int>("Indica el id que quieres eliminar: ");

                    AnsiConsole.WriteLine("");
                    var confirmed = AnsiConsole.Confirm("¿Estás seguro?");

                    if (confirmed)
                    {
                        bool deleted = vehiculosService.Delete(id);

                        if (deleted)
                        {
                            AnsiConsole.MarkupLine("\n[DarkOliveGreen1_1]vehiculo eliminado![/]\n");
                            break;
                        }

                        AnsiConsole.MarkupLine("\n[red]vehiculo no encontrado![/]\n");
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("\n[yellow]Operación cancelada![/]\n");

                    }
                    break;

                case "4. salir":
                    AnsiConsole.Clear();
                    AnsiConsole.MarkupLine("[DarkOliveGreen1_1]¡Fin del programa![/]");
                    running = false;
                    break;
                    

            }
        }
          
    }
}