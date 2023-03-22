using Proyecto_Matrix.Clases;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Funciones
{
    public class Menu
    {
        public void imprimirmenu()
        {
            bool salir = false;
            while (salir != true)
            {
                AnsiConsole.Write(
                        new FigletText("STOCK UP")
                            .LeftJustified()
                            .Color(Color.Gold3_1));

                Console.WriteLine("");
                var Funcion = AnsiConsole.Prompt(
             new SelectionPrompt<string>()
            .Title("¿Que desea Realizar?")
            .PageSize(10)
            .MoreChoicesText("Mueve con las flechas de arriba y abajo para seleccionar")
            .AddChoices(new[] {
            "Registro de productos", "Visualizacion de inventario", "Actualizacion de inventario",
             "Ventas","Salir"
            }));
                switch (Funcion)
                {
                    case "Registro de productos":
                        
                        break;
                    case "Visualizacion de inventario":
                       
                        break;
                    case "Actualizacion de inventario":
                        break;
                    case "Salir":

                        AnsiConsole.MarkupLine("¡Hasta Luego!");
                        salir = true;
                        break;
                }
            }
        }
    }
}
