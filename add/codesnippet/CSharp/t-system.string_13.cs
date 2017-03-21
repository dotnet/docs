   public string ToString(string format, IFormatProvider provider) 
   {
      if (String.IsNullOrEmpty(format)) format = "G";  
      if (provider == null) provider = CultureInfo.CurrentCulture;
      
      switch (format.ToUpperInvariant())
      {
         // Return degrees in Celsius.    
         case "G":
         case "C":
            return temp.ToString("F2", provider) + "°C";
         // Return degrees in Fahrenheit.
         case "F": 
            return (temp * 9 / 5 + 32).ToString("F2", provider) + "°F";
         // Return degrees in Kelvin.
         case "K":   
            return (temp + 273.15).ToString();
         default:
            throw new FormatException(
                  String.Format("The {0} format string is not supported.", 
                                format));
      }                                   
   }