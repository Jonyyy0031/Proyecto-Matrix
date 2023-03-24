using System;
using Spectre.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Funciones
{
    public class inventario
    {
     public void agregarproducto()
        {
            CRUDProducto FuncionCRUD = new CRUDProducto();
            FuncionCRUD.CrearProducto();
            
        }
    public void visualizaciondeinventario()
        {
            CRUDProducto FuncionCRUD = new CRUDProducto();
            FuncionCRUD.VisualizarProductos();
        }

    public void ModificarInventario()
        {
            CRUDProducto FuncionCRUD = new CRUDProducto();
            FuncionCRUD.ModificacionProductos();
        }
    }
}
