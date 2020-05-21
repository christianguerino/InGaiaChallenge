using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRest.Utils
{
    public static class Conversion
    {
        public static double ToDouble(object value)
        {
            double ret = 0.0;
            try
            {
                ret = Convert.ToDouble(value);
            }
            catch
            {
                //nada aqui
            }
            return ret;
        }

        public static string ToString(object value)
        {
            string ret = string.Empty;
            try
            {
                ret = value.ToString();
            }
            catch
            {
                //nada aqui
            }
            return ret;
        }

        public static DateTime ToDate(object value)
        {
            DateTime ret = DateTime.MinValue;
            try
            {
                ret = Convert.ToDateTime(value);
            }
            catch
            {
                //nada aqui
            }
            return ret;
        }
    }
}