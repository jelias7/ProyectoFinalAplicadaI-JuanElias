using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Inventarios
    {
        [Key]
        public int InventarioId { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        [Browsable(false)]
        public int UsuarioId { get; set; }
        public Inventarios()
        {
            InventarioId = 0;
            Producto = string.Empty;
            Cantidad = 0;
            UsuarioId = 0;
        }

    }
}
