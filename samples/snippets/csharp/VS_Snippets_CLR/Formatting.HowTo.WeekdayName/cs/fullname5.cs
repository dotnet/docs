// <Snippet5>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      DateTime dateValue = new DateTime(2008, 6, 11);
      Console.WriteLine(dateValue.ToString("dddd", 
                        new CultureInfo("es-ES")));    
   }
}
// The example displays the following output:
//       miércoles.
// </Snippet5>
