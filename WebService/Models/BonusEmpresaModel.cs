using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Extensions;
using WebService.Objetcs;

namespace WebService.Models
{
    public class BonusEmpresaModel
    {
        /// <summary>
        /// Monta o objeto BonusEmpresa para chegar no montante repartido de bonus salarial aos funcionarios
        /// </summary>
        /// <param name="totalDisponibilizado"></param>
        /// <returns>Objeto BonusEmpresa</returns>
        public async Task<BonusEmpresa> GerarBonusFuncionarios(decimal totalDisponibilizado)
        {
            ParticipacoesModel participacoesModel = new ParticipacoesModel();
            FuncionarioModel funcionarioModel = new FuncionarioModel();
            List<Funcionario> funcionarioColecao = await funcionarioModel.ColecaoFuncionario();

            BonusEmpresa bonusEmpresa = new BonusEmpresa
            {
                ParticipacoesColecao = participacoesModel.GerarParticipacoes(funcionarioColecao)
            };

            bonusEmpresa.TotalDeFuncionarios = bonusEmpresa.ParticipacoesColecao.Count;
            bonusEmpresa.TotalDisponibilizado = totalDisponibilizado;
            bonusEmpresa.TotalDistribuido = funcionarioColecao.Sum(x => x.BonusSalarial).ToDecimal(2);
            bonusEmpresa.SaldoTotalDisponibilizado = (bonusEmpresa.TotalDisponibilizado - bonusEmpresa.TotalDistribuido).ToDecimal(2);

            if (bonusEmpresa.SaldoTotalDisponibilizado < 0)
            {
                throw new ArgumentException($"O valor informado pela empresa é insuficiente para fazer a divisão de lucros.");
            }
            return bonusEmpresa;
        }
    }
}
