using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Extensions
{
    internal static class convercaoEntensions
    {
        public static int? ToNullableInt(this string s)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            return null;
        }

        public static Boolean ToBoolean(this string str)
        {
            String cleanValue = (str ?? "").Trim();
            if (String.Equals(cleanValue, "False", StringComparison.OrdinalIgnoreCase))
                return false;
            return
                (String.Equals(cleanValue, "True", StringComparison.OrdinalIgnoreCase)) ||
                (cleanValue != "0");
        }

        public static int ToInt(this string s)
        {
            try
            {
                int i;
                if (int.TryParse(s, out i)) return i;
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static decimal ToDecimal(this string s)
        {
            try
            {
                decimal i;
                if (decimal.TryParse(s, out i)) return i;
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static decimal? ToNullableDecimal(this string s)
        {
            try
            {
                decimal i;
                if (decimal.TryParse(s, out i)) return i;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DateTime ToShortDate(this DateTime dateTime)
        {
            try
            {
                string stringDate = dateTime.ToShortDateString();
                return Convert.ToDateTime(stringDate);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
