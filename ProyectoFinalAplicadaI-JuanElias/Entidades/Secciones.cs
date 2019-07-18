using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Secciones
    {
        [Key]
        public int SeccionId { get; set; }
        public string Nombre { get; set; }
        [Browsable(false)]
        public int UsuarioId { get; set; }
        public Secciones()
        {
            SeccionId = 0;
            Nombre = string.Empty;
            UsuarioId = 0;
        }
    }
}
