using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab05.Models
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public String Designacao { get; set; }

        public virtual ICollection<Carro> Carros { get; set; } 
    }
}
