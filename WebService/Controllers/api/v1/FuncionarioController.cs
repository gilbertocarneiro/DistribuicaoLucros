using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers.api.v1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class FuncionarioController
    {
        /// <summary>
        /// Get Setors
        /// </summary>
        /// <returns></returns>
        [HttpGet("colecao")]
        public dynamic Get()
        {
            try
            {
                return new FuncionarioModel().ColecaoFuncionario();
            }
            catch
            {
                return null;
            }
        }
    }
}
