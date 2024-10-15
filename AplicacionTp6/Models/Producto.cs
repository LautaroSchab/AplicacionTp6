using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionTp6.Models
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public double precioProducto { get; set; }
        public string categoria { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
    }
}
