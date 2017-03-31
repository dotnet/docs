//<Snippet1>
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
                if (baseKeyName.Contains(".NET Framework") || baseKeyName.StartsWith("KB") || baseKeyName.Contains(".NETFramework"))
                {

                    using (RegistryKey updateKey = baseKey.OpenSubKey(baseKeyName))
                    {
                        string name = (string)updateKey.GetValue("PackageName", "");
                        Console.WriteLine(baseKeyName + "  " + name);
                        foreach (string kbKeyName in updateKey.GetSubKeyNames())
                        {
                            using (RegistryKey kbKey = updateKey.OpenSubKey(kbKeyName))
                            {
                                name = (string)kbKey.GetValue("PackageName", "");
                                Console.WriteLine("  " + kbKeyName + "  " + name);

                                if (kbKey.SubKeyCount > 0)
                                {
                                    foreach (string sbKeyName in kbKey.GetSubKeyNames())
                                    {
                                        using (RegistryKey sbSubKey = kbKey.OpenSubKey(sbKeyName))
                                        {
                                            name = (string)sbSubKey.GetValue("PackageName", "");
                                            if (name == "")
                                                name = (string)sbSubKey.GetValue("Description", "");
                                            Console.WriteLine("    " + sbKeyName + "  " + name);

                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }
    }
}
//</Snippet1>
