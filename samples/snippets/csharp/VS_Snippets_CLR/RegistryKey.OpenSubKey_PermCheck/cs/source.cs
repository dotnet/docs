//<Snippet1>
using System;
using Microsoft.Win32;
using System.Diagnostics;

public class Example
{
    public static void Main()
    {
        const int LIMIT = 100;
        RegistryKey cu = Registry.CurrentUser;
        const string testKey = "RegistryKeyPermissionCheckExample";

        Console.WriteLine("Generating {0} key/value pairs.", LIMIT);
        RegistryKey rk = cu.CreateSubKey(testKey);
        for (int i = 0; i < LIMIT; i++)
        {
            rk.SetValue("Key" + i, i);
        }

        rk.Close();

        Stopwatch s = new Stopwatch();

        // On the default setting, security is checked every time
        // a key/value pair is read.
        rk = cu.OpenSubKey(testKey, RegistryKeyPermissionCheck.Default);
        
        s.Start();
        for (int i = 0; i < LIMIT; i++)
        {
            rk.GetValue("Key" + i, i);
        }
        s.Stop();
        rk.Close();
        long delta1 = s.ElapsedTicks;

        s.Reset();

        // When the key is opened with ReadSubTree, security is 
        // not checked when the values are read.
        rk = cu.OpenSubKey(testKey, RegistryKeyPermissionCheck.ReadSubTree);
        
        s.Start();
        for (int i = 0; i < LIMIT; i++)
        {
            rk.GetValue("Key" + i, i);
        }
        s.Stop();
        rk.Close();
        long delta2 = s.ElapsedTicks;

        double faster = (double) (delta1 - delta2) / (double) delta1;
        Console.WriteLine("ReadSubTree is {0}% faster for {1} values.",
            (faster * 100).ToString("0.0"), LIMIT);

        cu.DeleteSubKey(testKey);
    }
}

/* This code example produces output similar to the following:

Generating 100 key/value pairs.
ReadSubTree is 23.4% faster for 100 values.
 */
//</Snippet1>