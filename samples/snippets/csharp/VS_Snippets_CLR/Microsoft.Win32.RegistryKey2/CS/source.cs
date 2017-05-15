// <Snippet1>
using System;
using System.Security.Permissions;
using Microsoft.Win32;

class RegKey
{
    static void Main()
    {
        // Create a subkey named Test9999 under HKEY_CURRENT_USER.
        RegistryKey test9999 = 
            Registry.CurrentUser.CreateSubKey("Test9999");
        // Create two subkeys under HKEY_CURRENT_USER\Test9999. The
        // keys are disposed when execution exits the using statement.
        using(RegistryKey 
            testName = test9999.CreateSubKey("TestName"),
            testSettings = test9999.CreateSubKey("TestSettings"))
        {
            // Create data for the TestSettings subkey.
            testSettings.SetValue("Language", "French");
            testSettings.SetValue("Level", "Intermediate");
            testSettings.SetValue("ID", 123);
        }

        // <Snippet2>
        // Print the information from the Test9999 subkey.
        Console.WriteLine("There are {0} subkeys under {1}.", 
            test9999.SubKeyCount.ToString(), test9999.Name);
        foreach(string subKeyName in test9999.GetSubKeyNames())
        {
            using(RegistryKey 
                tempKey = test9999.OpenSubKey(subKeyName))
            {
                Console.WriteLine("\nThere are {0} values for {1}.", 
                    tempKey.ValueCount.ToString(), tempKey.Name);
                foreach(string valueName in tempKey.GetValueNames())
                {
                    Console.WriteLine("{0,-8}: {1}", valueName, 
                        tempKey.GetValue(valueName).ToString());
                }
            }
        }
        // </Snippet2>

        // <Snippet3>
        using(RegistryKey 
            testSettings = test9999.OpenSubKey("TestSettings", true))
        {
            // Delete the ID value.
            testSettings.DeleteValue("id");

            // Verify the deletion.
            Console.WriteLine((string)testSettings.GetValue(
                "id", "ID not found."));
        }
        // </Snippet3>

        // <Snippet4>
        // Delete or close the new subkey.
        Console.Write("\nDelete newly created registry key? (Y/N) ");
        if(Char.ToUpper(Convert.ToChar(Console.Read())) == 'Y')
        {
            Registry.CurrentUser.DeleteSubKeyTree("Test9999");
            Console.WriteLine("\nRegistry key {0} deleted.", 
                test9999.Name);
        }
        else
        {
            Console.WriteLine("\nRegistry key {0} closed.", 
                test9999.ToString());
            test9999.Close();
        }
        // </Snippet4>
    }
}
// </Snippet1>