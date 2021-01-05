using System;
using System.Collections.Generic;
using WebService.Extensions;
using WebService.Objetcs;

namespace WebService.Models
{
    public class ParticipacoesModel
    {
        public List<Participacoes> GerarParticipacoes(List<Funcionario> funcionarioColecao)
        {
            try
            {
                FuncionarioModel funcionarioModel = new FuncionarioModel();
                List<Participacoes> participacoesColecao = new List<Participacoes>();

                foreach (Funcionario funcionario in funcionarioColecao)
                {
                    Participacoes participacoes = new Participacoes();

                    participacoes.matricula = funcionario.matricula.ToString().PadLeft(7,'0');
                    participacoes.nome = funcionario.nome;
                    funcionario.bonus_salarial = funcionarioModel.CalcularBonusSalario(funcionario);
                    participacoes.valor_da_participação = funcionario.bonus_salarial.FormatarValorDecimal();

                    participacoesColecao.Add(participacoes);
                }

                return participacoesColecao;
            }
            catch
            {
                throw;
            }
        }
    }
}
