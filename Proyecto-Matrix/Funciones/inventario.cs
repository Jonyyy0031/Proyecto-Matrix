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
            CRUDCurso FuncionCRUD = new CRUDCurso();
            FuncionCRUD.CrearProducto();
            
        }
    public void visualizaciondeinventario()
        {
            CRUDCurso FuncionCRUD = new CRUDCurso();
            FuncionCRUD.VisualizarProductos();
        }

    public void ModificarInventario()
        {
            CRUDCurso FuncionCRUD = new CRUDCurso();
            FuncionCRUD.ModificacionProductos();
        }
    }
}
