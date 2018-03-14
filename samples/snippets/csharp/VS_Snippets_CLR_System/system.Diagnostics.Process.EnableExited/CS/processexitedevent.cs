//<snippet1>
using System;
using System.Diagnostics;
using System.Threading;

class PrintProcessClass
{

    private Process myProcess = new Process();
    private int elapsedTime;
    private bool eventHandled;

    // Print a file with any known extension.
    public void PrintDoc(string fileName)
    {

        elapsedTime = 0;
        eventHandled = false;

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
            Console.WriteLine("An error occurred trying to print \"{0}\":" + "\n" + ex.Message, fileName);
            return;
        }

        // Wait for Exited event, but not more than 30 seconds.
        const int SLEEP_AMOUNT = 100;
        while (!eventHandled)
        {
            elapsedTime += SLEEP_AMOUNT;
            if (elapsedTime > 30000)
            {
                break;
            }
            Thread.Sleep(SLEEP_AMOUNT);
        }
    }

    // Handle Exited event and display process information.
    private void myProcess_Exited(object sender, System.EventArgs e)
    {

        eventHandled = true;
        Console.WriteLine("Exit time:    {0}\r\n" +
            "Exit code:    {1}\r\nElapsed time: {2}", myProcess.ExitTime, myProcess.ExitCode, elapsedTime);
    }

    public static void Main(string[] args)
    {

        // Verify that an argument has been entered.
        if (args.Length <= 0)
        {
            Console.WriteLine("Enter a file name.");
            return;
        }

        // Create the process and print the document.
        PrintProcessClass myPrintProcess = new PrintProcessClass();
        myPrintProcess.PrintDoc(args[0]);
    }
}
//</snippet1>



