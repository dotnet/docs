using System;
using Microsoft.Win32;

public class GetUpdateHistory
{
    public static void Main()
    {
        using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\Updates"))
        {
            foreach (string baseKeyName in baseKey.GetSubKeyNames())
            {
                if (baseKeyName.Contains(".NET Framework"))
                {
                    using (RegistryKey updateKey = baseKey.OpenSubKey(baseKeyName))
                    {
                        Console.WriteLine(baseKeyName);
                        foreach (string kbKeyName in updateKey.GetSubKeyNames())
                        {
                            using (RegistryKey kbKey = updateKey.OpenSubKey(kbKeyName))
                            {
                                Console.WriteLine("  " + kbKeyName);
                            }
                        }
                    }
                }
            }
        }
    }
}