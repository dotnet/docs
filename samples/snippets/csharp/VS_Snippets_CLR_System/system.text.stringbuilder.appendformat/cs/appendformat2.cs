// <Snippet3>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

public class Example
{
   public static void Main()
   {
      CultureInfo culture = new CultureInfo("en-US");
      StringBuilder sb = new StringBuilder();
      Dictionary<DateTime, Double> temperatureInfo = new Dictionary<DateTime, Double>(); 
      temperatureInfo.Add(new DateTime(2010, 6, 1, 14, 0, 0), 87.46);
      temperatureInfo.Add(new DateTime(2010, 12, 1, 10, 0, 0), 36.81);
      

      sb.AppendLine("Temperature Information:\n");
      foreach (var item in temperatureInfo)
      {
         sb.AppendFormat(culture,
                         "Temperature at {0,8:t} on {0,9:d}: {1,5:N1}°F\n",
                         item.Key, item.Value);
      }
      Console.WriteLine(sb.ToString());
   }
}
// The example displays the following output:
//       Temperature Information:
//       
//       Temperature at  2:00 PM on  6/1/2010:  87.5°F
//       Temperature at 10:00 AM on 12/1/2010:  36.8°F
// </Snippet3>
