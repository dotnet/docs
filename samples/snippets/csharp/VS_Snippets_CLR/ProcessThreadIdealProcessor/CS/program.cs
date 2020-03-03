//<Snippet1>
using System;
using System.Diagnostics;

namespace ProcessThreadIdealProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Make sure there is an instance of notepad running.
            Process[] notepads = Process.GetProcessesByName("notepad");
            if (notepads.Length == 0)
                Process.Start("notepad");
            ProcessThreadCollection threads;
            //Process[] notepads;
            // Retrieve the Notepad processes.
            notepads = Process.GetProcessesByName("Notepad");
            // Get the ProcessThread collection for the first instance
            threads = notepads[0].Threads;
            // Set the properties on the first ProcessThread in the collection
            threads[0].IdealProcessor = 0;
            threads[0].ProcessorAffinity = (IntPtr)1;
        }
    }
}
//</Snippet1>
