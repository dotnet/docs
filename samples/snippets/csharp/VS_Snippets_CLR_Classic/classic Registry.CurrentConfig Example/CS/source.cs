// <Snippet1>
using System;
using Microsoft.Win32;

class Reg {
    public static void Main() {

        // Create a RegistryKey, which will access the HKEY_CURRENT_CONFIG
        // key in the registry of this machine.
        RegistryKey rk = Registry.CurrentConfig;

        // Print out the keys.
        PrintKeys(rk);
    }

    static void PrintKeys(RegistryKey rkey) {

        // Retrieve all the subkeys for the specified key.
        String [] names = rkey.GetSubKeyNames();

        int icount = 0;

        Console.WriteLine("Subkeys of " + rkey.Name);
        Console.WriteLine("-----------------------------------------------");

        // Print the contents of the array to the console.
        foreach (String s in names) {
            Console.WriteLine(s);

            // The following code puts a limit on the number
            // of keys displayed.  Comment it out to print the
            // complete list.
            icount++;
            if (icount >= 10)
                break;
        }
    }
}
// </Snippet1>

