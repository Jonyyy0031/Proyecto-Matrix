using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Proyecto_Matrix.Clases;
using Proyecto_Matrix.Context;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Funciones
{
    public class CRUDProducto
    {
        public void CrearProducto()
        {
            using (var _context = new ApplicationDbContext())
            {
                bool salir = false;
                while (salir != true)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    Menus menu = new Menus();
                    //TODO ADENTRO SE AGREGA
                    Producto producto = new Producto();
                        producto.nombre = AnsiConsole.Ask<string>("Ingresa el Nombre del Producto");
                        producto.descripcion = AnsiConsole.Ask<string>("Ingresa la descripcion breve del producto");
                        producto.precio = AnsiConsole.Ask<decimal>("Ingresa el precio del producto");
                        producto.cantidad_inventario = AnsiConsole.Ask<int>("¿Cuantos hay en el inventario?");
                        _context.productos.Add(producto);
                        _context.SaveChanges();
                        Console.Clear();
                        menu.ImprimirLogo();
                        var Seleccion = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("¿Desea agregar otro producto?")
                            .PageSize(10)
                            .AddChoices(new[]
                            {
                       "Si","No"
                            }));
                        switch (Seleccion)
                        {
                            case "No":
                                AnsiConsole.MarkupLine("Producto agregado con exito");
                                salir = true;
                                break;
                        }
                }
            }
        }
        public void VisualizarProductos()
        {
            using (var _context = new ApplicationDbContext())
            {
                if (_context.productos.Any())
                {
                    AnsiConsole.Status()
                            .Start("Espere por favor...", ctx =>
                            {
                                AnsiConsole.MarkupLine("Cargando Tabla...");
                                Thread.Sleep(1000);
                                ctx.Status("Espere por favor...");
                                ctx.Spinner(Spinner.Known.Aesthetic);
                                ctx.SpinnerStyle(Style.Parse("green"));
                                AnsiConsole.MarkupLine("Organizando Productos...");
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
                            table.Title("Inventario");
                            table.AddColumn("ID");
                            table.AddColumn("Nombre del producto ");
                            table.AddColumn("Descripcion del producto");
                            table.AddColumn("Precio del producto");
                            table.AddColumn("Cantidad disponible");
                            using (var _context = new ApplicationDbContext())
                            {
                                var productos = _context.productos.ToList();
                                foreach (Producto item in productos)
                                {
                                    table.AddRow("" + item.ID, "" + item.nombre, "" + item.descripcion, "" + item.precio, "" + item.cantidad_inventario);
                                }
                            }
                        });
                    Console.WriteLine("Presiona una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    AnsiConsole.MarkupLine("No hay productos en el inventario");
                    AnsiConsole.MarkupLine("Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        public void ModificacionProductos()
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                Menus menu = new Menus();
                if (_context.productos.Any())
                {
                    int IDCambio = AnsiConsole.Ask<int>("Ingrese la ID del producto a modificar");
                    Console.Clear();
                    menu.ImprimirLogo();
                    Producto producto = _context.productos.Find(IDCambio);
                    if (producto != null)
                    {
                        var Cambio = AnsiConsole.Prompt(
                            new SelectionPrompt<String>()
                            .Title("¿Que desea Realizar?")
                            .PageSize(10)
                            .AddChoices(new[]
                            {
                            "Cambiar Nombre del producto","Cambiar Descripcion del producto","Cambiar Precio del Producto","Cambiar Cantidad Disponible del producto",
                            "Cambiar toda la informacion del producto","Eliminar el producto"
                            }));
                        switch (Cambio)
                        {
                            case "Cambiar Nombre del producto":
                                bool finalizado = false;
                                while (finalizado != true)
                                {
                                    producto.nombre = AnsiConsole.Ask<string>("Ingrese el nuevo nombre del producto");
                                    AnsiConsole.MarkupLine("Nombre del producto actualizado correctamente a " +producto.nombre+"\n");
                                    var seleccion = AnsiConsole.Prompt(
                                        new SelectionPrompt<String>()
                                        .Title("Desea mantener el nuevo nombre?")
                                        .PageSize(10)
                                        .AddChoices(new[]
                                        {
                                            "Si","No"
                                        }));
                                   switch (seleccion)
                                    {
                                        case "Si":
                                            finalizado = true;
                                            _context.productos.Update(producto);
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
                            case "Cambiar Descripcion del producto":
                                bool finalizado1 = false;
                                while (finalizado1 != true)
                                {
                                    producto.descripcion = AnsiConsole.Ask<string>("Ingrese el nuevo nombre del producto");
                                    AnsiConsole.MarkupLine("Nombre del producto actualizado correctamente a " + producto.descripcion + "\n");
                                    var seleccion = AnsiConsole.Prompt(
                                        new SelectionPrompt<String>()
                                        .Title("Desea mantener la nueva descripción?")
                                        .PageSize(10)
                                        .AddChoices(new[]
                                        {
                                            "Si","No"
                                        }));
                                    switch (seleccion)
                                    {
                                        case "Si":
                                            finalizado1 = true;
                                            _context.productos.Update(producto);
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
                            case "Cambiar Precio del Producto":
                                bool finalizado3 = false;
                                while (finalizado3 != true)
                                {
                                    producto.precio = AnsiConsole.Ask<int>("Ingrese el nuevo nombre del producto");
                                    AnsiConsole.MarkupLine("precio del producto actualizado correctamente a " + producto.precio + "\n");
                                    var seleccion = AnsiConsole.Prompt(
                                        new SelectionPrompt<String>()
                                        .Title("Desea mantener el precio que selecciono?")
                                        .PageSize(10)
                                        .AddChoices(new[]
                                        {
                                            "Si","No"
                                        }));
                                    switch (seleccion)
                                    {
                                        case "Si":
                                            finalizado3 = true;
                                            _context.productos.Update(producto);
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
                            case "Cambiar Cantidad Disponible del producto":
                                bool finalizado4 = false;
                                while (finalizado4 != true)
                                {
                                    producto.nombre = AnsiConsole.Ask<string>("Ingrese la nueva cantidad disponible");
                                    AnsiConsole.MarkupLine("Nombre del producto actualizado correctamente a " + producto.cantidad_inventario + "\n");
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
                                            _context.productos.Update(producto);
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
                            case "Cambiar toda la informacion del producto":
                                bool finalizado5 = false;
                                while (finalizado5 != true)
                                {
                                    producto.nombre = AnsiConsole.Ask<string>("Ingrese el nuevo nombre del producto");
                                    producto.descripcion = AnsiConsole.Ask<string>("Ingrese la nueva descripcion");
                                    producto.precio = AnsiConsole.Ask<int>("Ingrese el nuevo precio");
                                    producto.cantidad_inventario = AnsiConsole.Ask<int>("Ingrese la nueva cantidad disponible");
                                    AnsiConsole.MarkupLine("producto actualizado correctamente a:\nNombre: " + producto.nombre +"\n Descripcion: "+producto.descripcion+
                                        "\nPrecio: "+producto.precio+"\nCantidad: "+producto.cantidad_inventario+ "\n");
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
                                            _context.productos.Update(producto);
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
                            case "Eliminar el producto":
                                _context.productos.Remove(producto);
                                _context.SaveChanges();
                               _context.productos.Update(producto);
                                AnsiConsole.MarkupLine("Producto eliminado correctamente");
                                AnsiConsole.MarkupLine("Presione una tecla para continuar");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("No se encontro ningun producto con ID "+IDCambio);
                        AnsiConsole.MarkupLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    AnsiConsole.MarkupLine("No hay productos en el inventario");
                    AnsiConsole.MarkupLine("Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}