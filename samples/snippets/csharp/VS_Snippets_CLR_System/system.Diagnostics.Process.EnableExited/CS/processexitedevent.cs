//<snippet1>
using System;
using System.Diagnostics;
using System.Threading.Tasks;

class PrintProcessClass
{
    private Process myProcess;
    private TaskCompletionSource<bool> eventHandled;

    // Print a file with any known extension.
    public async Task PrintDoc(string fileName)
    {
        eventHandled = new TaskCompletionSource<bool>();

        using (myProcess = new Process())
        {
            try
            {
                // Start a process to print a file and raise an event when done.
                myProcess.StartInfo.FileName = fileName;
                myProcess.StartInfo.Verb = "Print";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.EnableRaisingEvents = true;
                myProcess.Exited += new EventHandler(myProcess_Exited);
                myProcess.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred trying to print \"{fileName}\":\n{ex.Message}");
                return;
            }

            // Wait for Exited event, but not more than 30 seconds.
            await Task.WhenAny(eventHandled.Task,Task.Delay(30000));            
        }
    }

    // Handle Exited event and display process information.
    private void myProcess_Exited(object sender, System.EventArgs e)
    {        
        Console.WriteLine(
            $"Exit time    : {myProcess.ExitTime}\n" +
            $"Exit code    : {myProcess.ExitCode}\n" +
            $"Elapsed time : {Math.Round((myProcess.ExitTime - myProcess.StartTime).TotalMilliseconds)}");
        eventHandled.TrySetResult(true);
    }

    public static async Task Main(string[] args)
    {
        // Verify that an argument has been entered.
        if (args.Length <= 0)
        {
            Console.WriteLine("Enter a file name.");
            return;
        }

        // Create the process and print the document.
        PrintProcessClass myPrintProcess = new PrintProcessClass();
        await myPrintProcess.PrintDoc(args[0]);
    }
}
//</snippet1>
