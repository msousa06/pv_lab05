using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab05.Models
{
    public class Marca
    {
        public int MarcaId { get; set; }
        [DisplayName("Designação")] [Required] [StringLength(15)]public String Designacao { get; set; }

        public virtual ICollection<Carro> Carros { get; set; } 
    }
}
