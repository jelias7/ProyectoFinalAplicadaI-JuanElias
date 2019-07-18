using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public int Codigo { get; set; }
        public string Producto { get; set; }
        public string Proveedor { get; set; }
        public string Seccion { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public decimal Ganancia { get; set; }
        public int Cantidad { get; set; }
        public decimal ITBIS { get; set; }
        public DateTime Vencimiento { get; set; }
        [Browsable(false)]
        public int UsuarioId { get; set; }
        public Productos()
        {
            ProductoId = 0;
            Codigo = 0;
            Producto = string.Empty;
            Proveedor = string.Empty;
            Seccion = string.Empty;
            Precio = 0;
            Costo = 0;
            Cantidad = 0;
            Ganancia = 0;
            ITBIS = 0;
            Vencimiento = DateTime.Now;
            UsuarioId = 0;
        }
    }
}
