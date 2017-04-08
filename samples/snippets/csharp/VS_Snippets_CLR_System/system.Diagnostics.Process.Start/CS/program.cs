//<Snippet1>
// NOTE: This example requires a text.txt file file in your Documents folder
using System;
using System.Diagnostics;
using System.Security;
using System.ComponentModel;

class Example
{
    static void Main()
    {
        Console.Write("Enter your domain: ");
        string domain = Console.ReadLine();
        Console.Write("Enter you user name: ");
        string uname = Console.ReadLine();
        Console.Write("Enter your password: ");
        SecureString password = new SecureString();
        ConsoleKeyInfo key;
        do {
           key = Console.ReadKey(true);

           // Ignore any key out of range.
           if (((int) key.Key) >= 33 && ((int) key.Key <= 90) && key.Key != ConsoleKey.Enter) {
              // Append the character to the password.
              password.AppendChar(key.KeyChar);
              Console.Write("*");
           }
        // Exit if Enter key is pressed.
        } while (key.Key != ConsoleKey.Enter);
        Console.WriteLine();
        
        try {
            Console.WriteLine("\nTrying to launch NotePad using your login information...");
            Process.Start("notepad.exe", uname, password, domain);
        }
        catch (Win32Exception ex) {
            Console.WriteLine(ex.Message);
        }

        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";

        try {
             // The following call to Start succeeds if test.txt exists.
             Console.WriteLine("\nTrying to launch 'text.txt'...");
             Process.Start(path + "text.txt");
        }
        catch (Win32Exception ex) {
            Console.WriteLine(ex.Message);
        }

        try {
             // Attempting to start in a shell using this Start overload fails. This causes
             // the following exception, which is picked up in the catch block below:
             // The specified executable is not a valid application for this OS platform.
             Console.WriteLine("\nTrying to launch 'text.txt' with your login information...");
             Process.Start(path + "text.txt", uname, password, domain);
         }
         catch (Win32Exception ex)
         {
             Console.WriteLine(ex.Message);
         }
         finally {
            password.Dispose();
         }
    }
}
//</Snippet1>
