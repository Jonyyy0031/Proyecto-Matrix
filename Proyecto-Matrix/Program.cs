using System;
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
            Console.WriteLine("");
            var Funcion = AnsiConsole.Prompt(
         new SelectionPrompt<string>()
        .Title("¿Que desea Realizar?")
        .PageSize(10)
        .MoreChoicesText("Mueve con las flechas de arriba y abajo para seleccionar")
        .AddChoices(new[] {
            "Registro de productos", "Visualizacion de inventario", "Actualizacion de inventario",
            "Checkeo de producto"
        }));
            if (Funcion == "Registro de productos")
            {
                Console.WriteLine(Funcion);
            }
            if (Funcion == "Visualizacion de Inventario")
            { 
                Console.WriteLine(Funcion); 
            }
            if (Funcion == "Actualizacion de Inventario")
            {
                Console.WriteLine(Funcion);
            }
            if (Funcion =="Checkeo de producto")
            {
                Console.WriteLine(Funcion);
            }
            
        }
    }
}
