using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Objetcs
{
    public class BonusEmpresa
    {
        public BonusEmpresa()
        {
            participacoesColecao = new List<Participacoes>();
        }
        /// <summary>
        /// Colecao com participantes
        /// </summary>
        public List<Participacoes> participacoesColecao { get; set; }
        /// <summary>
        /// Quantidade total de funcionarios na empresa
        /// </summary>
        public int total_de_funcionarios { get; set; }
        /// <summary>
        /// Soma do que foi pago em PL a todos os funcionários
        /// </summary>
        public decimal total_distribuido { get; set; }
        /// <summary>
        /// O valor que a empresa desejava distribuir
        /// </summary>
        public decimal total_disponibilizado { get; set; }
        /// <summary>
        /// Total disponibilizado menos o total distribuido
        /// </summary>
        public decimal saldo_total_disponibilizado { get; set; }

    }
}
