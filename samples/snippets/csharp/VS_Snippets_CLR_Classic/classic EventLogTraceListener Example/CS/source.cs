using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
public static void Main(string[] args) {

    // Create a trace listener for the event log.
    EventLogTraceListener myTraceListener = new EventLogTraceListener("myEventLogSource");
 
    // Add the event log trace listener to the collection.
    Trace.Listeners.Add(myTraceListener);
 
    // Write output to the event log.
    Trace.WriteLine("Test output");
 }
 
// </Snippet1>
}
