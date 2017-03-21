using System;

public class Temperature
{ 
   private decimal temp;
   
   public Temperature(decimal temperature)
   {
      this.temp = temperature;
   }
   
   public override string ToString() 
   {
      return ToString("C");
   }
   
   public string ToString(string format)
   {
      if (String.IsNullOrEmpty(format))
         format = "G";
      
      switch (format.ToUpper())
      {
         case "G":
         case "C":
            return temp.ToString("N") + "  °C";
         case "F":
            return (9 * temp / 5 + 32).ToString("N") + "  °F";
         case "K": 
            return (temp + 273.15m).ToString("N") + "  °K";
         default:
            throw new FormatException(String.Format("The '{0}' format specifier is not supported", 
                                                    format));
      }                                                         
   }         
   
   public void Display(params string []formats)
   {
      if (formats.Length == 0)
      {
         Console.WriteLine(this.ToString("G"));
      }
      else  
      { 
         foreach (string format in formats)
         {
            try {
               Console.WriteLine(this.ToString(format));
            }
            // If there is an exception, do nothing.
            catch { }
         }
      }
   }
}