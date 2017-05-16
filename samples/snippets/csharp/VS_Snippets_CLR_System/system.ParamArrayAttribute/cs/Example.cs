// <Snippet1>
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
// </Snippet1>

// <Snippet2>
public class Class1
{
   public static void Main()
   {
      Temperature temp1 = new Temperature(100);
      string[] formats = { "C", "G", "F", "K" }; 

      // Call Display method with a string array.
      Console.WriteLine("Calling Display with a string array:");
      temp1.Display(formats);
      Console.WriteLine();
      
      // Call Display method with individual string arguments.
      Console.WriteLine("Calling Display with individual arguments:");
      temp1.Display("C", "F", "K", "G");
      Console.WriteLine();
      
      // Call parameterless Display method.
      Console.WriteLine("Calling Display with an implicit parameter array:");
      temp1.Display();
   }
}
// The example displays the following output:
//       Calling Display with a string array:
//       100.00  °C
//       100.00  °C
//       212.00  °F
//       373.15  °K
//       
//       Calling Display with individual arguments:
//       100.00  °C
//       212.00  °F
//       373.15  °K
//       100.00  °C
//       
//       Calling Display with an implicit parameter array:
//       100.00  °C
// </Snippet2>
