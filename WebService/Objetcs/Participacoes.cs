using Newtonsoft.Json;

namespace WebService.Objetcs
{
    public class Participacoes
    {
        /// <summary>
        /// codigo da matricula do funcionario
        /// </summary>
        [JsonProperty("matricula")]
        public string Matricula { get; set; }
        /// <summary>
        /// Nome do funcionario
        /// </summary>
        [JsonProperty("nome")]
        public string Nome { get; set; }
        /// <summary>
        /// valor de bonus salarial a ser recebido pelo funcionario
        /// </summary>
        [JsonProperty("valor_da_participacao")]
        public string ValorDaParticipacao { get; set; }
    }
}
