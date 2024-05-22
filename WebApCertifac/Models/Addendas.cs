using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApCertifac.Models
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
        public int Estado2 { get; set; }
    }
}
