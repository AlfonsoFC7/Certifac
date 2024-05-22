using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApICERTIFAC.Models
{
    public class Addendas
    {
      [Key]
      public Guid IdAddenda { get; set; }
      public string NombreAddenda { get; set; }
        public string XML { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Usuario { get; set; }
        public Boolean Estado { get; set; }
    }
}
