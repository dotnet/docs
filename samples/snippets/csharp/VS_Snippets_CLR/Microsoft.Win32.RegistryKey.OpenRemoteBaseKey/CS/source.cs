// <Snippet1>
using System;
using System.IO;
using System.Security.Permissions;
using Microsoft.Win32;


class RemoteKey
{
    static void Main(string[] args)
    {
        RegistryKey environmentKey;
        string remoteName;

        // Check that an argument was specified when the 
        // program was invoked.
        if(args.Length == 0)
        {
            Console.WriteLine("Error: The name of the remote " +
                "computer must be specified when the program is " +
                "invoked.");
            return;
        }
        else
        {
            remoteName = args[0];
        }

        try
        {
            // Open HKEY_CURRENT_USER\Environment 
            // on a remote computer.
            environmentKey = RegistryKey.OpenRemoteBaseKey(
                RegistryHive.CurrentUser, remoteName).OpenSubKey(
                "Environment");
        }
        catch(IOException e)
        {
            Console.WriteLine("{0}: {1}", 
                e.GetType().Name, e.Message);
            return;
        }

        // Print the values.
        Console.WriteLine("\nThere are {0} values for {1}.", 
            environmentKey.ValueCount.ToString(), 
            environmentKey.Name);
        foreach(string valueName in environmentKey.GetValueNames())
        {
            Console.WriteLine("{0,-20}: {1}", valueName, 
                environmentKey.GetValue(valueName).ToString());
        }

        // Close the registry key.
        environmentKey.Close();
    }
}
// </Snippet1>