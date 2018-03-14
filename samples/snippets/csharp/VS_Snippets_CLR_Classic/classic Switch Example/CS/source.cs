using System;
using System.Diagnostics;

// <Snippet1>
// The following are possible values for the new switch.
public enum MethodTracingSwitchLevel
{
    Off = 0,
    EnteringMethod = 1,
    ExitingMethod = 2,
    Both = 3,
}
// </Snippet1>
// <Snippet2>
public class MyMethodTracingSwitch : Switch
{
     protected bool outExit;
     protected bool outEnter;
     protected MethodTracingSwitchLevel level;

     public MyMethodTracingSwitch(string displayName, string description) :
         base(displayName, description)
     {
     }

     public MethodTracingSwitchLevel Level
     {
         get
         {
             return level;
         }
         set
         {
             SetSwitchSetting((int)value);
         }
     }

     protected void SetSwitchSetting(int value)
     {
         if (value < 0)
         {
             value = 0;
         }
         if (value > 3)
         {
             value = 3;
         }

         level = (MethodTracingSwitchLevel)value;

         outEnter = false;
         if ((value == (int)MethodTracingSwitchLevel.EnteringMethod) ||
             (value == (int)MethodTracingSwitchLevel.Both))
         {
             outEnter = true;
         }

         outExit = false;
         if ((value == (int)MethodTracingSwitchLevel.ExitingMethod) ||
             (value == (int)MethodTracingSwitchLevel.Both))
         {
             outExit = true;
         }
     }

     public bool OutputExit
     {
         get
         {
             return outExit;
         }
     }

     public bool OutputEnter
     {
         get
         {
             return outEnter;
         }
     }
 }
// </Snippet2>
// <Snippet3>
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
// </Snippet3>

