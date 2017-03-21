/* Create a listener that outputs to the console screen, and 
  * add it to the debug listeners. */
 TextWriterTraceListener myWriter = new 
    TextWriterTraceListener(System.Console.Out);
 Debug.Listeners.Add(myWriter);
