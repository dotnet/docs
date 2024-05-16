using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

public class Example2
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Current directory is '{Environment.CurrentDirectory}'");
        Console.WriteLine("Setting current directory to 'C:\\'");

        Directory.SetCurrentDirectory(@"C:\");
        string path = Path.GetFullPath(@"D:\FY2018");
        Console.WriteLine($"'D:\\FY2018' resolves to {path}");
        path = Path.GetFullPath(@"D:FY2018");
        Console.WriteLine($"'D:FY2018' resolves to {path}");

        Console.WriteLine("Setting current directory to 'D:\\Docs'");
        Directory.SetCurrentDirectory(@"D:\Docs");

        path = Path.GetFullPath(@"D:\FY2018");
        Console.WriteLine($"'D:\\FY2018' resolves to {path}");
        path = Path.GetFullPath(@"D:FY2018");

        // This will be "D:\Docs\FY2018" as it happens to match the drive of the current directory
        Console.WriteLine($"'D:FY2018' resolves to {path}");

        Console.WriteLine("Setting current directory to 'C:\\'");
        Directory.SetCurrentDirectory(@"C:\");

        path = Path.GetFullPath(@"D:\FY2018");
        Console.WriteLine($"'D:\\FY2018' resolves to {path}");

        // This will be either "D:\FY2018" or "D:\FY2018\FY2018" in the subprocess. In the sub process,
        // the command prompt set the current directory before launch of our application, which
        // sets a hidden environment variable that is considered.
        path = Path.GetFullPath(@"D:FY2018");
        Console.WriteLine($"'D:FY2018' resolves to {path}");

        if (args.Length < 1)
        {
            Console.WriteLine(@"Launching again, after setting current directory to D:\FY2018");
            Uri currentExe = new(Assembly.GetExecutingAssembly().Location, UriKind.Absolute);
            string commandLine = $"/C cd D:\\FY2018 & \"{currentExe.LocalPath}\" stop";
            ProcessStartInfo psi = new("cmd", commandLine); ;
            Process.Start(psi).WaitForExit();

            Console.WriteLine("Sub process returned:");
            path = Path.GetFullPath(@"D:\FY2018");
            Console.WriteLine($"'D:\\FY2018' resolves to {path}");
            path = Path.GetFullPath(@"D:FY2018");
            Console.WriteLine($"'D:FY2018' resolves to {path}");
        }
        Console.WriteLine("Press any key to continue... ");
        Console.ReadKey();
    }
}
// The example displays the following output:
//      Current directory is 'C:\Programs\file-paths'
//      Setting current directory to 'C:\'
//      'D:\FY2018' resolves to D:\FY2018
//      'D:FY2018' resolves to d:\FY2018
//      Setting current directory to 'D:\Docs'
//      'D:\FY2018' resolves to D:\FY2018
//      'D:FY2018' resolves to D:\Docs\FY2018
//      Setting current directory to 'C:\'
//      'D:\FY2018' resolves to D:\FY2018
//      'D:FY2018' resolves to d:\FY2018
//      Launching again, after setting current directory to D:\FY2018
//      Sub process returned:
//      'D:\FY2018' resolves to D:\FY2018
//      'D:FY2018' resolves to d:\FY2018
// The subprocess displays the following output:
//      Current directory is 'C:\'
//      Setting current directory to 'C:\'
//      'D:\FY2018' resolves to D:\FY2018
//      'D:FY2018' resolves to D:\FY2018\FY2018
//      Setting current directory to 'D:\Docs'
//      'D:\FY2018' resolves to D:\FY2018
//      'D:FY2018' resolves to D:\Docs\FY2018
//      Setting current directory to 'C:\'
//      'D:\FY2018' resolves to D:\FY2018
//      'D:FY2018' resolves to D:\FY2018\FY2018
