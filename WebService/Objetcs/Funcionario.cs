using Newtonsoft.Json;
using System;

namespace WebService.Objetcs
{
    public class Funcionario
    {   /// <summary>
        /// codigo da matricula do funcionario
        /// </summary>
        [JsonProperty("matricula")]
        public int Matricula { get; set; }
        /// <summary>
        /// Nome do funcionario
        /// </summary>
        [JsonProperty("nome")]
        public string Nome { get; set; }
        /// <summary>
        /// area de atuação do funcionario
        /// </summary>
        [JsonProperty("area")]
        public string Area { get; set; }
        /// <summary>
        /// cargo de atuação do funcionario 
        /// </summary>
        [JsonProperty("cargo")]
        public string Cargo { get; set; }
        /// <summary>
        /// valor sem descontos do salario
        /// </summary>
        [JsonProperty("salario_bruto")]
        public decimal SalarioBruto { get; set; }
        /// <summary>
        /// data de admissao do funcionario na empresa
        /// </summary>
        [JsonProperty("data_de_admissao")]
        public DateTime DataDeAdmissao { get; set; }
        /// <summary>
        /// valor de bonus salarial a ser recebido pelo funcionario
        /// </summary>
        [JsonIgnore]
        public decimal BonusSalarial { get; set; }
    }
}
