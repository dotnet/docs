' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports Microsoft.Win32
Imports System.Security
Imports System.Security.Permissions

Module Example
   Public Sub Main()
      Dim perms As New PermissionSet(CType(Nothing, PermissionSet))
      perms.AddPermission(New UIPermission(PermissionState.Unrestricted))
      perms.AddPermission(New RegistryPermission(PermissionState.None))
      perms.PermitOnly()
      
      Try 
          Dim key As RegistryKey = Registry.CurrentUser.CreateSubKey("MyCompany\\Applications")
          Console.WriteLine("Registry key: {0}", key.Name)
      Catch e As SecurityException
         Console.WriteLine("Security Exception:\n\n{0}", e.Message)      
      End Try
   End Sub
End Module
' The example displays the following output:
'    Security Exception:
'    
'    Request for the permission of type 'System.Security.Permissions.RegistryPermission, 
'    mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089' failed.
' </Snippet1>

