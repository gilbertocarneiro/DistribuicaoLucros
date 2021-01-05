using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Extensions
{
    internal static class ConvercaoEntensions
    {
        public static int ToInt(this string s)
        {

            if (int.TryParse(s, out int i)) return i;
            return 0;
        }

        public static decimal ToDecimal(this string s)
        {
            if (decimal.TryParse(s, out decimal i)) return i;
            return 0;
        }

        public static DateTime ToShortDate(this DateTime dateTime)
        {
            string stringDate = dateTime.ToShortDateString();
            return Convert.ToDateTime(stringDate);
        }

        public static string FormatarValorDecimal(this decimal valor)
        {
            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "R$ {0:#,###.00}", valor);
        }

        public static decimal ToDecimal(this decimal value, int casasDecimais)
        {
            if (casasDecimais < 0)
                throw new ArgumentException("Casas decimais devem ser maior que 0.");

            var modifier = Convert.ToDecimal(0.5 / Math.Pow(10, casasDecimais));
            return Math.Round(value >= 0 ? value - modifier : value + modifier, casasDecimais);
        }
    }
}
