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

            using SqlDataReader sqlDataReader = await ExecutaConsultaReader("SELECT [matricula], [nome], [area], [cargo], [salario_bruto], [data_de_admissao] FROM [dbo].[Funcionario]");
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
        /// <param name="data_de_admissao"></param>
        /// <returns>valor do peso</returns>
        public Task<int> CalcularPesoAdmissao(DateTime data_de_admissao)
        {

            TimeSpan tempo = DateTime.Today - data_de_admissao.ToShortDate();

            double tempo_de_casa = tempo.TotalDays / 365;

            if (tempo_de_casa <= 1)
            {
                return Task.FromResult(1);
            }
            else if (tempo_de_casa > 1 && tempo_de_casa < 3)
            {
                return Task.FromResult(2);
            }
            else if (tempo_de_casa >= 3 && tempo_de_casa < 8)
            {
                return Task.FromResult(3);
            }
            else
            {
                return Task.FromResult(5);
            }
        }

        /// <summary>
        /// calcula o peso por faixa salarial e uma exceção para estagiários
        /// </summary>
        /// <param name="salario_bruto"></param>
        /// <param name="profissao"></param>
        /// <returns>valor do peso</returns>
        public Task<int> CalcularPesoSalario(decimal salario_bruto, string profissao)
        {

            decimal salario_minimo = 1100;
            decimal numeros_salario_minimos = salario_bruto / salario_minimo;

            if (numeros_salario_minimos <= 3 || profissao == "Estagiário")
            {
                return Task.FromResult(1);
            }
            else if (numeros_salario_minimos > 3 && numeros_salario_minimos < 5)
            {
                return Task.FromResult(2);
            }
            else if (numeros_salario_minimos >= 5 && numeros_salario_minimos < 8)
            {
                return Task.FromResult(3);
            }
            else
            {
                return Task.FromResult(5);
            }
        }

        /// <summary>
        /// calcula o peso por área de atuação
        /// </summary>
        /// <param name="area"></param>
        /// <returns>valor do peso</returns>
        public Task<int> CalcularPesoAreaAtuacao(string area)
        {

            if (area == "Diretoria")
            {
                return Task.FromResult(1);
            }
            else if (area == "Contabilidade" || area == "Financeiro" || area == "Tecnologia")
            {
                return Task.FromResult(2);
            }
            else if (area == "Serviços Gerais")
            {
                return Task.FromResult(3);
            }
            else
            {
                return Task.FromResult(5);
            }

        }

        /// <summary>
        /// calcula o bonus salarial do funcionarios recebido
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>bonus salarial</returns>
        public async Task<decimal> CalcularBonusSalario(Funcionario funcionario)
        {
            decimal SBxPTA = funcionario.Salario_Bruto * await CalcularPesoAdmissao(funcionario.Data_De_Admissao);
            decimal SBxPAA = funcionario.Salario_Bruto * await CalcularPesoAreaAtuacao(funcionario.Area);
            decimal bonus = ((SBxPTA + SBxPAA) / await CalcularPesoSalario(funcionario.Salario_Bruto, funcionario.Cargo)) * MesesAno;

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
                Salario_Bruto = reader[nameof(Funcionario.Salario_Bruto)].ToString().ToDecimal(),
                Data_De_Admissao = DateTime.Parse(reader[nameof(Funcionario.Data_De_Admissao)].ToString())
            };
        }
    }
}
