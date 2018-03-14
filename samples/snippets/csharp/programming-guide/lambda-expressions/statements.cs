using System;

public class Example
{
   // <Snippet1>
   delegate void TestDelegate(string s);
   // </Snippet1>
   
   public static void Main()
   {
      // <Snippet2>
      TestDelegate del = n => { string s = n + " World"; 
                                Console.WriteLine(s); };
      // </Snippet2>
      del("Hi, there, ");
   }
}
