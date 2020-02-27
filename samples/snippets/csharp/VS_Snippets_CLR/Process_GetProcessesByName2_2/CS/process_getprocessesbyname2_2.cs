// System.Diagnostics.Process.GetProcessesByName(String, String)
// System.Diagnostics.Process.MachineName

/* 
   The following program demonstrates the method 'GetProcessesByName(String, String)'
   and property 'MachineName' of class 'Process'.
   It reads the remote computer name from commandline and gets all the notepad 
   processes by name on remote computer and displays its properties to console.
*/
// <Snippet1>
// <Snippet2>
using System;
using System.Diagnostics;

class GetProcessesByNameClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Create notepad processes on remote computer");
        Console.Write("Enter remote computer name : ");
        string remoteMachineName = Console.ReadLine();

        if (remoteMachineName == null)
        {
            // Prepend a new line to prevent it from being on the same line as the prompt.
            Console.WriteLine(Environment.NewLine + "You have to enter a remote computer name.");
            return;
        }

        try
        {
            // Get all notepad processess into Process array.
            Process[] myProcesses = Process.GetProcessesByName("notepad", remoteMachineName);

            if (myProcesses.Length == 0)
                Console.WriteLine("Could not find notepad processes on remote computer.");

            foreach (Process myProcess in myProcesses)
            {
                Console.WriteLine(
                    $"Process Name : {myProcess.ProcessName}\n" +
                    $"Process ID   : {myProcess.Id}\n" +
                    $"MachineName  : {myProcess.MachineName}");
            }
        }
        catch (ArgumentException)
        {
            Console.WriteLine($"The value \'{remoteMachineName}\' is an invalid remote computer name.");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Unable to get process information on the remote computer.");
        }
        catch (PlatformNotSupportedException)
        {
            Console.WriteLine(
                "Finding notepad processes on remote computers " +
                "is not supported on this operating system.");
        }
    }
}
// </Snippet1> 
// </Snippet2> 
