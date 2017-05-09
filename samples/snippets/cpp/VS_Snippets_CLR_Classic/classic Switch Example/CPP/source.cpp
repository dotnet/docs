#using <System.dll>

using namespace System;
using namespace System::Diagnostics;

// <Snippet1>
// The following are possible values for the new switch.
public enum class MethodTracingSwitchLevel
{
    Off = 0,
    EnteringMethod = 1,
    ExitingMethod = 2,
    Both = 3
};


// </Snippet1>
// <Snippet2>
public ref class MyMethodTracingSwitch: public Switch
{
protected:
    bool outExit;
    bool outEnter;
    MethodTracingSwitchLevel level;

public:
    MyMethodTracingSwitch( String^ displayName, String^ description )
       : Switch( displayName, description )
    {}

    property MethodTracingSwitchLevel Level
    {
        MethodTracingSwitchLevel get()
        {
            return level;
        }

       void set( MethodTracingSwitchLevel value )
       {
           SetSwitchSetting( (int)value );
       }
    }

protected:
    void SetSwitchSetting( int value )
    {
        if ( value < 0 )
        {
            value = 0;
        }

        if ( value > 3 )
        {
            value = 3;
        }

        level = (MethodTracingSwitchLevel)value;
        outEnter = false;
        if ((value == (int)MethodTracingSwitchLevel::EnteringMethod) ||
            (value == (int)MethodTracingSwitchLevel::Both))
        {
            outEnter = true;
        }

        outExit = false;
        if ((value == (int)MethodTracingSwitchLevel::ExitingMethod) ||
            (value == (int)MethodTracingSwitchLevel::Both))
        {
            outExit = true;
        }
    }

public:
    property bool OutputExit
    {
        bool get()
        {
            return outExit;
        }
    }

    property bool OutputEnter
    {
        bool get()
        {
            return outEnter;
        }
    }
};


// </Snippet2>
// <Snippet3>
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
// </Snippet3>

int main()
{
    Class1::main();
}

