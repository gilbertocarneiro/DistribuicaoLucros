using System.Data;

namespace WebService.Tools
{
    public class ParametroSql
    {
        public string ParameterName;
        public object Value;
        public SqlDbType Type;

        public ParametroSql(string ParameterName, object Value, SqlDbType Type)
        {
            this.ParameterName = ParameterName;
            this.Value = Value;
            this.Type = Type;
        }
    }
}
