// <Snippet10>
using System;
using System.IO;
using System.Threading;

public class Example5
{
   public static void Main()
   {
      // Initialize flag variables.
      bool isRedirected = false;
      bool isBoth = false;
      String fileName = "";
      StreamWriter sw = null;

      // Get any command line arguments.
      String[] args = Environment.GetCommandLineArgs();
      // Handle any arguments.
      if (args.Length > 1) {
         for (int ctr = 1; ctr < args.Length; ctr++) {
            String arg = args[ctr];
            if (arg.StartsWith("/") || arg.StartsWith("-")) {
               switch (arg.Substring(1).ToLower())
               {
                  case "f":
                     isRedirected = true;
                     if (args.Length < ctr + 2) {
                        ShowSyntax("The /f switch must be followed by a filename.");
                        return;
                     }
                     fileName = args[ctr + 1];
                     ctr++;
                     break;
                  case "b":
                     isBoth = true;
                     break;
                  default:
                     ShowSyntax(String.Format("The {0} switch is not supported",
                                              args[ctr]));
                     return;
               }
            }
         }
      }

      // If isBoth is True, isRedirected must be True.
      if (isBoth &&  ! isRedirected) {
         ShowSyntax("The /f switch must be used if /b is used.");
         return;
      }

      // Handle output.
      if (isRedirected) {
         sw = new StreamWriter(fileName);
         if (!isBoth)
            Console.SetOut(sw);
      }
      String msg = String.Format("Application began at {0}", DateTime.Now);
      Console.WriteLine(msg);
      if (isBoth) sw.WriteLine(msg);
      Thread.Sleep(5000);
      msg = String.Format("Application ended normally at {0}", DateTime.Now);
      Console.WriteLine(msg);
      if (isBoth) sw.WriteLine(msg);
      if (isRedirected) sw.Close();
   }

   private static void ShowSyntax(String errMsg)
   {
      Console.WriteLine(errMsg);
      Console.WriteLine("\nSyntax: Example [[/f <filename> [/b]]\n");
   }
}
// </Snippet10>

public class Evaluation
{
   public void SomeMethod()
   {
      bool booleanValue = false;

      // <Snippet11>
      if (booleanValue == true) {
      // </Snippet11>
      }

      // <Snippet12>
      if (booleanValue) {
      // </Snippet12>
      }
   }
}
