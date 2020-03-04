//<Snippet1>
using System;
using System.Threading;
using System.Security.Permissions;
using System.Security.Principal;
using System.Diagnostics;

class ProcessDemo
{
    public static void Main()
    {
        Process notePad = Process.Start("notepad");
        Console.WriteLine("Started notepad process Id = " + notePad.Id);
        Console.WriteLine("All instances of notepad:");
        // Get Process objects for all running instances on notepad.
        Process[] localByName = Process.GetProcessesByName("notepad");
        int i = localByName.Length;
        while (i > 0)
        {
            // You can use the process Id to pass to other applications or to
            // reference that particular instance of the application.
            Console.WriteLine(localByName[i - 1].Id.ToString());
            i -= 1;
        }
        
        i = localByName.Length;
        while (i > 0)
        {
            Console.WriteLine("Enter a process Id to kill the process");
            string id = Console.ReadLine();
            if (string.IsNullOrEmpty(id))
                break;

            try
            {
                using (Process chosen = Process.GetProcessById(Int32.Parse(id)))
                {
                    if (chosen.ProcessName == "notepad")
                    {
                        chosen.Kill();
                        chosen.WaitForExit();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Incorrect entry.");
                continue;
            }
            
            i -= 1;
        }
    }
}
//</Snippet1>
