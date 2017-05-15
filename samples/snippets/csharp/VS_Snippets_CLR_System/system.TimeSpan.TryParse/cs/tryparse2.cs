// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string[] values = { "6", "6:12", "6:12:14", "6:12:14:45", 
                          "6.12:14:45", "6:12:14:45.3448", 
                          "6:12:14:45,3448", "6:34:14:45" };
      CultureInfo[] cultures = { new CultureInfo("en-US"), 
                                 new CultureInfo("ru-RU"),
                                 CultureInfo.InvariantCulture };
      
      string header = String.Format("{0,-17}", "String");
      foreach (CultureInfo culture in cultures)
         header += culture.Equals(CultureInfo.InvariantCulture) ? 
                      String.Format("{0,20}", "Invariant") :
                      String.Format("{0,20}", culture.Name);

      Console.WriteLine(header);
      Console.WriteLine();
      
      foreach (string value in values)
      {
         Console.Write("{0,-17}", value);
         foreach (CultureInfo culture in cultures)
         {
            TimeSpan interval = new TimeSpan();
            if (TimeSpan.TryParse(value, culture, out interval))
               Console.Write("{0,20}", interval.ToString("c"));
            else
               Console.Write("{0,20}", "Unable to Parse");
         }
         Console.WriteLine();                                
      }
   }
}
// The example displays the following output:
//    String                          en-US               ru-RU           Invariant
//    
//    6                          6.00:00:00          6.00:00:00          6.00:00:00
//    6:12                         06:12:00            06:12:00            06:12:00
//    6:12:14                      06:12:14            06:12:14            06:12:14
//    6:12:14:45                 6.12:14:45          6.12:14:45          6.12:14:45
//    6.12:14:45                 6.12:14:45          6.12:14:45          6.12:14:45
//    6:12:14:45.3448    6.12:14:45.3448000     Unable to Parse  6.12:14:45.3448000
//    6:12:14:45,3448       Unable to Parse  6.12:14:45.3448000     Unable to Parse
//    6:34:14:45            Unable to Parse     Unable to Parse     Unable to Parse
// </Snippet2>