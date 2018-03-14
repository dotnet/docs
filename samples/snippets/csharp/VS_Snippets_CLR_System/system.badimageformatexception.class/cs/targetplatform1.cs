// <Snippet4>
using System;
using System.IO;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      String[] args = Environment.GetCommandLineArgs();
      if (args.Length == 1) {
         Console.WriteLine("\nSyntax:   PlatformInfo <filename>\n");
         return;
      }
      Console.WriteLine();

      // Loop through files and display information about their platform.
      for (int ctr = 1; ctr < args.Length; ctr++) {
         string fn = args[ctr];
         if (! File.Exists(fn)) {
            Console.WriteLine("File: {0}", fn);
            Console.WriteLine("The file does not exist.\n");
         }
         else {
            try {
               AssemblyName an = AssemblyName.GetAssemblyName(fn);
               Console.WriteLine("Assembly: {0}", an.Name);
               if (an.ProcessorArchitecture == ProcessorArchitecture.MSIL)
                  Console.WriteLine("Architecture: AnyCPU");
               else
                  Console.WriteLine("Architecture: {0}", an.ProcessorArchitecture);

               Console.WriteLine();
            }
            catch (BadImageFormatException) {
               Console.WriteLine("File: {0}", fn);
               Console.WriteLine("Not a valid assembly.\n");
            }
         }
      }
   }
}
// </Snippet4>
