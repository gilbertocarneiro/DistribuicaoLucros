using System;

namespace WebService.Objetcs
{
    public class Funcionario
    {
        public int matricula { get; set; }
        public string nome { get; set; }
        public string area { get; set; }
        public string cargo { get; set; }
        public decimal salario_bruto { get; set; }
        public DateTime data_de_admissao { get; set; }
    }
}
