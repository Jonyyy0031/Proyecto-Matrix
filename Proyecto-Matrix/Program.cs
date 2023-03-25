using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.Data.SqlClient;
using Proyecto_Matrix.Clases;
using Proyecto_Matrix.Context;
using Proyecto_Matrix.Funciones;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Proyecto_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            CRUD_USUARIOS crud = new CRUD_USUARIOS();
            crud.viewUser();
            */
            Login login = new Login();
            login.Sesion();
        }
    }
}
