using Microsoft.Win32;
using System;

public static class VersionTest
{
    public static void Main()
    {
        GetVersionFromRegistry();
    }
    
    private static void GetVersionFromRegistry()
    {
         // Opens the registry key for the .NET Framework entry.
            using (RegistryKey ndpKey = 
                RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "").
                OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                // As an alternative, if you know the computers you will query are running .NET Framework 4.5 
                // or later, you can use:
                // using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
                // RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            foreach (string versionKeyName in ndpKey.GetSubKeyNames())
            {
                if (versionKeyName.StartsWith("v"))
                {

                    RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                    string name = (string)versionKey.GetValue("Version", "");
                    string sp = versionKey.GetValue("SP", "").ToString();
                    string install = versionKey.GetValue("Install", "").ToString();
                    if (install == "") //no install info, must be later.
                        Console.WriteLine(versionKeyName + "  " + name);
                    else
                    {
                        if (sp != "" && install == "1")
                        {
                            Console.WriteLine(versionKeyName + "  " + name + "  SP" + sp);
                        }

                    }
                    if (name != "")
                    {
                        continue;
                    }
                    foreach (string subKeyName in versionKey.GetSubKeyNames())
                    {
                        RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                        name = (string)subKey.GetValue("Version", "");
                        if (name != "")
                            sp = subKey.GetValue("SP", "").ToString();
                        install = subKey.GetValue("Install", "").ToString();
                        if (install == "") //no install info, must be later.
                            Console.WriteLine(versionKeyName + "  " + name);
                        else
                        {
                            if (sp != "" && install == "1")
                            {
                                Console.WriteLine("  " + subKeyName + "  " + name + "  SP" + sp);
                            }
                            else if (install == "1")
                            {
                                Console.WriteLine("  " + subKeyName + "  " + name);
                            }
                        }
                    }
                }
            }
        }
    }
}