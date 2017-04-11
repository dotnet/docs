// <Snippet5>
using System;

public class Example
{
   public static void Main()
   {
      DateTime date1 = new DateTime(2009, 7, 1);
      TimeSpan hiTime = new TimeSpan(14, 17, 32);
      decimal hiTemp = 62.1m; 
      TimeSpan loTime = new TimeSpan(3, 16, 10);
      decimal loTemp = 54.8m; 

      string result1 = String.Format("Temperature on {0:d}:\n{1,11}: {2} degrees (hi)\n{3,11}: {4} degrees (lo)", 
                                     date1, hiTime, hiTemp, loTime, loTemp);
      Console.WriteLine(result1);
      Console.WriteLine();
           
      string result2 = String.Format("Temperature on {0:d}:\n{1,11}: {2} degrees (hi)\n{3,11}: {4} degrees (lo)", 
                                     new object[] { date1, hiTime, hiTemp, loTime, loTemp });
      Console.WriteLine(result2);
   }
}
// The example displays the following output:
//       Temperature on 7/1/2009:
//          14:17:32: 62.1 degrees (hi)
//          03:16:10: 54.8 degrees (lo)
//       Temperature on 7/1/2009:
//          14:17:32: 62.1 degrees (hi)
//          03:16:10: 54.8 degrees (lo)
// </Snippet5>
