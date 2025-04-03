// <Snippet4>
using System;
using System.IO;
using System.Reflection;

public class Example0
{
   public static void Main()
   {
      if (Environment.GetCommandLineArgs().Length == 1) { 
         Console.WriteLine("No filename.");
         return;
      }
      
      string filename = Environment.GetCommandLineArgs()[1].Trim();
      // Check whether the file exists.
      if (! File.Exists(filename)) {
         Console.WriteLine($"{filename} does not exist.");
         return;
      }   
      
      // Try to load the assembly.
      Assembly assem = Assembly.LoadFrom(filename);
      Console.WriteLine($"File: {filename}");
         
      // Enumerate the resource files.
      string[] resNames = assem.GetManifestResourceNames();
      if (resNames.Length == 0)
         Console.WriteLine("   No resources found.");

      foreach (var resName in resNames)
         Console.WriteLine($"   Resource: {resName.Replace(".resources", "")}");

      Console.WriteLine();
   }
}
// </Snippet4>
