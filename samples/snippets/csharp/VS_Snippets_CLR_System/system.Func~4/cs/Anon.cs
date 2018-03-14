// <Snippet3>
using System;
using System.Globalization;

public class Anonymous
{
   public static void Main()
   {
      string numericString = "-1,234";
      Func<string, NumberStyles, IFormatProvider, int> parser = 
           delegate(string s, NumberStyles sty, IFormatProvider p) 
           { return int.Parse(s, sty, p); };
      Console.WriteLine(parser(numericString, 
                        NumberStyles.Integer | NumberStyles.AllowThousands, 
                        CultureInfo.InvariantCulture));
   }
}
// </Snippet3>
