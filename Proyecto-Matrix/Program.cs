using System;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Proyecto_Matrix.Context;
using Spectre.Console;

namespace Proyecto_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.Write(
                    new FigletText("MATRIX")
                        .LeftJustified()
                        .Color(Color.Red));
            while (true)
            {
                Console.WriteLine("");
                var Funcion = AnsiConsole.Prompt(
             new SelectionPrompt<string>()
            .Title("¿Que desea Realizar?")
            .PageSize(10)
            .MoreChoicesText("Mueve con las flechas de arriba y abajo para seleccionar")
            .AddChoices(new[] {
            "Registro de productos", "Visualizacion de inventario", "Actualizacion de inventario",
            "salir"
            }));
                    if(Funcion == "Registro de productos")
                {
                    var Nombre = AnsiConsole.Ask<string>("Nombre del producto");
                    var precio = AnsiConsole.Ask<string>("del producto");
                    var cantidad = AnsiConsole.Ask<string>(" del producto");
                    var color = AnsiConsole.Ask<string>(" del producto");
                    AnsiConsole.MarkupLine("Producto agregado con exito");
                    AnsiConsole.MarkupLine("Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();

                }

                if (Funcion == "Visualizacion de Inventario")
                {
                    Console.WriteLine(Funcion);
                }
                if (Funcion == "Actualizacion de Inventario")
                {
                    Console.WriteLine(Funcion);
                }
                if (Funcion == "salir")
                {
                    break;
                }
            }
        }
    }
}
