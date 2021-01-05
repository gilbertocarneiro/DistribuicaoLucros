using Xunit;
using System;
using WebService.Models;
using WebService.Objetcs;
using System.Collections.Generic;

namespace WebServiceTeste
{
    public class FuncionarioUnitTest
    {
        [Fact]
        public async void Get_DeveRetornarColecao()
        {
            try
            {
                List<Funcionario> FuncionarioColecao = new List<Funcionario>();
                FuncionarioModel funcionarioModel = new FuncionarioModel();

                FuncionarioColecao = await funcionarioModel.ColecaoFuncionario();

                Assert.NotEmpty(FuncionarioColecao);
            }          
            catch (Exception ex)
            {
                Assert.Throws<Exception>(() => ex.Message);
            }
}

        [Theory]
        [InlineData("2010-5-20", 5)]
        [InlineData("2015-5-20", 3)]
        [InlineData("2019-1-1", 2)]
        [InlineData("2021-1-1", 1)]
        public async void CalcularPesoPorAdmissao(string Date, int Expected)
        {
            try
            {
                FuncionarioModel FuncionarioModel = new FuncionarioModel();

                Assert.Equal(Expected, await FuncionarioModel.CalcularPesoAdmissao(Convert.ToDateTime(Date)));
            }
            catch (Exception ex)
            {
                Assert.Throws<Exception>(() => ex.Message);
            }
        }

        [Theory]
        [InlineData(1019, "JovemAprendiz", 1)]
        [InlineData(4000, "Líder de Ouvidoria", 2)]
        [InlineData(7000, "Programador", 3)]
        [InlineData(18500, "Estagiário", 1)]
        [InlineData(18500, "Diretor", 5)]
        public async void CalcularPesoPorSalario(decimal Salario_Bruto, string Profissao, int Expected)
        {
            try
            {
                FuncionarioModel FuncionarioModel = new FuncionarioModel();

                Assert.Equal(Expected,await FuncionarioModel.CalcularPesoSalario(Salario_Bruto, Profissao));
            }
            catch (Exception ex)
            {
                Assert.Throws<Exception>(() => ex.Message);
            }
        }

        [Theory]
        [InlineData("Diretoria", 1)]
        [InlineData("Contabilidade", 2)]
        [InlineData("Financeiro", 2)]
        [InlineData("Tecnologia", 2)]
        [InlineData("Serviços Gerais", 3)]
        [InlineData("Relacionamento com o Cliente", 5)]
        public async void CalcularPesoPorArea(string Area, int Expected)
        {
            try
            {
                FuncionarioModel FuncionarioModel = new FuncionarioModel();

                Assert.Equal(Expected, await FuncionarioModel.CalcularPesoAreaAtuacao(Area));
            }
            catch (Exception ex)
            {
                Assert.Throws<Exception>(() => ex.Message);
            }
        }

        [Fact]
        public async void Get_CalcularBonus()
        {
            try
            {
                decimal Expected = 83791.20m;
                List<Funcionario> funcionarioColecao = new List<Funcionario>();
                FuncionarioModel FuncionarioModel = new FuncionarioModel();

                funcionarioColecao = await FuncionarioModel.ColecaoFuncionario();

                Assert.Equal(Expected, await FuncionarioModel.CalcularBonusSalario(funcionarioColecao[1]));
            }
            catch (Exception ex)
            {
                Assert.Throws<Exception>(() => ex.Message);
            }
        }

    }
}
