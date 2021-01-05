using System;
using WebService.Tools;
using WebService.Objetcs;
using WebService.Extensions;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class FuncionarioModel : Database
    {
        const int MesesAno = 12;

        /// <summary>
        /// Get Colecao de funcionarios
        /// </summary>
        /// <returns>Colecao de funcionarios</returns>
        public async Task<List<Funcionario>> ColecaoFuncionario()
        {

            using SqlDataReader sqlDataReader = await ExecutaConsultaReader("SELECT [Matricula], [Nome], [Area], [Cargo], [SalarioBruto], [DataDeAdmissao] FROM [dbo].[Funcionario]");
            if (!sqlDataReader.HasRows) return null;
            List<Funcionario> funcionariosList = new List<Funcionario>();
            while (sqlDataReader.Read())
            {
                funcionariosList.Add(DataToFuncionario(sqlDataReader));
            }
            return funcionariosList;
        }

        /// <summary>
        /// calcula o peso por tempo de admissão
        /// </summary>
        /// <param name="dataDeAdmissao"></param>
        /// <returns>valor do peso</returns>
        public int CalcularPesoAdmissao(DateTime dataDeAdmissao)
        {

            TimeSpan tempo = DateTime.Today - dataDeAdmissao.ToShortDate();

            double tempoDeCasa = tempo.TotalDays / 365;

            if (tempoDeCasa <= 1)
            {
                return 1;
            }
            else if (tempoDeCasa > 1 && tempoDeCasa < 3)
            {
                return 2;
            }
            else if (tempoDeCasa >= 3 && tempoDeCasa < 8)
            {
                return 3;
            }
            else
            {
                return 5;
            }
        }

        /// <summary>
        /// calcula o peso por faixa salarial e uma exceção para estagiários
        /// </summary>
        /// <param name="salarioBruto"></param>
        /// <param name="profissao"></param>
        /// <returns>valor do peso</returns>
        public int CalcularPesoSalario(decimal salarioBruto, string profissao)
        {

            decimal salarioMinimo = 1100;
            decimal numeroDeSalariosMinimos = salarioBruto / salarioMinimo;

            if (numeroDeSalariosMinimos <= 3 || profissao == "Estagiário")
            {
                return 1;
            }
            else if (numeroDeSalariosMinimos > 3 && numeroDeSalariosMinimos < 5)
            {
                return 2;
            }
            else if (numeroDeSalariosMinimos >= 5 && numeroDeSalariosMinimos < 8)
            {
                return 3;
            }
            else
            {
                return 5;
            }
        }

        /// <summary>
        /// calcula o peso por área de atuação
        /// </summary>
        /// <param name="area"></param>
        /// <returns>valor do peso</returns>
        public int CalcularPesoAreaAtuacao(string area)
        {

            if (area == "Diretoria")
            {
                return 1;
            }
            else if (area == "Contabilidade" || area == "Financeiro" || area == "Tecnologia")
            {
                return 2;
            }
            else if (area == "Serviços Gerais")
            {
                return 3;
            }
            else
            {
                return 5;
            }

        }

        /// <summary>
        /// calcula o bonus salarial do funcionarios recebido
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>bonus salarial</returns>
        public decimal CalcularBonusSalario(Funcionario funcionario)
        {
            decimal sBxPTA = funcionario.SalarioBruto * CalcularPesoAdmissao(funcionario.DataDeAdmissao);
            decimal sBxPAA = funcionario.SalarioBruto * CalcularPesoAreaAtuacao(funcionario.Area);
            decimal bonus = ((sBxPTA + sBxPAA) / CalcularPesoSalario(funcionario.SalarioBruto, funcionario.Cargo)) * MesesAno;

            return bonus;
        }

        /// <summary>
        /// convert reader para objeto
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>objeto funcionario</returns>
        private static Funcionario DataToFuncionario(SqlDataReader reader)
        {
            return new Funcionario()
            {
                Matricula = reader[nameof(Funcionario.Matricula)].ToString().ToInt(),
                Nome = reader[nameof(Funcionario.Nome)].ToString(),
                Area = reader[nameof(Funcionario.Area)].ToString(),
                Cargo = reader[nameof(Funcionario.Cargo)].ToString(),
                SalarioBruto = reader[nameof(Funcionario.SalarioBruto)].ToString().ToDecimal(),
                DataDeAdmissao = DateTime.Parse(reader[nameof(Funcionario.DataDeAdmissao)].ToString())
            };
        }
    }
}
