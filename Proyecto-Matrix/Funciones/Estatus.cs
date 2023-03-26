using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Spectre.Console;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Funciones
{
    public class Estatus
    {
        public void Loading()
        {
            Menus menu = new Menus();
            AnsiConsole.Status()
        .SpinnerStyle(Style.Parse("red"))
        .Start("Espere por favor...", ctx =>
        {
            AnsiConsole.MarkupLine("Cargando...");
            Thread.Sleep(1000);
            AnsiConsole.MarkupLine("Preparando función...");
            Thread.Sleep(1500);
            ctx.SpinnerStyle(Style.Parse("green"));
            ctx.Status("Verificando...");
            AnsiConsole.MarkupLine("Finalizando...");
            Thread.Sleep(2000);
        });
        Console.Clear();
        menu.ImprimirLogo();
        Console.ResetColor();
        } 
    }
}
