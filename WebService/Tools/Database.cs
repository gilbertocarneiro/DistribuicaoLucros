using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebService.Tools
{
    public class Database
    {
        protected const int TIMEOUT_BANCO = 20;

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
            SqlConnection sqlConnection = CriarConexao();

            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = nomeStoredProcedureOuTextoSql;
            sqlCommand.CommandTimeout = TIMEOUT_BANCO;
            parametroSqls?.ForEach(sqlParameter =>
            {
                if (sqlParameter.Value == null)
                {
                    sqlParameter.Value = DBNull.Value;
                }
                sqlCommand.Parameters.Add(sqlParameter.ParameterName, sqlParameter.Type).Value = sqlParameter.Value;
            });
            return await sqlCommand.ExecuteReaderAsync(CommandBehavior.CloseConnection);
        }
    }
}
