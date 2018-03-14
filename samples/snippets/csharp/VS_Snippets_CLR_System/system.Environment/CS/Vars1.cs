//<Snippet4>
using System;
using System.IO;

public class Example
{
   public static void Main()
   {
      // Change the directory to %WINDIR%
      Environment.CurrentDirectory = Environment.GetEnvironmentVariable("windir");
      DirectoryInfo info = new DirectoryInfo(".");

      Console.WriteLine("Directory Info:   " + info.FullName);
   }
}
// The example displays output like the following:
//        Directory Info:   C:\windows
//</Snippet4>
