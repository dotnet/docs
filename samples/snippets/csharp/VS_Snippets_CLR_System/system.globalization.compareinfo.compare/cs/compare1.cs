using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CompareInfo ci = CultureInfo.CurrentCulture.CompareInfo;
      string s1 = "ani\u00ADmal";
      string s2 = "animal";
      
      Console.WriteLine("Comparison of '{0}' and '{1}': {2}", 
                        s1, s2, ci.Compare(s1, s2));
   }
}
