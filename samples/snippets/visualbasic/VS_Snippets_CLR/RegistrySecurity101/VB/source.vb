'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Security
Imports System.Security.AccessControl
Imports Microsoft.Win32

Public Class Example
    Public Shared Sub Main()
        ' Delete the example key if it exists.
        Try
            Registry.CurrentUser.DeleteSubKey("RegistryRightsExample")
            Console.WriteLine("Example key has been deleted.")
        Catch ex As ArgumentException
            ' ArgumentException is thrown if the key does not exist. In
            ' this case, there is no reason to display a message.
        Catch ex As Exception
            Console.WriteLine("Unable to delete the example key: {0}", ex)
            Return
        End Try

        Dim user As String = Environment.UserDomainName & "\" & Environment.UserName

        Dim rs As New RegistrySecurity()

        ' Allow the current user to read and delete the key.
        '
        rs.AddAccessRule(new RegistryAccessRule(user, _
            RegistryRights.ReadKey Or RegistryRights.Delete, _
            InheritanceFlags.None, _
            PropagationFlags.None, _
            AccessControlType.Allow))

        ' Prevent the current user from writing or changing the
        ' permission set of the key. Note that if Delete permission
        ' were not allowed in the previous access rule, denying
        ' WriteKey permission would prevent the user from deleting the 
        ' key.
        rs.AddAccessRule(new RegistryAccessRule(user, _
            RegistryRights.WriteKey Or RegistryRights.ChangePermissions, _
            InheritanceFlags.None, _
            PropagationFlags.None, _
            AccessControlType.Deny))

        ' Create the example key with registry security.
        Dim rk As RegistryKey = Nothing
        Try
            rk = Registry.CurrentUser.CreateSubKey("RegistryRightsExample", _
                RegistryKeyPermissionCheck.Default, rs)
            Console.WriteLine(vbCrLf & "Example key created.")
            rk.SetValue("ValueName", "StringValue")
        Catch ex As Exception
            Console.WriteLine(vbCrLf & "Unable to create the example key: {0}", ex)
        End Try

        If rk IsNot Nothing Then rk.Close()

        rk = Registry.CurrentUser

        Dim rk2 As RegistryKey
        
        ' Open the key with read access.
        rk2 = rk.OpenSubKey("RegistryRightsExample", False)
        Console.WriteLine(vbCrLf & "Retrieved value: {0}", rk2.GetValue("ValueName"))
        rk2.Close()

        ' Attempt to open the key with write access.
        Try
            rk2 = rk.OpenSubKey("RegistryRightsExample", True)
        Catch ex As SecurityException
            Console.WriteLine(vbCrLf & "Unable to write to the example key." _
                & " Caught SecurityException: {0}", ex.Message)
        End Try
        If rk2 IsNot Nothing Then rk2.Close()

        ' Attempt to change permissions for the key.
        Try
            rs = New RegistrySecurity()
            rs.AddAccessRule(new RegistryAccessRule(user, _
                RegistryRights.WriteKey, _
                InheritanceFlags.None, _
                PropagationFlags.None, _
                AccessControlType.Allow))
            rk2 = rk.OpenSubKey("RegistryRightsExample", False)
            rk2.SetAccessControl(rs)
            Console.WriteLine(vbCrLf & "Example key permissions were changed.")
        Catch ex As UnauthorizedAccessException
            Console.WriteLine(vbCrLf & "Unable to change permissions for the example key." _
                & " Caught UnauthorizedAccessException: {0}", ex.Message)
        End Try
        If rk2 IsNot Nothing Then rk2.Close()

        Console.WriteLine(vbCrLf & "Press Enter to delete the example key.")
        Console.ReadLine()

        Try
            rk.DeleteSubKey("RegistryRightsExample")
            Console.WriteLine("Example key was deleted.")
        Catch ex As Exception
            Console.WriteLine("Unable to delete the example key: {0}", ex)
        End Try

        rk.Close()
    End Sub
End Class

' This code produces the following output:
'
'Example key created.
'
'Retrieved value: StringValue
'
'Unable to write to the example key. Caught SecurityException: Requested registry access is not allowed.
'
'Unable to change permissions for the example key. Caught UnauthorizedAccessException: Cannot write to the registry key.
'
'Press Enter to delete the example key.
'
'Example key was deleted.
'</Snippet1>