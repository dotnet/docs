//<snippet1>
using System;
using System.IO;
using System.Diagnostics;

class IORedirExample
{
    public static void Main()
    {
        string[] args = Environment.GetCommandLineArgs();
        if (args.Length > 1)
        {
            // This is the code for the spawned process
            Console.WriteLine("Hello from the redirected process!");
        }
        else
        {
            // This is the code for the base process
            Process myProcess = new Process();
            // Start a new instance of this program but specify the 'spawned' version.
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(args[0], "spawn");
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcess.StartInfo = myProcessStartInfo;
            myProcess.Start();
            StreamReader myStreamReader = myProcess.StandardOutput;
            // Read the standard output of the spawned process.
            string myString = myStreamReader.ReadLine();
            Console.WriteLine(myString);

            myProcess.WaitForExit();
            myProcess.Close();
        }
    }
}
//</snippet1>
//<snippet2>
using System;
using System.IO;
using System.Diagnostics;

class StandardOutputExample
{
    public static void Main()
    {        
        Process process = new Process();
        process.StartInfo.FileName = "ipconfig.exe";        
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;        
        process.Start();
        
        // Synchronously read the standard output of the spawned process. 
        StreamReader reader = process.StandardOutput;
        string output = reader.ReadToEnd();

        // Write the redirected output to this application's window.
        Console.WriteLine(output);

        process.WaitForExit();
        process.Close();

        Console.WriteLine("\n\nPress any key to exit.");
        Console.ReadLine();
    }
}
//</snippet2>
