// <Snippet1>
using System;

class Sample 
{
    public static void Main()
    {
        ConsoleKeyInfo cki;

        Console.Clear();

        // Establish an event handler to process key press events.
        Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);
        while (true) {
            Console.Write("Press any key, or 'X' to quit, or ");
            Console.WriteLine("CTRL+C to interrupt the read operation:");

            // Start a console read operation. Do not display the input.
            cki = Console.ReadKey(true);

            // Announce the name of the key that was pressed .
            Console.WriteLine("  Key pressed: {0}\n", cki.Key);

            // Exit if the user pressed the 'X' key.
            if (cki.Key == ConsoleKey.X) break;
        }
    }

    protected static void myHandler(object sender, ConsoleCancelEventArgs args)
    {
        Console.WriteLine("\nThe read operation has been interrupted.");

        Console.WriteLine("  Key pressed: {0}", args.SpecialKey);

        Console.WriteLine("  Cancel property: {0}", args.Cancel);

        // Set the Cancel property to true to prevent the process from terminating.
        Console.WriteLine("Setting the Cancel property to true...");
        args.Cancel = true;

        // Announce the new value of the Cancel property.
        Console.WriteLine("  Cancel property: {0}", args.Cancel);
        Console.WriteLine("The read operation will resume...\n");
    }
}
// The example displays output similar to the follwoing:
//    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
//      Key pressed: J
//    
//    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
//      Key pressed: Enter
//    
//    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
//    
//    The read operation has been interrupted.
//      Key pressed: ControlC
//      Cancel property: False
//    Setting the Cancel property to true...
//      Cancel property: True
//    The read operation will resume...
//    
//      Key pressed: Q
//    
//    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
//      Key pressed: X
// </Snippet1>