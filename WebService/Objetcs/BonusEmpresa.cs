using Newtonsoft.Json;
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
        [JsonProperty("participacoes")]
        public List<Participacoes> ParticipacoesColecao { get; set; }
        /// <summary>
        /// Quantidade total de funcionarios na empresa
        /// </summary>
        [JsonProperty("total_de_funcionarios")]
        public int TotalDeFuncionarios { get; set; }
        /// <summary>
        /// Soma do que foi pago em PL a todos os funcionários
        /// </summary>
        [JsonProperty("total_distribuido")]
        public decimal TotalDistribuido { get; set; }
        /// <summary>
        /// O valor que a empresa desejava distribuir
        /// </summary>
        [JsonProperty("total_disponibilizado")]
        public decimal TotalDisponibilizado { get; set; }
        /// <summary>
        /// Total disponibilizado menos o total distribuido
        /// </summary>
        [JsonProperty("saldo_total_disponibilizado")]
        public decimal SaldoTotalDisponibilizado { get; set; }

    }
}
