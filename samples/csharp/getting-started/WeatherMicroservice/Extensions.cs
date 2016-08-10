using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherMicroservice
{
    public static class Extensions
    {
        public static double? TryParse(this string input)
        {
            double result;
            if (double.TryParse(input, out result))
                return result;
            else
                return default(double?);
        }
    }
}
