using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.Extensions;
using WebService.Objetcs;

namespace WebService.Models
{
    public class ParticipacoesModel
    {
        public List<Participacoes> GerarParticipacoes(List<Funcionario> funcionarioColecao)
        {

            FuncionarioModel funcionarioModel = new FuncionarioModel();
            List<Participacoes> participacoesColecao = new List<Participacoes>();

            foreach (Funcionario funcionario in funcionarioColecao)
            {
                Participacoes participacoes = new Participacoes
                {
                    Matricula = funcionario.Matricula.ToString().PadLeft(7, '0'),
                    Nome = funcionario.Nome
                };

                funcionario.BonusSalarial = funcionarioModel.CalcularBonusSalario(funcionario);
                participacoes.ValorDaParticipação = funcionario.BonusSalarial.FormatarValorDecimal();

                participacoesColecao.Add(participacoes);
            }

            return participacoesColecao;
        }
    }
}
