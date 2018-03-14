// <Snippet2>
using System;
using System.Globalization;

public class GenericFunc
{
   public static void Main()
   {
      string numericString = "-1,234";
      Func<string, NumberStyles, IFormatProvider, int> parser = int.Parse;
      Console.WriteLine(parser(numericString, 
                        NumberStyles.Integer | NumberStyles.AllowThousands, 
                        CultureInfo.InvariantCulture));
   }
}
// </Snippet2>
