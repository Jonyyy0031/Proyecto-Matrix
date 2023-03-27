using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Proyecto_Matrix.Clases;
using Proyecto_Matrix.Context;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Funciones
{
    public class CRUDEmpleado
    {
        public void AñadirEmpleado()
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                bool salir = false;
                while (salir !=true)
                {
                    Menus menu = new Menus();
                    Empleado empleado = new Empleado();
                    Console.WriteLine("Ingresa la informacion:");
                    empleado.UserE = AnsiConsole.Ask<string>("Ingresa el nombre de Usuario del Empleado");
                    empleado.PasswordE = AnsiConsole.Ask<string>("Ingresa la contraseña del Empleado");
                    empleado.NombreE = AnsiConsole.Ask<string>("Ingresa el nombre del Empleado");
                    empleado.Apellido = AnsiConsole.Ask<string>("Ingresa el apellido del Empleado");
                    empleado.Puesto = AnsiConsole.Ask<string>("Ingresa el puesto laboral del Empleado");
                    _context.Empleados.Add(empleado);
                    _context.SaveChanges();
                    Console.Clear();
                    menu.ImprimirLogo();
                    var Seleccion = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .Title("¿Desea agregar otro Empleado?")
                        .PageSize(10)
                        .AddChoices(new[]
                        {
                       "Si","No"
                        }));
                    switch (Seleccion)
                    {
                        case "No":
                            AnsiConsole.MarkupLine("Empleado agregado con exito");
                            AnsiConsole.MarkupLine("Presione una tecla para continuar");
                            Console.ReadKey();
                            Console.Clear();
                            salir = true;
                            break;
                    }
                }
            }
        }
        public void VisualizarEmpleados()
        {
            using (var _context = new ApplicationDbContext())
            {
                if (_context.Empleados.Any())
                {
                    AnsiConsole.Status()
                            .Start("Espere por favor...", ctx =>
                            {
                                AnsiConsole.MarkupLine("Cargando Tabla...");
                                Thread.Sleep(1000);
                                ctx.Status("Espere por favor...");
                                ctx.Spinner(Spinner.Known.Aesthetic);
                                ctx.SpinnerStyle(Style.Parse("green"));
                                AnsiConsole.MarkupLine("Organizando Empleados...");
                                Thread.Sleep(1500);
                                AnsiConsole.MarkupLine("Finalizando...");
                                Thread.Sleep(2000);
                            });
                    Console.Clear();
                    Menus menu = new Menus();
                    menu.ImprimirLogo();
                    var table = new Table().LeftAligned();
                    table.Border = TableBorder.Rounded;
                    table.BorderColor<Table>(color: Color.Grey70);
                    AnsiConsole.Live(table)
                        .Start(ctx =>
                        {

                            ctx.Refresh();
                            Thread.Sleep(500);
                            table.Title("Empleados");
                            table.AddColumn("ID");
                            table.AddColumn("Usuario del Empleado");
                            table.AddColumn("Contraseña del Empleado");
                            table.AddColumn("Nombre del Empleado");
                            table.AddColumn("Apellido del Empleado");
                            table.AddColumn("Puesto del Empleado");
                            using (var _context = new ApplicationDbContext())
                            {
                                var Empleados = _context.Empleados.ToList();
                                foreach (Empleado User  in Empleados)
                                {
                                    table.AddRow("" + User.IDEmpleado, "" + User.UserE, "" + User.PasswordE, "" + User.NombreE, "" + User.Apellido,""+User.Puesto);
                                }
                            }
                        });
                    Console.WriteLine("Presiona una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    AnsiConsole.MarkupLine("No hay empleados en el sistema");
                    AnsiConsole.MarkupLine("Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        public void ModificarEmpleados()
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                Menus menu = new Menus();
                if (_context.Empleados.Any())
                {
                    int IDCambio = AnsiConsole.Ask<int>("Ingrese la ID del Empleado a modificar");
                    Console.Clear();
                    menu.ImprimirLogo();
                    Empleado Empleado = _context.Empleados.Find(IDCambio);
                    if (Empleado != null)
                    {
                        var Cambio = AnsiConsole.Prompt(
                            new SelectionPrompt<String>()
                            .Title("¿Que desea hacer con el Empleado?")
                            .PageSize(10)
                            .AddChoices(new[]
                            {
                            "Cambiar Usuario del Empleado","Cambiar Contraseña del Empleado","Cambiar Nombre del Empleado","Cambiar Apellido del Empleado","Cambiar puesto del Empleado",
                            "Cambiar toda la informacion del Empleado","Eliminar Empleado"
                            }));
                        switch (Cambio)
                        {
                            case "Cambiar Usuario del Empleado":
                                bool finalizado = false;
                                while (finalizado != true)
                                {
                                    Empleado.UserE = AnsiConsole.Ask<string>("Ingrese el Usuario del Empleado");
                                    AnsiConsole.MarkupLine("Usuario actualizado correctamente a " + Empleado.UserE + "\n");
                                    var seleccion = AnsiConsole.Prompt(
                                        new SelectionPrompt<String>()
                                        .Title("Desea mantener el nuevo Usuario?")
                                        .PageSize(10)
                                        .AddChoices(new[]
                                        {
                                            "Si","No"
                                        }));
                                    switch (seleccion)
                                    {
                                        case "Si":
                                            finalizado = true;
                                            _context.Empleados.Update(Empleado);
                                            _context.SaveChanges();
                                            break;
                                        case "No":
                                            Console.Clear();
                                            menu.ImprimirLogo();
                                            break;
                                    }
                                }
                                AnsiConsole.MarkupLine("Presione una tecla para continuar");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "Cambiar Contraseña del Empleado":
                                bool finalizado1 = false;
                                while (finalizado1 != true)
                                {
                                    Empleado.PasswordE = AnsiConsole.Ask<string>("Ingrese la nueva contraseña del Empleado");
                                    AnsiConsole.MarkupLine("Contraseña actualizada correctamente a " + Empleado.PasswordE + "\n");
                                    var seleccion = AnsiConsole.Prompt(
                                        new SelectionPrompt<String>()
                                        .Title("Desea mantener la nueva contraseña?")
                                        .PageSize(10)
                                        .AddChoices(new[]
                                        {
                                            "Si","No"
                                        }));
                                    switch (seleccion)
                                    {
                                        case "Si":
                                            finalizado1 = true;
                                            _context.Empleados.Update(Empleado);
                                            _context.SaveChanges();
                                            break;
                                        case "No":
                                            Console.Clear();
                                            menu.ImprimirLogo();
                                            break;
                                    }
                                }
                                AnsiConsole.MarkupLine("Presione una tecla para continuar");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "Cambiar Nombre del Empleado":
                                bool finalizado3 = false;
                                while (finalizado3 != true)
                                {
                                    Empleado.NombreE = AnsiConsole.Ask<string>("Ingrese el nuevo nombre del empleado");
                                    AnsiConsole.MarkupLine("Nombre actualizado correctamente a " + Empleado.NombreE + "\n");
                                    var seleccion = AnsiConsole.Prompt(
                                        new SelectionPrompt<String>()
                                        .Title("Desea mantener el nombre?")
                                        .PageSize(10)
                                        .AddChoices(new[]
                                        {
                                            "Si","No"
                                        }));
                                    switch (seleccion)
                                    {
                                        case "Si":
                                            finalizado3 = true;
                                            _context.Empleados.Update(Empleado);
                                            _context.SaveChanges();
                                            break;
                                        case "No":
                                            Console.Clear();
                                            menu.ImprimirLogo();
                                            break;
                                    }
                                }
                                AnsiConsole.MarkupLine("Presione una tecla para continuar");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "Cambiar Apellido del Empleado":
                                bool finalizado4 = false;
                                while (finalizado4 != true)
                                {
                                    Empleado.Apellido = AnsiConsole.Ask<string>("Ingrese el nuevo Apellido");
                                    AnsiConsole.MarkupLine("Apellido actualizado correctamente a " + Empleado.Apellido + "\n");
                                    var seleccion = AnsiConsole.Prompt(
                                        new SelectionPrompt<String>()
                                        .Title("Es correcta la nueva cantidad?")
                                        .PageSize(10)
                                        .AddChoices(new[]
                                        {
                                            "Si","No"
                                        }));
                                    switch (seleccion)
                                    {
                                        case "Si":
                                            finalizado4 = true;
                                            _context.Empleados.Update(Empleado);
                                            _context.SaveChanges();
                                            break;
                                        case "No":
                                            Console.Clear();
                                            menu.ImprimirLogo();
                                            break;
                                    }
                                }
                                AnsiConsole.MarkupLine("Presione una tecla para continuar");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "Cambiar toda la informacion del Empleado":
                                bool finalizado5 = false;
                                while (finalizado5 != true)
                                {
                                    Empleado.UserE = AnsiConsole.Ask<string>("Ingrese el nuevo Usuario");
                                    Empleado.PasswordE = AnsiConsole.Ask<string>("Ingrese la nueva contraseña");
                                    Empleado.NombreE = AnsiConsole.Ask<string>("Ingrese el nuevo nombre");
                                    Empleado.Apellido = AnsiConsole.Ask<string>("Ingrese el nuevo apellido");
                                    Empleado.Puesto = AnsiConsole.Ask<string>("Ingrese el nuevo puesto");
                                    AnsiConsole.MarkupLine("Datos del empleado actualizado correctamente a:\nUsuario: " + Empleado.UserE + "\n Contraseña: " + Empleado.PasswordE +
                                        "\nNombre: " + Empleado.NombreE + "\nApellido: " + Empleado.Apellido + "\n Puesto: "+Empleado.Puesto+"");
                                    var seleccion = AnsiConsole.Prompt(
                                        new SelectionPrompt<String>()
                                        .Title("Desea mantener los cambios?")
                                        .PageSize(10)
                                        .AddChoices(new[]
                                        {
                                            "Si","No"
                                        }));
                                    switch (seleccion)
                                    {
                                        case "Si":
                                            finalizado5 = true;
                                            _context.Empleados.Update(Empleado);
                                            _context.SaveChanges();
                                            break;
                                        case "No":
                                            Console.Clear();
                                            menu.ImprimirLogo();
                                            break;
                                    }
                                }
                                AnsiConsole.MarkupLine("Presione una tecla para continuar");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "Cambiar puesto del Empleado":
                                bool finalizado6 = false;
                                while (finalizado6 != true)
                                {
                                    Empleado.Puesto = AnsiConsole.Ask<string>("Ingrese el nuevo puesto del Empleado");
                                    AnsiConsole.MarkupLine("Puesto actualizado correctamente a " + Empleado.Puesto + "\n");
                                    var seleccion = AnsiConsole.Prompt(
                                        new SelectionPrompt<String>()
                                        .Title("Desea mantener el nuevo puesto?")
                                        .PageSize(10)
                                        .AddChoices(new[]
                                        {
                                            "Si","No"
                                        }));
                                    switch (seleccion)
                                    {
                                        case "Si":
                                            finalizado6 = true;
                                            _context.Empleados.Update(Empleado);
                                            _context.SaveChanges();
                                            break;
                                        case "No":
                                            Console.Clear();
                                            menu.ImprimirLogo();
                                            break;
                                    }
                                }
                                AnsiConsole.MarkupLine("Presione una tecla para continuar");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "Eliminar Empleado":
                                _context.Empleados.Remove(Empleado);
                                _context.SaveChanges();
                                AnsiConsole.MarkupLine("Empleado eliminado correctamente");
                                AnsiConsole.MarkupLine("Presione una tecla para continuar");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("No se encontro ningun Empleado con ID " + IDCambio);
                        AnsiConsole.MarkupLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    AnsiConsole.MarkupLine("No hay Empleados en el sistema");
                    AnsiConsole.MarkupLine("Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
