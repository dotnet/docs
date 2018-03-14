// <Snippet1>
using System;
using System.Globalization;

delegate T ParseNumber<T>(string input, NumberStyles styles, 
                         IFormatProvider provider);
                         
public class DelegateExample
{
   public static void Main()
   {
      string numericString = "-1,234";
      ParseNumber<int> parser = int.Parse;
      Console.WriteLine(parser(numericString, 
                        NumberStyles.Integer | NumberStyles.AllowThousands, 
                        CultureInfo.InvariantCulture));
   }
}
// </Snippet1>
