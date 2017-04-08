// <Snippet1>
using System;
using Microsoft.Win32;
using Microsoft.VisualBasic;

public class Example
{
    public static void Main()
    {
        // Delete and recreate the test key.
        Registry.CurrentUser.DeleteSubKey("RegistryValueOptionsExample", false);
        RegistryKey rk = 
            Registry.CurrentUser.CreateSubKey("RegistryValueOptionsExample");

        // Add a value that contains an environment variable.
        rk.SetValue("ExpandValue", "The path is %PATH%", RegistryValueKind.ExpandString);

        // Retrieve the value, first without expanding the environment 
        // variable and then expanding it.
        Console.WriteLine("Unexpanded: \"{0}\"", 
            rk.GetValue("ExpandValue", "No Value", 
            RegistryValueOptions.DoNotExpandEnvironmentNames));
        Console.WriteLine("Expanded: \"{0}\"", rk.GetValue("ExpandValue"));
    } //Main
} //Example
// </Snippet1>


