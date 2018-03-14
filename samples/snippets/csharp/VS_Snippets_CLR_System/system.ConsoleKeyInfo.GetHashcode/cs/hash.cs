//<snippet1>
// This example demonstrates the ConsoleKeyInfo.GetHashCode() method.

using System;
using System.Text;

class Sample 
{
    public static void Main() 
    {
    string k1 = "\nEnter a key ......... ";
    string key1 = "";
    string hashCodeFmt = "The hash code for the {0} key is {1}.";
    string prompt = "Press the escape key (ESC) to quit, " + 
                    "or any other key to continue.";
    ConsoleKeyInfo cki1;
    int hashCode = 0;

//
// The Console.TreatControlCAsInput property prevents this example from
// ending if you press CTL+C, however all other operating system keys and 
// shortcuts, such as ALT+TAB or the Windows Logo key, are still in effect. 
//
    Console.TreatControlCAsInput = true;

// Request that the user enter two key presses. A key press and any 
// combination shift, CTRL, and ALT modifier keys is permitted.
    do 
    {
        Console.Write(k1);
        cki1 = Console.ReadKey(false);
        Console.WriteLine();
//
        key1 = KeyCombination(cki1);
        hashCode = cki1.GetHashCode();
        Console.WriteLine(hashCodeFmt, key1, hashCode);
//
        Console.WriteLine(prompt);
        cki1 = Console.ReadKey(true);
    } while (cki1.Key != ConsoleKey.Escape);
// Note: This example requires the Escape (Esc) key.
    }

// The KeyCombination() method creates a string that specifies what 
// key and what combination of shift, CTRL, and ALT modifier keys 
// were pressed simultaneously.

    protected static string KeyCombination(ConsoleKeyInfo sourceCki)
    {
    StringBuilder sb = new StringBuilder();
    sb.Length = 0;
    string keyCombo;
    if (sourceCki.Modifiers != 0)
        {
        if ((sourceCki.Modifiers & ConsoleModifiers.Alt) != 0)
            sb.Append("ALT+");
        if ((sourceCki.Modifiers & ConsoleModifiers.Shift) != 0)
            sb.Append("SHIFT+");
        if ((sourceCki.Modifiers & ConsoleModifiers.Control) != 0)
            sb.Append("CTL+");
        }
    sb.Append(sourceCki.Key.ToString());
    keyCombo = sb.ToString();
    return keyCombo;
    }
}

/*
This example produces results similar to the following output:

Enter a key ......... a
The hash code for the A key is 97.
Press the escape key (ESC) to quit, or any other key to continue.

Enter a key ......... S
The hash code for the SHIFT+S key is 83.
Press the escape key (ESC) to quit, or any other key to continue.

Enter a key .........
The hash code for the ALT+SHIFT+CTL+J key is 7.
Press the escape key (ESC) to quit, or any other key to continue.

*/
//</snippet1>
