// System.Diagnostics
//
// Requires .NET Framework version 1.2 or higher.

// Define the namespaces used by this sample.
using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;

// <Snippet3>
namespace ProcessAsyncStreamSamples
{
    class ProcessNMakeStreamRedirection
    {
        // Define static variables shared by class methods.
        private static StreamWriter buildLogStream =null;
        private static Mutex logMutex = new Mutex();
        private static int maxLogLines = 25;
        private static int currentLogLines = 0;

        public static void RedirectNMakeCommandStreams()
        {
            String nmakeArguments = null;
            Process nmakeProcess;

            // Get the input nmake command-line arguments.
            Console.WriteLine("Enter the NMake command line arguments " +
                "(@commandfile or /f makefile, etc):");
            String inputText = Console.ReadLine();
            if (!String.IsNullOrEmpty(inputText))
            {
                nmakeArguments = inputText;
            }
               
            Console.WriteLine("Enter max line limit for log file (default is 25):");
            inputText = Console.ReadLine();
            if (!String.IsNullOrEmpty(inputText))
            {
                if (!Int32.TryParse(inputText, out maxLogLines))
                {
                    maxLogLines = 25;
                }
            }
            Console.WriteLine("Output beyond {0} lines will be ignored.",
                maxLogLines);

            // Initialize the process and its StartInfo properties.
            nmakeProcess = new Process();
            nmakeProcess.StartInfo.FileName = "NMake.exe";
            
            // Build the nmake command argument list.
            if (!String.IsNullOrEmpty(nmakeArguments))
            {
                nmakeProcess.StartInfo.Arguments = nmakeArguments;
            }

            // Set UseShellExecute to false for redirection.
            nmakeProcess.StartInfo.UseShellExecute = false;

            // Redirect the standard output of the nmake command.  
            // Read the stream asynchronously using an event handler.
            nmakeProcess.StartInfo.RedirectStandardOutput = true;
            nmakeProcess.OutputDataReceived += new DataReceivedEventHandler(NMakeOutputDataHandler);
   
            // Redirect the error output of the nmake command. 
            nmakeProcess.StartInfo.RedirectStandardError = true;
            nmakeProcess.ErrorDataReceived += new DataReceivedEventHandler(NMakeErrorDataHandler);

            logMutex.WaitOne();

            currentLogLines = 0;

            // Write a header to the log file.
            const String buildLogFile = "NmakeCmd.Txt";
            try 
            {
                buildLogStream = new StreamWriter(buildLogFile, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not open output file {0}", buildLogFile);
                Console.WriteLine("Exception = {0}", e.ToString());
                Console.WriteLine(e.Message);

                buildLogStream = null;
            }

            if (buildLogStream != null)
            {   
                Console.WriteLine("Nmake output logged to {0}", 
                    buildLogFile);
    
                buildLogStream.WriteLine();
                buildLogStream.WriteLine(DateTime.Now.ToString());
                if (!String.IsNullOrEmpty(nmakeArguments))
                {
                    buildLogStream.Write("Command line = NMake {0}",
                        nmakeArguments);
                }
                else 
                {
                    buildLogStream.Write("Command line = Nmake");
                }
                buildLogStream.WriteLine();
                buildLogStream.Flush();
            
                logMutex.ReleaseMutex();

                // Start the process.
                Console.WriteLine();
                Console.WriteLine("\nStarting Nmake command...");
                Console.WriteLine();
                nmakeProcess.Start();

                // Start the asynchronous read of the error stream.
                nmakeProcess.BeginErrorReadLine();

                // Start the asynchronous read of the output stream.
                nmakeProcess.BeginOutputReadLine();
    
                // Let the nmake command run, collecting the output.
                nmakeProcess.WaitForExit();

                nmakeProcess.Close();
                buildLogStream.Close();
                logMutex.Dispose();
            }
        }

        private static void NMakeOutputDataHandler(object sendingProcess, 
            DataReceivedEventArgs outLine)
        {
            // Collect the output, displaying it to the screen and 
            // logging it to the output file.  Cancel the read
            // operation when the maximum line limit is reached.

            if (!String.IsNullOrEmpty(outLine.Data))
            {
                logMutex.WaitOne();

                currentLogLines++;
                if (currentLogLines > maxLogLines)
                {
                    // Display the line to the console.
                    // Skip writing the line to the log file.
                    Console.WriteLine("StdOut: {0}", outLine.Data);
                }
                else if (currentLogLines == maxLogLines)
                {
                    LogToFile("StdOut", "<Max build log limit reached!>", 
                        true);
    
                    // Stop reading the output streams.
                    Process p = sendingProcess as Process;
                    if (p != null)
                    {
                        p.CancelOutputRead();
                        p.CancelErrorRead();
                    }
                }
                else 
                {
                    // Write the line to the log file.
                    LogToFile("StdOut", outLine.Data, true);
                }
                logMutex.ReleaseMutex();
            }
        }

        private static void NMakeErrorDataHandler(object sendingProcess, 
            DataReceivedEventArgs errLine)
        {
            // Collect error output, displaying it to the screen and 
            // logging it to the output file.  Cancel the error output
            // read operation when the maximum line limit is reached.

            if (!String.IsNullOrEmpty(errLine.Data))
            {
                logMutex.WaitOne();

                currentLogLines++;
                if (currentLogLines > maxLogLines)
                {
                    // Display the error line to the console.
                    // Skip writing the line to the log file.
                    Console.WriteLine("StdErr: {0}", errLine.Data);
                }
                else if (currentLogLines == maxLogLines)
                {
                    LogToFile("StdErr", "<Max build log limit reached!>", 
                        true);
    
                    // Stop reading the output streams
                    Process p = sendingProcess as Process;
                    if (p != null)
                    {
                        p.CancelErrorRead();
                        p.CancelOutputRead();

                    }
                }
                else 
                {
                    // Write the line to the log file.
                    LogToFile("StdErr", errLine.Data, true);
                }

                logMutex.ReleaseMutex();
            }
        }

        private static void LogToFile(String logPrefix, 
            String logText, bool echoToConsole)
        {
            // Write the specified line to the log file stream.
            StringBuilder logString = new StringBuilder();

            if (!String.IsNullOrEmpty(logPrefix))
            {
                logString.AppendFormat("{0}> ", logPrefix);
            }

            if (!String.IsNullOrEmpty(logText))
            {
                logString.Append(logText); 
            }

            if (buildLogStream != null)
            {
                buildLogStream.WriteLine("[{0}] {1}",
                    DateTime.Now.ToString(), logString.ToString());
                buildLogStream.Flush();
            }
            
            if (echoToConsole)
            {
                Console.WriteLine(logString.ToString());
            }
        }
    }
} 
// </Snippet3>

namespace ProcessAsyncStreamSamples
{

    class ProcessSampleMain
    {
        /// The main entry point for the application.
        static void Main()
        {
            try 
            {
                ProcessNMakeStreamRedirection.RedirectNMakeCommandStreams();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception:");
                Console.WriteLine(e.ToString());
            }
        }
    }
}