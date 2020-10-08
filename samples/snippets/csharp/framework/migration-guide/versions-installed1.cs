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
        // Open the registry key for the .NET Framework entry.
        using RegistryKey ndpKey =
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).
                OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\");

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
}

// The example displays output similar to the following:
//        v2.0.50727  2.0.50727.4927  SP2
//        v3.0  3.0.30729.4926  SP2
//        v3.5  3.5.30729.4926  SP1
//        v4.0
//           Client  4.0.0.0
