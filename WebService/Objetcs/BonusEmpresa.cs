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
            ParticipacoesColecao = new List<Participacoes>();
        }
        /// <summary>
        /// Colecao com participantes
        /// </summary>
        public List<Participacoes> ParticipacoesColecao { get; set; }
        /// <summary>
        /// Quantidade total de funcionarios na empresa
        /// </summary>
        public int Total_De_Funcionarios { get; set; }
        /// <summary>
        /// Soma do que foi pago em PL a todos os funcionários
        /// </summary>
        public decimal Total_Distribuido { get; set; }
        /// <summary>
        /// O valor que a empresa desejava distribuir
        /// </summary>
        public decimal Total_Disponibilizado { get; set; }
        /// <summary>
        /// Total disponibilizado menos o total distribuido
        /// </summary>
        public decimal Saldo_Total_Disponibilizado { get; set; }

    }
}
