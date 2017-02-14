using System;

public class LambdaExpressions
{
   public static void Main()
   {
      // <Snippet1>
      Action line = () => Console.WriteLine();
      // </Snippet1>
      Console.WriteLine("Hello");
      line();
      Console.WriteLine("World!");

      // <Snippet2>
      Func<int,int,bool> testEquality = (x, y) => x == y;  // test for equality
      // </Snippet2>

      int n1 = 20;
      int n2 = 25;
      Console.WriteLine(testEquality(n1, n2));

      // <Snippet3>
      Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;
      // </Snippet3>
      Console.WriteLine(isTooLong(10, "This is a string"));
   }
}
