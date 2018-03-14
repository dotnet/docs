using System;

public class Class1
{
   public static void Main()
   {
      // <Snippet2>
      int value = 6324;
      string output = string.Format("{0}{1:D}{2}", 
                                   "{", value, "}");
      Console.WriteLine(output);
      // The example displays the following output:
      //       {6324}                            
      // </Snippet2>
   }
}
