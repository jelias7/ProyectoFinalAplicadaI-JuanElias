using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public string Modo { get; set; }
        public string Cliente { get; set; }
        public decimal Itbis { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        [Browsable(false)]
        public int UsuarioId { get; set; }
        public virtual List<VentasDetalle> Detalle { get; set; }
        public Ventas()
        {
            VentaId = 0;
            UsuarioId = 0;
            Modo = string.Empty;
            Cliente = string.Empty;
            Itbis = 0;
            Subtotal = 0;
            Total = 0;
            Cantidad = 0;
            Fecha = DateTime.Now;
            Detalle = new List<VentasDetalle>();
        }
    }
}
