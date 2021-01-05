using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;
using WebService.Objetcs;

namespace WebService.Controllers.api.v1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class BonusEmpresaController
    {
        /// <summary>
        /// Baseado no valor disponibilizado pela empresa, sera feito a tentativa de calcular o bonus de salarios dos funcionarios
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        /// TotalDisponibilizado: 1000000
        /// 
        /// </remarks>
        /// <param name="totalDisponibilizado"></param>
        /// <returns>retorna objeto BonusEmpresa</returns> 
        /// <response code="200">Deve retornar a colecao de funcionarios com seu devido bonus salarial ja calculado juntamente ao saldo restante do lucro que a empresa gostaria de recompensar os funcionarios</response>

        [HttpGet("{totalDisponibilizado}")]
        public async Task<IActionResult> Get(decimal totalDisponibilizado)
        {
            try
            {
                BonusEmpresaModel bonusEmpresaModel = new BonusEmpresaModel();
                BonusEmpresa bonusEmpresa = await bonusEmpresaModel.GerarBonusFuncionarios(totalDisponibilizado);
                 
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
