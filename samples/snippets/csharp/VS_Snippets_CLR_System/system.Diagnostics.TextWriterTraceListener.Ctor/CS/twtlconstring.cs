//<snippet3>
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

class TWTLConStringMod
{

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
            // Create a TextWriterTraceListener object that takes a 
            // file specification.
            TextWriterTraceListener textListener;
            try
            {
                textListener = new TextWriterTraceListener(args[0]);
                Trace.Listeners.Add(textListener);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error creating TextWriterTraceListener for trace " +
                    "file \"{0}\":\r\n{1}", args[0], ex.Message);
                return;
            }

            // Write these messages only to the TextWriterTraceListener.
            textListener.WriteLine("This is trace listener named \""+textListener.Name+"\"");
            textListener.WriteLine("Trace written to a file: " +
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
//</snippet3>

