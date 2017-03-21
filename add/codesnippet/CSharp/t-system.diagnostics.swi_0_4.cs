public class Class1
{
    /* Create an instance of MyMethodTracingSwitch.*/
    static MyMethodTracingSwitch mySwitch =
        new MyMethodTracingSwitch("Methods", "Trace entering and exiting method");

    public static void Main()
    {
        // Add the console listener to see trace messages as console output
        Trace.Listeners.Add(new ConsoleTraceListener(true));
        Debug.AutoFlush = true;

        // Set the switch level to both enter and exit
        mySwitch.Level = MethodTracingSwitchLevel.Both;

        // Write a diagnostic message if the switch is set to entering.
        Debug.WriteLineIf(mySwitch.OutputEnter, "Entering Main");

        // Insert code to handle processing here...

        // Write another diagnostic message if the switch is set to exiting.
        Debug.WriteLineIf(mySwitch.OutputExit, "Exiting Main");
    }
}