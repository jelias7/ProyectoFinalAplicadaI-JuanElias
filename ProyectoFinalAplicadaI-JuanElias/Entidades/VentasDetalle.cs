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
        public int VentaId { get; set; }
        [Browsable(false)]
        public int UsuarioId { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
