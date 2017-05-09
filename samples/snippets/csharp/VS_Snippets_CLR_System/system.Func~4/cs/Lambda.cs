// <Snippet4>
using System;
using System.Globalization;

public class LambdaExpression
{
   public static void Main()
   {
      string numericString = "-1,234";
      Func<string, NumberStyles, IFormatProvider, int> parser = (s, sty, p)
                   => int.Parse(s, sty, p);
      Console.WriteLine(parser(numericString, 
                        NumberStyles.Integer | NumberStyles.AllowThousands, 
                        CultureInfo.InvariantCulture));
   }
}
// </Snippet4>
