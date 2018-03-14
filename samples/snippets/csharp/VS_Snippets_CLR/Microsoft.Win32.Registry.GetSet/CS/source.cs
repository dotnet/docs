//<Snippet1>
using System;
using Microsoft.Win32;

public class Example
{
    public static void Main()
    {
        // The name of the key must include a valid root.
        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "RegistrySetValueExample";
        const string keyName = userRoot + "\\" + subkey;

        // An int value can be stored without specifying the
        // registry data type, but long values will be stored
        // as strings unless you specify the type. Note that
        // the int is stored in the default name/value
        // pair.
        Registry.SetValue(keyName, "", 5280);
        Registry.SetValue(keyName, "TestLong", 12345678901234,
            RegistryValueKind.QWord);

        // Strings with expandable environment variables are
        // stored as ordinary strings unless you specify the
        // data type.
        Registry.SetValue(keyName, "TestExpand", "My path: %path%");
        Registry.SetValue(keyName, "TestExpand2", "My path: %path%",
            RegistryValueKind.ExpandString);

        // Arrays of strings are stored automatically as 
        // MultiString. Similarly, arrays of Byte are stored
        // automatically as Binary.
        string[] strings = {"One", "Two", "Three"};
        Registry.SetValue(keyName, "TestArray", strings);

        // Your default value is returned if the name/value pair
        // does not exist.
        string noSuch = (string) Registry.GetValue(keyName, 
            "NoSuchName",
            "Return this default if NoSuchName does not exist.");
        Console.WriteLine("\r\nNoSuchName: {0}", noSuch);

        // Retrieve the int and long values, specifying 
        // numeric default values in case the name/value pairs
        // do not exist. The int value is retrieved from the
        // default (nameless) name/value pair for the key.
        int tInteger = (int) Registry.GetValue(keyName, "", -1);
        Console.WriteLine("(Default): {0}", tInteger);
        long tLong = (long) Registry.GetValue(keyName, "TestLong",
            long.MinValue);
        Console.WriteLine("TestLong: {0}", tLong);

        // When retrieving a MultiString value, you can specify
        // an array for the default return value. 
        string[] tArray = (string[]) Registry.GetValue(keyName,
            "TestArray",
            new string[] {"Default if TestArray does not exist."});
        for(int i=0; i<tArray.Length; i++)
        {
            Console.WriteLine("TestArray({0}): {1}", i, tArray[i]);
        }

        // A string with embedded environment variables is not
        // expanded if it was stored as an ordinary string.
        string tExpand = (string) Registry.GetValue(keyName,
             "TestExpand", 
             "Default if TestExpand does not exist.");
        Console.WriteLine("TestExpand: {0}", tExpand);

        // A string stored as ExpandString is expanded.
        string tExpand2 = (string) Registry.GetValue(keyName,
            "TestExpand2",
            "Default if TestExpand2 does not exist.");
        Console.WriteLine("TestExpand2: {0}...",
            tExpand2.Substring(0, 40));

        Console.WriteLine("\r\nUse the registry editor to examine the key.");
        Console.WriteLine("Press the Enter key to delete the key.");
        Console.ReadLine();
        Registry.CurrentUser.DeleteSubKey(subkey);
    }
}
//
// This code example produces output similar to the following:
//
//NoSuchName: Return this default if NoSuchName does not exist.
//(Default): 5280
//TestLong: 12345678901234
//TestArray(0): One
//TestArray(1): Two
//TestArray(2): Three
//TestExpand: My path: %path%
//TestExpand2: My path: D:\Program Files\Microsoft.NET\...
//
//Use the registry editor to examine the key.
//Press the Enter key to delete the key.
//</Snippet1>


