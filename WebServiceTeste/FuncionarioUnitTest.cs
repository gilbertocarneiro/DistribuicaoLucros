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
        public void Get_DeveRetornarColecao()
        {
            try
            {
                List<Funcionario> funcionarios = new List<Funcionario>();
                FuncionarioModel funcionarioModel = new FuncionarioModel();

                funcionarios = funcionarioModel.ColecaoFuncionario();

                Assert.NotEmpty(funcionarios);
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
        public void CalcularPesoPorAdmissao(string date, int expected)
        {
            try
            {
                FuncionarioModel funcionarioModel = new FuncionarioModel();

                Assert.Equal(expected, funcionarioModel.CalcularPesoAdmissao(Convert.ToDateTime(date)));
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
        public void CalcularPesoPorSalario(decimal salario_bruto, string profissao, int expected)
        {
            try
            {
                FuncionarioModel funcionarioModel = new FuncionarioModel();

                Assert.Equal(expected, funcionarioModel.CalcularPesoSalario(salario_bruto, profissao));
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
        public void CalcularPesoPorArea(string area, int expected)
        {
            try
            {
                FuncionarioModel funcionarioModel = new FuncionarioModel();

                Assert.Equal(expected, funcionarioModel.CalcularPesoAreaAtuacao(area));
            }
            catch (Exception ex)
            {
                Assert.Throws<Exception>(() => ex.Message);
            }
        }

        [Fact]
        public void Get_CalcularBonus()
        {
            try
            {
                decimal expected = 83791.20m;
                List<Funcionario> funcionarios = new List<Funcionario>();
                FuncionarioModel funcionarioModel = new FuncionarioModel();

                funcionarios = funcionarioModel.ColecaoFuncionario();

                Assert.Equal(expected, funcionarioModel.CalcularBonusSalario(funcionarios[1]));
            }
            catch (Exception ex)
            {
                Assert.Throws<Exception>(() => ex.Message);
            }
        }

    }
}
