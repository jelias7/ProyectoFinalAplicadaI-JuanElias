using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
       // [ForeignKey("Usuarios")]
        public int UsuarioId { get; set; }
        public Secciones()
        {
            SeccionId = 0;
            Nombre = string.Empty;
            UsuarioId = 0;
        }
    }
}
