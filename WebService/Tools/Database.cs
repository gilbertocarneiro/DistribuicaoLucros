using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace WebService.Tools
{
    public class Database
    {
        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;
        private string SQL = string.Empty;
        protected const int TIMEOUT_BANCO = 20;

        private SqlConnectionStringBuilder GetConnectionServer()
        {
            return new SqlConnectionStringBuilder
            {
                DataSource = "tesouraria.database.windows.net",
                UserID = "stone",
                Password = "pagamento+-123",
                InitialCatalog = "stone"
            };
        }

        private SqlConnection CriarConexao()
        {
            try
            {
                return new SqlConnection(GetConnectionServer().ToString());
            }
            catch
            {
                throw;
            }
        }

        protected void AdicionarParametroPorNomeEValor(String nomeDoParametro, object valorDoParametro)
        {
            try
            {
                sqlParameterCollection.AddWithValue(nomeDoParametro, valorDoParametro);
            }
            catch
            {
                throw;
            }
        }

        protected SqlDataReader ExecutaConsultaReader(string nomeStoredProcedureOuTextoSql, List<ParametroSql> parametroSqls = null)
        {
            SqlConnection sqlConnection = CriarConexao();
            try
            {
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
                return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                throw;
            }
        }


        protected dynamic ExecutaAlteracao(string nomeStoredProcedureOuTextoSql, List<ParametroSql> parametroSqls)
        {
            try
            {
                object i;
                using (SqlConnection sqlConnection = CriarConexao())
                {
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
                    i = sqlCommand.ExecuteNonQuery();
                }
                return i;
            }
            catch
            {
                throw;
            }
        }

        public class Transaction : Database
        {
            public SqlConnection SqlConnection { get; set; }
            public SqlTransaction SqlTransaction { get; set; }

            public Transaction()
            {
                this.SqlConnection = CriarConexao();
                this.SqlTransaction = GetTransaction(this.SqlConnection);
            }

            protected SqlConnection GetTransactionConnection()
            {
                return CriarConexao();
            }

            protected SqlTransaction GetTransaction(SqlConnection sqlConnection)
            {
                sqlConnection.Open();
                return sqlConnection.BeginTransaction();
            }

            public void Commit()
            {
                try
                {
                    this.SqlTransaction.Commit();
                }
                finally
                {
                    this.SqlConnection.Close();
                }
            }

            public void Roolback()
            {
                try
                {
                    this.SqlTransaction.Rollback();
                }
                finally
                {
                    this.SqlConnection.Close();
                }
            }

            public dynamic ExecutaAlteracaoTrasaction(string nomeStoredProcedureOuTextoSql, List<ParametroSql> parametroSqls)
            {
                try
                {
                    object i;
                    SqlCommand sqlCommand = SqlConnection.CreateCommand();
                    sqlCommand.Connection = SqlConnection;
                    sqlCommand.Transaction = SqlTransaction;
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
                    i = sqlCommand.ExecuteNonQuery();
                    return i;
                }
                catch
                {
                    try
                    {
                        this.SqlTransaction.Rollback();
                    }
                    finally
                    {
                        this.SqlConnection.Close();
                    }
                    return null;
                }
            }

            public dynamic ExecutaAlteracaoTrasactionID(string nomeStoredProcedureOuTextoSql, List<ParametroSql> parametroSqls)
            {
                try
                {
                    object i;
                    SqlCommand sqlCommand = SqlConnection.CreateCommand();
                    sqlCommand.Connection = SqlConnection;
                    sqlCommand.Transaction = SqlTransaction;
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
                    i = sqlCommand.ExecuteScalar();
                    return i;
                }
                catch
                {
                    try
                    {
                        this.SqlTransaction.Rollback();
                    }
                    finally
                    {
                        this.SqlConnection.Close();
                    }
                    return null;
                }
            }
        }
    }
}
