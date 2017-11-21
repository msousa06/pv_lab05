using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab05.Models
{
    public class Carro
    {
        public int CarroId { get; set; }
        public String Modelo { get; set; }
        public int NumeroDePassageiros { get; set; }
        public int NumeroDePortas { get; set; }
        public int EmissoesCO2 { get; set; }
        public String TipoCaixa { get; set; }
        public int MarcaId { get; set; }

        public virtual Marca Marca { get; set; }

    }
}
