// <Snippet1>
using namespace System;

void OnCancelKeyPressed(Object^ sender, 
    ConsoleCancelEventArgs^ args)
{
    Console::WriteLine("{0}The read operation has been interrupted.",
        Environment::NewLine);

    Console::WriteLine("  Key pressed: {0}", args->SpecialKey);

    Console::WriteLine("  Cancel property: {0}", args->Cancel);

    // Set the Cancel property to true to prevent the process from 
    // terminating.
    Console::WriteLine("Setting the Cancel property to true...");
    args->Cancel = true;

    // Announce the new value of the Cancel property.
    Console::WriteLine("  Cancel property: {0}", args->Cancel);
    Console::WriteLine("The read operation will resume...{0}",
        Environment::NewLine);
}

int main()
{       
    // Clear the screen.
    Console::Clear();

    // Establish an event handler to process key press events.
    Console::CancelKeyPress += 
        gcnew ConsoleCancelEventHandler(OnCancelKeyPressed);

    while (true)
    {
        // Prompt the user.
        Console::Write("Press any key, or 'X' to quit, or ");
        Console::WriteLine("CTRL+C to interrupt the read operation:");

        // Start a console read operation. Do not display the input.
        ConsoleKeyInfo^ keyInfo = Console::ReadKey(true);

        // Announce the name of the key that was pressed .
        Console::WriteLine("  Key pressed: {0}{1}", keyInfo->Key, 
            Environment::NewLine);

        // Exit if the user pressed the 'X' key.
        if (keyInfo->Key == ConsoleKey::X)
        {
            break;
        }
    }
}
// The example displays output similar to the following:
//    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
//    Key pressed: J
//    
//    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
//    Key pressed: Enter
//    
//    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
//    
//    The read operation has been interrupted.
//    Key pressed: ControlC
//    Cancel property: False
//    Setting the Cancel property to true...
//    Cancel property: True
//    The read operation will resume...
//    
//    Key pressed: Q
//    
//    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
//    Key pressed: X
// </Snippet1>
