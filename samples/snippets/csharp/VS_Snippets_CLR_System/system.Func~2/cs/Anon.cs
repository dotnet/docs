// <Snippet3>
using System;

public class Anonymous
{
   public static void Main()
   {
      Func<string, string> convert = delegate(string s)
         { return s.ToUpper();}; 
         
      string name = "Dakota";
      Console.WriteLine(convert(name));   
   }
}
// </Snippet3>
