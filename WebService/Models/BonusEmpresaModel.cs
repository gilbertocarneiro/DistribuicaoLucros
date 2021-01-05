using System;
using System.Collections.Generic;
using System.Linq;
using WebService.Extensions;
using WebService.Objetcs;

namespace WebService.Models
{
    public class BonusEmpresaModel
    {
        /// <summary>
        /// Monta o objeto BonusEmpresa para chegar no montante repartido de bonus salarial aos funcionarios
        /// </summary>
        /// <param name="total_disponibilizado"></param>
        /// <returns>Objeto BonusEmpresa</returns>
        public BonusEmpresa GerarBonusFuncionarios(decimal total_disponibilizado)
        {

                ParticipacoesModel participacoesModel = new ParticipacoesModel();
                FuncionarioModel funcionarioModel = new FuncionarioModel();
                List<Funcionario> funcionarioColecao = funcionarioModel.ColecaoFuncionario();

                BonusEmpresa bonusEmpresa = new BonusEmpresa();

                bonusEmpresa.participacoesColecao = participacoesModel.GerarParticipacoes(funcionarioColecao);
                bonusEmpresa.total_de_funcionarios = bonusEmpresa.participacoesColecao.Count();
                bonusEmpresa.total_disponibilizado = total_disponibilizado;
                bonusEmpresa.total_distribuido = funcionarioColecao.Sum(x =>  x.bonus_salarial).ToDecimal(2);
                bonusEmpresa.saldo_total_disponibilizado = (bonusEmpresa.total_disponibilizado - bonusEmpresa.total_distribuido).ToDecimal(2);

                if (bonusEmpresa.saldo_total_disponibilizado < 0)
                {
                    throw new ArgumentException($"O valor informado pela empresa é insuficiente para fazer a divisão de lucros.");
                }

                return bonusEmpresa;
        }
    }
}
