using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab05.Models
{
    public class Carro
    {
        public int CarroId { get; set; }
        [Required] [StringLength(20)] public String Modelo { get; set; }
        [DisplayName("Número de passageiros")][Range (2,9)]public int NumeroDePassageiros { get; set; }
        [DisplayName("Número de portas")] [Range(2,5)] public int NumeroDePortas { get; set; }
        [DisplayName("Emissões de CO2")] public int EmissoesCO2 { get; set; }
        [DisplayName("Tipo de Caixa")] public String TipoCaixa { get; set; }
        public int MarcaId { get; set; }

        public virtual Marca Marca { get; set; }

    }
}
