using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebService.Tools
{
    public class Database
    {
        protected const int TimeoutBanco = 20;

        private static SqlConnectionStringBuilder GetConnectionServer()
        {
            return new SqlConnectionStringBuilder
            {
                DataSource = "tesouraria.database.windows.net",
                UserID = "stone",
                Password = "pagamento+-123",
                InitialCatalog = "stone"
            };
        }

        private static SqlConnection CriarConexao()
        {
            return new SqlConnection(GetConnectionServer().ToString());
        }

        protected async Task<SqlDataReader> ExecutaConsultaReader(string nomeStoredProcedureOuTextoSql, List<ParametroSql> parametroSqls = null)
        {
            SqlConnection SqlConnection = CriarConexao();

            SqlConnection.Open();
            SqlCommand SqlCommand = SqlConnection.CreateCommand();
            SqlCommand.Connection = SqlConnection;
            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.CommandText = nomeStoredProcedureOuTextoSql;
            SqlCommand.CommandTimeout = TimeoutBanco;
            parametroSqls?.ForEach(sqlParameter =>
            {
                if (sqlParameter.Value == null)
                {
                    sqlParameter.Value = DBNull.Value;
                }
                SqlCommand.Parameters.Add(sqlParameter.ParameterName, sqlParameter.Type).Value = sqlParameter.Value;
            });
            return await SqlCommand.ExecuteReaderAsync(CommandBehavior.CloseConnection);
        }
    }
}
