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
        /// <param name="total_disponibilizado"></param>
        /// <returns>Objeto BonusEmpresa</returns>
        public async Task<IActionResult> GerarBonusFuncionarios(decimal total_disponibilizado)
        {
            try
            {
                ParticipacoesModel participacoesModel = new ParticipacoesModel();
                FuncionarioModel funcionarioModel = new FuncionarioModel();
                List<Funcionario> funcionarioColecao = await funcionarioModel.ColecaoFuncionario();

                BonusEmpresa bonusEmpresa = new BonusEmpresa
                {
                    ParticipacoesColecao = await participacoesModel.GerarParticipacoes(funcionarioColecao)
                };

                bonusEmpresa.Total_De_Funcionarios = bonusEmpresa.ParticipacoesColecao.Count;
                bonusEmpresa.Total_Disponibilizado = total_disponibilizado;
                bonusEmpresa.Total_Distribuido = funcionarioColecao.Sum(x => x.Bonus_Salarial).ToDecimal(2);
                bonusEmpresa.Saldo_Total_Disponibilizado = (bonusEmpresa.Total_Disponibilizado - bonusEmpresa.Total_Distribuido).ToDecimal(2);


                if (bonusEmpresa.Saldo_Total_Disponibilizado < 0)
                {
                    throw new ArgumentException($"O valor informado pela empresa é insuficiente para fazer a divisão de lucros.");
                }
                return new JsonResult(bonusEmpresa);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError 
                };
            }

        }
    }
}
