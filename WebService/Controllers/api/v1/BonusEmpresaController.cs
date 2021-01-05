﻿using System;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

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
        /// total_disponibilizado: 1000000
        /// 
        /// </remarks>
        /// <param name="total_disponibilizado"></param>
        /// <returns>retorna objeto BonusEmpresa</returns> 
        /// <response code="200">Deve retornar a colecao de funcionarios com seu devido bonus salarial ja calculado juntamente ao saldo restante do lucro que a empresa gostaria de recompensar os funcionarios</response>

        [HttpGet("{total_disponibilizado}")]
        public dynamic Get(decimal total_disponibilizado)
        {
            try
            {
                return new BonusEmpresaModel().GerarBonusFuncionarios(total_disponibilizado);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
