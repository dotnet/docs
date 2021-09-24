using Microsoft.Win32;
using System;

public static class VersionTest
{
    public static void Main()
    {
        GetVersionFromRegistry();
        Get45PlusFromRegistry();
    }

    private static void GetVersionFromRegistry()
    {
        //<snippet1>
        // Open the registry key for the .NET Framework entry.
        using (RegistryKey ndpKey =
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).
                OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
        {
            foreach (var versionKeyName in ndpKey.GetSubKeyNames())
            {
                // Skip .NET Framework 4.5 version information.
                if (versionKeyName == "v4")
                {
                    continue;
                }

                if (versionKeyName.StartsWith("v"))
                {
                    RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);

                    // Get the .NET Framework version value.
                    var name = (string)versionKey.GetValue("Version", "");
                    // Get the service pack (SP) number.
                    var sp = versionKey.GetValue("SP", "").ToString();

                    // Get the installation flag.
                    var install = versionKey.GetValue("Install", "").ToString();
                    if (string.IsNullOrEmpty(install))
                    {
                        // No install info; it must be in a child subkey.
                        Console.WriteLine($"{versionKeyName}  {name}");
                    }
                    else if (install == "1")
                    {
                        // Install = 1 means the version is installed.

                        if (!string.IsNullOrEmpty(sp))
                        {
                            Console.WriteLine($"{versionKeyName}  {name}  SP{sp}");
                        }
                        else
                        {
                            Console.WriteLine($"{versionKeyName}  {name}");
                        }
                    }

                    if (!string.IsNullOrEmpty(name))
                    {
                        continue;
                    }
                    // else print out info from subkeys...

                    // Iterate through the subkeys of the version subkey.
                    foreach (var subKeyName in versionKey.GetSubKeyNames())
                    {
                        RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                        name = (string)subKey.GetValue("Version", "");
                        if (!string.IsNullOrEmpty(name))
                            sp = subKey.GetValue("SP", "").ToString();

                        install = subKey.GetValue("Install", "").ToString();
                        if (string.IsNullOrEmpty(install))
                        {
                            // No install info; it must be later.
                            Console.WriteLine($"{versionKeyName}  {name}");
                        }
                        else if (install == "1")
                        {
                            if (!string.IsNullOrEmpty(sp))
                            {
                                Console.WriteLine($"{subKeyName}  {name}  SP{sp}");
                            }
                            else
                            {
                                Console.WriteLine($"  {subKeyName}  {name}");
                            }
                        }
                    }
                }
            }
        }
        //</snippet1>
    }

    private static void Get45PlusFromRegistry()
    {
        //<snippet2>
        const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

        using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
        {
            if (ndpKey != null && ndpKey.GetValue("Release") != null)
            {
                Console.WriteLine($".NET Framework Version: {CheckFor45PlusVersion((int)ndpKey.GetValue("Release"))}");
            }
            else
            {
                Console.WriteLine(".NET Framework Version 4.5 or later is not detected.");
            }
        }

        // Checking the version using >= enables forward compatibility.
        string CheckFor45PlusVersion(int releaseKey)
        {
            if (releaseKey >= 528040)
                return "4.8 or later";
            if (releaseKey >= 461808)
                return "4.7.2";
            if (releaseKey >= 461308)
                return "4.7.1";
            if (releaseKey >= 460798)
                return "4.7";
            if (releaseKey >= 394802)
                return "4.6.2";
            if (releaseKey >= 394254)
                return "4.6.1";
            if (releaseKey >= 393295)
                return "4.6";
            if (releaseKey >= 379893)
                return "4.5.2";
            if (releaseKey >= 378675)
                return "4.5.1";
            if (releaseKey >= 378389)
                return "4.5";
            // This code should never execute. A non-null release key should mean
            // that 4.5 or later is installed.
            return "No 4.5 or later version detected";
        }
        //</snippet2>
    }
}
