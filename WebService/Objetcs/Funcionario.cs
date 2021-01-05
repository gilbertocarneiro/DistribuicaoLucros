using System;

namespace WebService.Objetcs
{
    public class Funcionario
    {   /// <summary>
        /// codigo da matricula do funcionario
        /// </summary>
        public int matricula { get; set; }
        /// <summary>
        /// Nome do funcionario
        /// </summary>
        public string nome { get; set; }
        /// <summary>
        /// area de atuação do funcionario
        /// </summary>
        public string area { get; set; }
        /// <summary>
        /// cargo de atuação do funcionario 
        /// </summary>
        public string cargo { get; set; }
        /// <summary>
        /// valor sem descontos do salario
        /// </summary>
        public decimal salario_bruto { get; set; }
        /// <summary>
        /// data de admissao do funcionario na empresa
        /// </summary>
        public DateTime data_de_admissao { get; set; }
        /// <summary>
        /// valor de bonus salarial a ser recebido pelo funcionario
        /// </summary>
        public decimal bonus_salarial { get; set; }
    }
}
