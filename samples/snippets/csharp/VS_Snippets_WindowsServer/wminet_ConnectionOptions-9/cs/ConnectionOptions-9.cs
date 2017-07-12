//<Snippet1>
using System;
using System.Management;
using System.Security;

public class RemoteConnect
{
    public static void Main()
    {
        // Build an options object for the remote connection
        // if you plan to connect to the remote
        // computer with a different user name
        // and password than the one you are currently using.
        SecureString pw = GetPassword();
        ConnectionOptions options =
            new ConnectionOptions("MS_409", "userName", pw,
            "ntlmdomain:DOMAIN",
            System.Management.ImpersonationLevel.Impersonate,
            System.Management.AuthenticationLevel.Default, true,
            null, System.TimeSpan.MaxValue);
        pw.Dispose();

        // Make a connection to a remote computer.
        // Replace the "FullComputerName" section of the
        // string "\\\\FullComputerName\\root\\cimv2" with
        // the full computer name or IP address of the
        // remote computer.
        ManagementScope scope =
            new ManagementScope(
            "\\\\FullComputerName\\root\\cimv2", options);
        scope.Connect();

        //Query system for Operating System information
        ObjectQuery query = new ObjectQuery(
            "SELECT * FROM Win32_OperatingSystem");
        ManagementObjectSearcher searcher =
            new ManagementObjectSearcher(scope, query);

        ManagementObjectCollection queryCollection = searcher.Get();
        foreach (ManagementObject m in queryCollection)
        {
            // Display the remote computer information
            Console.WriteLine("Computer Name : {0}",
                m["csname"]);
            Console.WriteLine("Windows Directory : {0}",
                m["WindowsDirectory"]);
            Console.WriteLine("Operating System: {0}",
                m["Caption"]);
            Console.WriteLine("Version: {0}", m["Version"]);
            Console.WriteLine("Manufacturer : {0}",
                m["Manufacturer"]);
        }
    }

    /// <summary>
    /// Read a password from the console into a SecureString
    /// </summary>
    /// <returns>Password stored in a secure string</returns>
    public static SecureString GetPassword()
    {
        SecureString password = new SecureString();
        Console.WriteLine("Enter password: ");

        // get the first character of the password
        ConsoleKeyInfo nextKey = Console.ReadKey(true);

        while (nextKey.Key != ConsoleKey.Enter)
        {
            if (nextKey.Key == ConsoleKey.Backspace)
            {
                if (password.Length > 0)
                {
                    password.RemoveAt(password.Length - 1);

                    // erase the last * as well
                    Console.Write(nextKey.KeyChar);
                    Console.Write(" ");
                    Console.Write(nextKey.KeyChar);
                }
            }
            else
            {
                password.AppendChar(nextKey.KeyChar);
                Console.Write("*");
            }

            nextKey = Console.ReadKey(true);
        }

        Console.WriteLine();

        // lock the password down
        password.MakeReadOnly();
        return password;
    }
}
//</Snippet1>