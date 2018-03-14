using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>
// Class-level declaration.
 // Create a TraceSwitch.
 static TraceSwitch generalSwitch = new TraceSwitch("General", "Entire Application");
 
 static public void MyErrorMethod(Object myObject, String category) {
    // Write the message if the TraceSwitch level is set to Verbose.
    if(generalSwitch.TraceVerbose)
       Trace.Write(myObject.ToString() + " is not a valid object for category: ", 
          category);
 
    // Write a second message if the TraceSwitch level is set to Error or higher.
    if(generalSwitch.TraceError)
       Trace.WriteLine(" Please use a different category.");
 }

// </Snippet1>
}
