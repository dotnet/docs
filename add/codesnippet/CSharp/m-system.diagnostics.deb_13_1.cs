// Class-level declaration.
 // Create a TraceSwitch.
 static TraceSwitch generalSwitch = new TraceSwitch("General", "Entire Application");
 
 static public void MyErrorMethod(Object myObject, String category) {
    // Write the message if the TraceSwitch level is set to Verbose.
    Debug.WriteIf(generalSwitch.TraceVerbose, myObject.ToString() + 
       " is not a valid object for category: ", category);
 
    // Write a second message if the TraceSwitch level is set to Error or higher.
    Debug.WriteLineIf(generalSwitch.TraceError, " Please use a different category.");
 }
