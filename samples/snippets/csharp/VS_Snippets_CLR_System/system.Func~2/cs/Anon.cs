using System;

public class Anonymous
{
   public static void Main()
   {
      // <Snippet3>
      Func<string, string> convert = delegate(string s)
         { return s.ToUpper();}; 
         
      string name = "Dakota";
      Console.WriteLine(convert(name));   

     // This code example produces the following output:
     //
     //    DAKOTA      
     // </Snippet3>
   }
}
