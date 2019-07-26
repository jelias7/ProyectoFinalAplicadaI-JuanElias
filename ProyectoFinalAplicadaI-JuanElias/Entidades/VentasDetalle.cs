using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VentasDetalle
    {
        [Key]
        public int VentaDetalleId { get; set; }
        public int ProductoId { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Impuesto { get; set; }
        public VentasDetalle()
        {
            VentaDetalleId = 0;
            Precio = 0;
            Cantidad = 0;
            Impuesto = 0;
            ProductoId = 0;
        }
    }
}
