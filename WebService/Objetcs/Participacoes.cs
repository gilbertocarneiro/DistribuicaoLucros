using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Objetcs
{
    public class Participacoes
    {
        public Participacoes()
        {
            participacao = new List<Participacao>();
        }

        public List<Participacao> participacao { get; set; }
        public int total_de_funcionarios { get; set; }
        public decimal total_distribuido { get; set; }
        public decimal total_disponibilizado { get; set; }
        public decimal saldo_total_disponibilizado { get; set; }

    }
}
