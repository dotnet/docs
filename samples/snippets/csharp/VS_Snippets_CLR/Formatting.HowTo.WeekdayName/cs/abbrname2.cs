// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      DateTime dateValue = new DateTime(2008, 6, 11);
      Console.WriteLine(dateValue.ToString("ddd", 
                        new CultureInfo("fr-FR")));    
   }
}
// The example displays the following output:
//       mer.  
// </Snippet2>
