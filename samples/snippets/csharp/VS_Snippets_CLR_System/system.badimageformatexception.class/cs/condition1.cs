using System;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      // Windows DLL (non-.NET assembly)
      string filePath = Environment.ExpandEnvironmentVariables("%windir%");
      if (! filePath.Trim().EndsWith(@"\"))
         filePath += @"\";
      filePath += @"System32\Kernel32.dll";
      
      try {
         Assembly assem = Assembly.LoadFile(filePath);
      }
      catch (BadImageFormatException e) {
         Console.WriteLine("Unable to load {0}.", filePath);
         Console.WriteLine(e.Message.Substring(0, 
                           e.Message.IndexOf(".") + 1));   
      }
      // The example displays an error message like the following:
      //       Unable to load C:\WINDOWS\System32\Kernel32.dll.
      //       The module was expected to contain an assembly manifest.
      // </Snippet1>
   }
}
