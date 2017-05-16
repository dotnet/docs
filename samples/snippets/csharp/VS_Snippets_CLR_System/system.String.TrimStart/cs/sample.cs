using System;
using System.Collections.Generic;

public class TrimExample
{
   // <Snippet2>
   public static void Main()
   {
      string[] lines= {"using System;",
                       "", 
                       "public class HelloWorld",
                       "{", 
                       "   public static void Main()",
                       "   {", 
                       "      // This code displays a simple greeting", 
                       "      // to the console.", 
                       "      Console.WriteLine(\"Hello, World.\");", 
                       "   }", 
                       "}"};
      Console.WriteLine("Before call to StripComments:");
      foreach (string line in lines)
         Console.WriteLine("   {0}", line);                         
      
      string[] strippedLines = StripComments(lines); 
      Console.WriteLine("After call to StripComments:");
      foreach (string line in strippedLines)
         Console.WriteLine("   {0}", line);                         
   }
   // This code produces the following output to the console:
   //    Before call to StripComments:
   //       using System;
   //   
   //       public class HelloWorld
   //       {
   //           public static void Main()
   //           {
   //               // This code displays a simple greeting
   //               // to the console.
   //               Console.WriteLine("Hello, World.");
   //           }
   //       }  
   //    After call to StripComments:
   //       This code displays a simple greeting
   //       to the console.
   // </Snippet2>
   
   // <Snippet1>
   public static string[] StripComments(string[] lines)
   { 
      List<string> lineList = new List<string>();
      foreach (string line in lines)
      {
         if (line.TrimStart(' ').StartsWith("//"))
            lineList.Add(line.TrimStart(' ', '/'));
      }
      return lineList.ToArray();
   }   
   // </Snippet1>
}

