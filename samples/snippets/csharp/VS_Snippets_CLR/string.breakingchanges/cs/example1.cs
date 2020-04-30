// <Snippet1>
using System;

enum StringComparisonResult
{
    precedes = -1,
    equals = 0,
    follows = 1,
};

public class Example
{
   public static void Main()
   {
      string str1 = new string( new char[] {'\u0219', '\u021B', 'a' });
      string str2 = "a";

      Console.WriteLine("{0} {1} {2} in the sort order.",
                        str1,
                        (StringComparisonResult) String.Compare(str1, str2, StringComparison.CurrentCulture),
                        str2);
   }
}
// </Snippet1>
