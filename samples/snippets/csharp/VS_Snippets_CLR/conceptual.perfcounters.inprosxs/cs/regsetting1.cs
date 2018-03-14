using System;

public class Class1
{
   public static void Main()
   {
      // <Snippet1>
      // Create or open registry key.
      Microsoft.Win32.RegistryKey key; 
      key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey( 
                @"System\CurrentControlSet\Services\.NETFramework\Performance");
      // Create or overwrite value.
      key.SetValue("ProcessNameFormat", 1, 
                   Microsoft.Win32.RegistryValueKind.DWord);
      key.Close();
      // </Snippet1>
   }
}
