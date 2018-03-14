// <Snippet1>
using System;
using System.IO;
using System.Reflection;

public class RedirectStdErr
{
   public static void Main()
   {
      // Define file to receive error stream.
      DateTime appStart = DateTime.Now;
      string fn = @"c:\temp\errlog" + appStart.ToString("yyyyMMddHHmm") + ".log";
      TextWriter errStream = new StreamWriter(fn);
      string appName = typeof(RedirectStdErr).Assembly.Location;
      appName = appName.Substring(appName.LastIndexOf('\\') + 1);
      // Redirect standard error stream to file.
      Console.SetError(errStream);
      // Write file header.
      Console.Error.WriteLine("Error Log for Application {0}", appName);
      Console.Error.WriteLine();
      Console.Error.WriteLine("Application started at {0}.", appStart);
      Console.Error.WriteLine();
      //
      // Application code along with error output 
      //
      // Close redirected error stream.
      Console.Error.Close();
   }
}
// </Snippet1>
