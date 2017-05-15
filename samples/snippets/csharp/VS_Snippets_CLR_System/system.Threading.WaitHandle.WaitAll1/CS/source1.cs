// <Snippet1>
using System;
using System.IO;
using System.Security.Permissions;
using System.Threading;

class Test
{
    static void Main()
    {
        const int numberOfFiles = 5;
        string dirName = @"C:\TestTest";
        string fileName;

        byte[] byteArray;
        Random randomGenerator = new Random();

        ManualResetEvent[] manualEvents = 
            new ManualResetEvent[numberOfFiles];
        State stateInfo;

        if(!Directory.Exists(dirName))
        {
            Directory.CreateDirectory(dirName);
        }

        // Queue the work items that create and write to the files.
        for(int i = 0; i < numberOfFiles; i++)
        {
            fileName = string.Concat(
                dirName, @"\Test", i.ToString(), ".dat");

            // Create random data to write to the file.
            byteArray = new byte[1000000];
            randomGenerator.NextBytes(byteArray);

            manualEvents[i] = new ManualResetEvent(false);

            stateInfo = 
                new State(fileName, byteArray, manualEvents[i]);

            ThreadPool.QueueUserWorkItem(new WaitCallback(
                Writer.WriteToFile), stateInfo);
        }
    
        // Since ThreadPool threads are background threads, 
        // wait for the work items to signal before exiting.
        WaitHandle.WaitAll(manualEvents);
        Console.WriteLine("Files written - main exiting.");
    }
}

// Maintain state to pass to WriteToFile.
class State
{
    public string fileName;
    public byte[] byteArray;
    public ManualResetEvent manualEvent;

    public State(string fileName, byte[] byteArray, 
        ManualResetEvent manualEvent)
    {
        this.fileName = fileName;
        this.byteArray = byteArray;
        this.manualEvent = manualEvent;
    }
}

class Writer
{
    static int workItemCount = 0;
    Writer() {}

    public static void WriteToFile(object state)
    {
        int workItemNumber = workItemCount;
        Interlocked.Increment(ref workItemCount);
        Console.WriteLine("Starting work item {0}.",
            workItemNumber.ToString());
        State stateInfo = (State)state;
        FileStream fileWriter = null;

        // Create and write to the file.
        try
        {
            fileWriter = new FileStream(
                stateInfo.fileName, FileMode.Create);
            fileWriter.Write(stateInfo.byteArray, 
                0, stateInfo.byteArray.Length);
        }
        finally
        {
            if(fileWriter != null)
            {
                fileWriter.Close();
            }

            // Signal Main that the work item has finished.
            Console.WriteLine("Ending work item {0}.", 
                workItemNumber.ToString());
            stateInfo.manualEvent.Set();
        }
    }
}
// </Snippet1>