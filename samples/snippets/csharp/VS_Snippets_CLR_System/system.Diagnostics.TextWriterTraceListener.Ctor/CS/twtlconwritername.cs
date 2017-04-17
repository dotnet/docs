//<snippet5>
using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic;

class TWTLConWriterNameMod
{

    const string LISTENER_NAME = "myWriterListener";

    // args(0) is the specification of the trace log file.
    public static void Main(string[] args)
    {

        // Verify that a parameter was entered.
        if (args.Length==0)
        {
            Console.WriteLine("Enter a trace file specification.");

        }
        else
        {
            // Create a StreamWriter object that supports appending.
            StreamWriter traceWriter;
            try
            {
                traceWriter = new StreamWriter(args[0], true);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error creating StreamWriter for trace file \"{0}\":" +
                    "\r\n{1}", args[0], ex.Message);
                return;
            }

            // Create a TextWriterTraceListener that takes a StreamWriter.
            TextWriterTraceListener textListener;
            textListener = new TextWriterTraceListener(traceWriter, LISTENER_NAME);
            Trace.Listeners.Add(textListener);

            // Write these messages only to this TextWriterTraceListener.
            textListener.WriteLine("This is trace listener named \""+textListener.Name+"\"");
            textListener.WriteLine("Trace written through a stream to: " +
                "\r\n    \""+args[0]+"\"");

            // Write a message to all trace listeners.
            Trace.WriteLine(String.Format("This trace message written {0} to all listeners.", DateTime.Now));

            // Flush and close the output.
            Trace.Flush();
            textListener.Flush();
            textListener.Close();
        }
    }
}
//</snippet5>
