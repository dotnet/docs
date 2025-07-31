using Microsoft.Win32;
using System.Runtime.Versioning;

[SupportedOSPlatform("windows")]
class Program
{
    static void Main()
    {
        if (!OperatingSystem.IsWindows())
        {
            Console.WriteLine("This example requires Windows operating system.");
            return;
        }

        // <CreateRegistryKey>
        // Create a registry key under HKEY_CURRENT_USER
        // This does not require administrator privileges
        RegistryKey userKey = Registry.CurrentUser.CreateSubKey("TestApp");
        
        // Set a value in the registry key
        userKey.SetValue("LastRun", DateTime.Now);
        userKey.SetValue("UserName", Environment.UserName);
        
        // Close the key
        userKey.Close();
        
        Console.WriteLine("Registry key created successfully under HKEY_CURRENT_USER\\TestApp");
        // </CreateRegistryKey>

        Console.WriteLine("\nPress any key to run the robust example...");
        Console.ReadKey();

        // <RobustRegistryAccess>
        try
        {
            // Open or create a registry key with error handling
            using (RegistryKey robustKey = Registry.CurrentUser.CreateSubKey("TestApp"))
            {
                if (robustKey != null)
                {
                    // Store application settings
                    robustKey.SetValue("ConfigVersion", "1.0");
                    robustKey.SetValue("EnableNotifications", true);
                    robustKey.SetValue("MaxRetries", 3);
                    
                    Console.WriteLine("Application settings saved to registry.");
                    
                    // Read back the values to verify
                    string? version = robustKey.GetValue("ConfigVersion") as string;
                    bool notifications = (bool)(robustKey.GetValue("EnableNotifications") ?? false);
                    int retries = (int)(robustKey.GetValue("MaxRetries") ?? 0);
                    
                    Console.WriteLine($"Config Version: {version}");
                    Console.WriteLine($"Notifications Enabled: {notifications}");
                    Console.WriteLine($"Max Retries: {retries}");
                }
                else
                {
                    Console.WriteLine("Failed to create or access registry key.");
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied. The application doesn't have permission to access this registry key.");
        }
        catch (System.Security.SecurityException)
        {
            Console.WriteLine("Security error. The application doesn't have permission to access the registry.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        // </RobustRegistryAccess>
        
        // Demonstrate the difference in permission requirements
        Console.WriteLine("\nTrying to access HKEY_LOCAL_MACHINE (may require admin privileges):");
        DemonstrateLocalMachineAccess();
    }
    
    [SupportedOSPlatform("windows")]
    static void DemonstrateLocalMachineAccess()
    {
        try
        {
            // This will likely fail without administrator privileges
            using (RegistryKey machineKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\TestApp"))
            {
                if (machineKey != null)
                {
                    machineKey.SetValue("SystemSetting", "value");
                    Console.WriteLine("Successfully wrote to HKEY_LOCAL_MACHINE");
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied to HKEY_LOCAL_MACHINE. Administrator privileges required.");
        }
        catch (System.Security.SecurityException)
        {
            Console.WriteLine("Security error accessing HKEY_LOCAL_MACHINE. Administrator privileges required.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error accessing HKEY_LOCAL_MACHINE: {ex.Message}");
        }
    }
}