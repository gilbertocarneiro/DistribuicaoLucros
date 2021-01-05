using System;

namespace WebService.Objetcs
{
    public class Funcionario
    {   /// <summary>
        /// codigo da matricula do funcionario
        /// </summary>
        public int Matricula { get; set; }
        /// <summary>
        /// Nome do funcionario
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// area de atuação do funcionario
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// cargo de atuação do funcionario 
        /// </summary>
        public string Cargo { get; set; }
        /// <summary>
        /// valor sem descontos do salario
        /// </summary>
        public decimal SalarioBruto { get; set; }
        /// <summary>
        /// data de admissao do funcionario na empresa
        /// </summary>
        public DateTime DataDeAdmissao { get; set; }
        /// <summary>
        /// valor de bonus salarial a ser recebido pelo funcionario
        /// </summary>
        public decimal BonusSalarial { get; set; }
    }
}
