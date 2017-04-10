// <Snippet1>
using System;
using Microsoft.Win32;

class RegGetDef
{
    public static void Main()
    {
        // Create a reference to a valid key.  In order for this code to
        // work, the indicated key must have been created previously.
        // The key name is not case-sensitive.
        RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\myTestKey", false);
        // Get the value from the specified name/value pair in the key.

        string valueName = "myTestValue";

        Console.WriteLine("Retrieving registry value ...");
        Console.WriteLine();
        object o = rk.GetValue(valueName);
        Console.WriteLine("Object Type = " + o.GetType().FullName);
        Console.WriteLine();
        switch (rk.GetValueKind(valueName))
        {
            case RegistryValueKind.String:
            case RegistryValueKind.ExpandString:
                Console.WriteLine("Value = " + o);
                break;
            case RegistryValueKind.Binary:
                foreach (byte b in (byte[])o)
                {
                    Console.Write("{0:x2} ", b);
                }
                Console.WriteLine();
                break;
            case RegistryValueKind.DWord:
                Console.WriteLine("Value = " + Convert.ToString((Int32)o));
                break;
            case RegistryValueKind.QWord:
                Console.WriteLine("Value = " + Convert.ToString((Int64)o));
                break;
            case RegistryValueKind.MultiString:
                foreach (string s in (string[])o)
                {
                    Console.Write("[{0:s}], ", s);
                }
                Console.WriteLine();
                break;
            default:
                Console.WriteLine("Value = (Unknown)");
                break;
        }


        // Attempt to retrieve a value that does not exist; the specified
        // default value is returned.
        string def = (string)rk.GetValue("notavalue", "The default to return");
        Console.WriteLine();
        Console.WriteLine(def);
        
        rk.Close();
    }
}
/*
Output:
Retrieving registry value ...

Object Type = System.String

Value = testData

The default to return
*/
// </Snippet1>

