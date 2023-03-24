using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Clases
{
    public class Producto
    {
        [Key]
        public int ID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int cantidad_inventario { get; set; }
        public decimal precio { get; set; }

        



    }
}
