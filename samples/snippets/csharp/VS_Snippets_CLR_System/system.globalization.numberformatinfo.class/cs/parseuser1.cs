// <Snippet5>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo stdCulture = CultureInfo.GetCultureInfo("en-US");
      CultureInfo custCulture = CultureInfo.CreateSpecificCulture("en-US"); 
            
      String value = "310,16";
      try {
         Console.WriteLine("{0} culture reflects user overrides: {1}", 
                           stdCulture.Name, stdCulture.UseUserOverride);
         Decimal amount = Decimal.Parse(value, stdCulture);
         Console.WriteLine("'{0}' --> {1}", value, amount.ToString(CultureInfo.InvariantCulture));                                                                                        
      }
      catch (FormatException) {
         Console.WriteLine("Unable to parse '{0}'", value);
      }    
      Console.WriteLine();
                                            
      try {
         Console.WriteLine("{0} culture reflects user overrides: {1}", 
                           custCulture.Name, custCulture.UseUserOverride);
         Decimal amount = Decimal.Parse(value, custCulture);
         Console.WriteLine("'{0}' --> {1}", value, amount.ToString(CultureInfo.InvariantCulture));                                                                                        
      }
      catch (FormatException) {
         Console.WriteLine("Unable to parse '{0}'", value);
      }   
   }
}
// The example displays the following output:
//       en-US culture reflects user overrides: False
//       '310,16' --> 31016
//       
//       en-US culture reflects user overrides: True
//       '310,16' --> 310.16
// </Snippet5>
