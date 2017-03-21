public ref class Class1
{
private:

    /* Create an instance of MyMethodTracingSwitch.*/
    static MyMethodTracingSwitch^ mySwitch =
        gcnew MyMethodTracingSwitch( "Methods","Trace entering and exiting method" );

public:
    static void main()
    {
        // Add the console listener to see trace messages as console output
        Trace::Listeners->Add(gcnew ConsoleTraceListener(true));
        Debug::AutoFlush = true;

        // Set the switch level to both enter and exit
        mySwitch->Level = MethodTracingSwitchLevel::Both;

        // Write a diagnostic message if the switch is set to entering.
        Debug::WriteLineIf(mySwitch->OutputEnter, "Entering Main");

        // Insert code to handle processing here...

        // Write another diagnostic message if the switch is set to exiting.
        Debug::WriteLineIf(mySwitch->OutputExit, "Exiting Main");
    }
};