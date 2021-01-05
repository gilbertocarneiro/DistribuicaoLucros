using System;
using WebService.Tools;
using WebService.Objetcs;
using WebService.Extensions;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace WebService.Models
{
    public class FuncionarioModel : Database
    {
        const int MesesAno = 12;

        /// <summary>
        /// Get Colecao de funcionarios
        /// </summary>
        /// <returns>Colecao de funcionarios</returns>
        public List<Funcionario> ColecaoFuncionario()
        {
            try
            {
                using SqlDataReader sqlDataReader = ExecutaConsultaReader("SELECT [matricula], [nome], [area], [cargo], [salario_bruto], [data_de_admissao] FROM [dbo].[Funcionario]");
                if (!sqlDataReader.HasRows) return null;
                List<Funcionario> funcionariosList = new List<Funcionario>();
                while (sqlDataReader.Read())
                {
                    funcionariosList.Add(DataToFuncionario(sqlDataReader));
                }
                return funcionariosList;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// calcula o peso por tempo de admissão
        /// </summary>
        /// <param name="data_de_admissao"></param>
        /// <returns>valor do peso</returns>
        public int CalcularPesoAdmissao(DateTime data_de_admissao)
        {
            try
            {
                TimeSpan tempo = DateTime.Today - data_de_admissao.ToShortDate();

                double tempo_de_casa = tempo.TotalDays / 365;

                if (tempo_de_casa <= 1)
                {
                    return 1;
                }
                else if (tempo_de_casa > 1 && tempo_de_casa < 3)
                {
                    return 2;
                }
                else if (tempo_de_casa >= 3 && tempo_de_casa < 8)
                {
                    return 3;
                }
                else
                {
                    return 5;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// calcula o peso por faixa salarial e uma exceção para estagiários
        /// </summary>
        /// <param name="salario_bruto"></param>
        /// <param name="profissao"></param>
        /// <returns>valor do peso</returns>
        public int CalcularPesoSalario(decimal salario_bruto, string profissao)
        {
            try
            {
                decimal salario_minimo = 1100;
                decimal numeros_salario_minimos = salario_bruto / salario_minimo;

                if (numeros_salario_minimos <= 3 || profissao == "Estagiário")
                {
                    return 1;
                }
                else if (numeros_salario_minimos > 3 && numeros_salario_minimos < 5)
                {
                    return 2;
                }
                else if (numeros_salario_minimos >= 5 && numeros_salario_minimos < 8)
                {
                    return 3;
                }
                else
                {
                    return 5;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// calcula o peso por área de atuação
        /// </summary>
        /// <param name="area"></param>
        /// <returns>valor do peso</returns>
        public int CalcularPesoAreaAtuacao(string area)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// calcula o bonus salarial do funcionarios recebido
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>bonus salarial</returns>
        public decimal CalcularBonusSalario(Funcionario funcionario)
        {
            try
            {
                decimal SBxPTA = funcionario.salario_bruto * CalcularPesoAdmissao(funcionario.data_de_admissao);
                decimal SBxPAA = funcionario.salario_bruto * CalcularPesoAreaAtuacao(funcionario.area);
                decimal bonus = ((SBxPTA + SBxPAA) / CalcularPesoSalario(funcionario.salario_bruto, funcionario.cargo)) * MesesAno;

                return bonus;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// convert reader para objeto
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>objeto funcionario</returns>
        private Funcionario DataToFuncionario(SqlDataReader reader)
        {
            return new Funcionario()
            {
                matricula = reader[nameof(Funcionario.matricula)].ToString().ToInt(),
                nome = reader[nameof(Funcionario.nome)].ToString(),
                area = reader[nameof(Funcionario.area)].ToString(),
                cargo = reader[nameof(Funcionario.cargo)].ToString(),
                salario_bruto = reader[nameof(Funcionario.salario_bruto)].ToString().ToDecimal(),
                data_de_admissao = DateTime.Parse(reader[nameof(Funcionario.data_de_admissao)].ToString())
            };
        }
    }
}
