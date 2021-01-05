using System.Data;

namespace WebService.Tools
{
    public class ParametroSql
    {
        public string ParameterName;
        public object Value;
        public SqlDbType Type;

        public ParametroSql(string parameterName, object value, SqlDbType type)
        {
            this.ParameterName = parameterName;
            this.Value = value;
            this.Type = type;
        }
    }
}
