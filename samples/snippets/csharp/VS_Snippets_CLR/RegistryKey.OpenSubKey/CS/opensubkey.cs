//<Snippet1>
using System;
using Microsoft.Win32;
using Microsoft.VisualBasic;

public class Example
{
    public static void Main()
    {
        // Delete and recreate the test key.
        Registry.CurrentUser.DeleteSubKey("RegistryOpenSubKeyExample", false);
        RegistryKey rk = Registry.CurrentUser.CreateSubKey("RegistryOpenSubKeyExample");
        rk.Close();

        // Obtain an instance of RegistryKey for the CurrentUser registry 
        // root. 
        RegistryKey rkCurrentUser = Registry.CurrentUser;

        // Obtain the test key (read-only) and display it.
        RegistryKey rkTest = rkCurrentUser.OpenSubKey("RegistryOpenSubKeyExample");
        Console.WriteLine("Test key: {0}", rkTest);
        rkTest.Close();
        rkCurrentUser.Close();

        // Obtain the test key in one step, using the CurrentUser registry 
        // root.
        rkTest = Registry.CurrentUser.OpenSubKey("RegistryOpenSubKeyExample");
        Console.WriteLine("Test key: {0}", rkTest);
        rkTest.Close();

        // Open the test key in read/write mode.
        rkTest = Registry.CurrentUser.OpenSubKey("RegistryOpenSubKeyExample", true);
        rkTest.SetValue("TestName", "TestValue");
        Console.WriteLine("Test value for TestName: {0}", rkTest.GetValue("TestName"));
        rkTest.Close();
    } //Main
} //Example
//</Snippet1>



