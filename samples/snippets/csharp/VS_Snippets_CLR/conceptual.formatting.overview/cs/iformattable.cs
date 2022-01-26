// <Snippet12>
using System;
using System.Globalization;

namespace HotAndCold
{

    public class Temperature : IFormattable
    {
        private decimal m_Temp;

        public Temperature(decimal temperature)
        {
            this.m_Temp = temperature;
        }

        public decimal Celsius
        {
            get { return this.m_Temp; }
        }

        public decimal Kelvin
        {
            get { return this.m_Temp + 273.15m; }
        }

        public decimal Fahrenheit
        {
            get { return Math.Round((decimal)this.m_Temp * 9 / 5 + 32, 2); }
        }

        public override string ToString()
        {
            return this.ToString("G", null);
        }

        public string ToString(string format)
        {
            return this.ToString(format, null);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            // Handle null or empty arguments.
            if (String.IsNullOrEmpty(format))
                format = "G";
            // Remove any white space and covert to uppercase.
            format = format.Trim().ToUpperInvariant();

            if (provider == null)
                provider = NumberFormatInfo.CurrentInfo;

            switch (format)
            {
                // Convert temperature to Fahrenheit and return string.
                case "F":
                    return this.Fahrenheit.ToString("N2", provider) + "°F";
                // Convert temperature to Kelvin and return string.
                case "K":
                    return this.Kelvin.ToString("N2", provider) + "K";
                // Return temperature in Celsius.
                case "C":
                case "G":
                    return this.Celsius.ToString("N2", provider) + "°C";
                default:
                    throw new FormatException(String.Format("The '{0}' format string is not supported.", format));
            }
        }
    }
    // </Snippet12>

    // <Snippet13>
    public class Example11
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Temperature temp = new Temperature(22m);
            Console.WriteLine(Convert.ToString(temp, new CultureInfo("ja-JP")));
            Console.WriteLine("Temperature: {0:K}", temp);
            Console.WriteLine("Temperature: {0:F}", temp);
            Console.WriteLine(String.Format(new CultureInfo("fr-FR"), "Temperature: {0:F}", temp));
        }
    }
    // The example displays the following output:
    //       22.00°C
    //       Temperature: 295.15K
    //       Temperature: 71.60°F
    //       Temperature: 71,60°F
    // </Snippet13>
}
