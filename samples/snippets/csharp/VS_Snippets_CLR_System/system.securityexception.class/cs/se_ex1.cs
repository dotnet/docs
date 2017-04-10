// <Snippet1>
using Microsoft.Win32;
using System;
using System.Security;
using System.Security.Permissions;

public class Example
{
   public static void Main()
   {
      PermissionSet perms = new PermissionSet(null);
      perms.AddPermission(new UIPermission(PermissionState.Unrestricted));
      perms.AddPermission(new RegistryPermission(PermissionState.None));
      perms.PermitOnly();
      
      try {
          RegistryKey key = Registry.CurrentUser.CreateSubKey("MyCompany\\Applications");
          Console.WriteLine("Registry key: {0}", key.Name);
      }
      catch (SecurityException e) {
         Console.WriteLine("Security Exception:\n\n{0}", e.Message);      
      }
   }
}
// The example displays the following output:
//    Security Exception:
//    
//    Request for the permission of type 'System.Security.Permissions.RegistryPermission, 
//    mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089' failed.
// </Snippet1>