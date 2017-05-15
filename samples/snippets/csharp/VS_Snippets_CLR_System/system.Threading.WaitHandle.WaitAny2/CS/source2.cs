// <Snippet1>
using System;
using System.IO;
using System.Threading;

class Test
{
    static void Main()
    {
        Search search = new Search();
        search.FindFile("SomeFile.dat");
    }
}

class Search
{
    // Maintain state information to pass to FindCallback.
    class State
    {
        public AutoResetEvent autoEvent;
        public string         fileName;

        public State(AutoResetEvent autoEvent, string fileName)
        {
            this.autoEvent    = autoEvent;
            this.fileName     = fileName;
        }
    }

    AutoResetEvent[] autoEvents;
    String[] diskLetters;

    public Search()
    {
        // Retrieve an array of disk letters.
        diskLetters = Environment.GetLogicalDrives();

        autoEvents = new AutoResetEvent[diskLetters.Length];
        for(int i = 0; i < diskLetters.Length; i++)
        {
            autoEvents[i] = new AutoResetEvent(false);
        }
    }

    // Search for fileName in the root directory of all disks.
    public void FindFile(string fileName)
    {
        for(int i = 0; i < diskLetters.Length; i++)
        {
            Console.WriteLine("Searching for {0} on {1}.",
                fileName, diskLetters[i]);
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(FindCallback), 
                new State(autoEvents[i], diskLetters[i] + fileName));
        }

        // Wait for the first instance of the file to be found.
        int index = WaitHandle.WaitAny(autoEvents, 3000, false);
        if(index == WaitHandle.WaitTimeout)
        {
            Console.WriteLine("\n{0} not found.", fileName);
        }
        else
        {
            Console.WriteLine("\n{0} found on {1}.", fileName,
                diskLetters[index]);
        }
    }

    // Search for stateInfo.fileName.
    void FindCallback(object state)
    {
        State stateInfo = (State)state;

        // Signal if the file is found.
        if(File.Exists(stateInfo.fileName))
        {
            stateInfo.autoEvent.Set();
        }
    }
}
// </Snippet1>