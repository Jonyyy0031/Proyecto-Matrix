using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Funciones
{
    public class Login
    {
        public void Ingreso()
        {
           AnsiConsole.Prompt(
         
        new TextPrompt<string>("Enter [green]password[/]?")
        .PromptStyle("red")
        .Secret());
        }
    }
}
