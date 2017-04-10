' Created by REDMOND\glennha
'<Snippet1>
Option Explicit
Imports System
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports System.Security
Imports Microsoft.Win32

Public Class Example

    Public Shared Sub Main()

        Const TestKey As String = "TestKey3927"
        Dim cu As RegistryKey = Registry.CurrentUser

        Dim user As String = Environment.UserDomainName _ 
            & "\" & Environment.UserName

        ' Create a security object that grants no access.
        Dim mSec As New RegistrySecurity()

        ' Add a rule that grants the current user the right
        ' to read and enumerate the name/value pairs in a key, 
        ' to read its access and audit rules, to enumerate
        ' its subkeys, to create subkeys, and to delete the key. 
        ' The rule is inherited by all contained subkeys.
        '
        Dim rule As New RegistryAccessRule(user, _
            RegistryRights.ReadKey Or RegistryRights.WriteKey _
                Or RegistryRights.Delete, _
            InheritanceFlags.ContainerInherit, _
            PropagationFlags.None, _
            AccessControlType.Allow)
        mSec.AddAccessRule(rule)

        ' Add a rule that allows the current user the right
        ' right to set the name/value pairs in a key. 
        ' This rule is inherited by contained subkeys, but
        ' propagation flags limit it to immediate child 
        ' subkeys.
        rule = New RegistryAccessRule(user, _
            RegistryRights.ChangePermissions, _
            InheritanceFlags.ContainerInherit, _
            PropagationFlags.InheritOnly Or PropagationFlags.NoPropagateInherit, _
            AccessControlType.Allow)
        mSec.AddAccessRule(rule)

        ' Display the rules in the security object.
        ShowSecurity(mSec)

        ' Create the test key using the security object.
        '
        Dim rk As RegistryKey = cu.CreateSubKey(TestKey, _
            RegistryKeyPermissionCheck.ReadWriteSubTree, _
            mSec)

        ' Create a child subkey and a grandchild subkey, 
        ' without security.
        Dim rkChild As RegistryKey= rk.CreateSubKey("ChildKey", _
            RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim rkGrandChild As RegistryKey = _
            rkChild.CreateSubKey("GrandChildKey", _
                RegistryKeyPermissionCheck.ReadWriteSubTree)

        Show(rk)
        Show(rkChild)
        Show(rkGrandChild)

        rkGrandChild.Close()
        rkChild.Close()
        rk.Close()

        cu.DeleteSubKeyTree(TestKey)
    End Sub 

    Private Shared Sub Show(ByVal rk As RegistryKey)
        Console.WriteLine(rk.Name)            
        ShowSecurity(rk.GetAccessControl())
    End Sub

    Private Shared Sub ShowSecurity(ByVal security As RegistrySecurity)
        Console.WriteLine(vbCrLf & "Current access rules:" & vbCrLf)

        For Each ar As RegistryAccessRule In _
            security.GetAccessRules(True, True, GetType(NTAccount))

            Console.WriteLine("        User: {0}", ar.IdentityReference)
            Console.WriteLine("        Type: {0}", ar.AccessControlType)
            Console.WriteLine("      Rights: {0}", ar.RegistryRights)
            Console.WriteLine(" Inheritance: {0}", ar.InheritanceFlags)
            Console.WriteLine(" Propagation: {0}", ar.PropagationFlags)
            Console.WriteLine("   Inherited? {0}", ar.IsInherited)
            Console.WriteLine()
        Next

    End Sub
End Class 

'This code example produces output similar to following:
'
'Current access rules:
'
'        User: TestDomain\TestUser
'        Type: Allow
'      Rights: SetValue, CreateSubKey, Delete, ReadKey
' Inheritance: ContainerInherit
' Propagation: None
'   Inherited? False
'
'        User: TestDomain\TestUser
'        Type: Allow
'      Rights: ChangePermissions
' Inheritance: ContainerInherit
' Propagation: NoPropagateInherit, InheritOnly
'   Inherited? False
'
'HKEY_CURRENT_USER\TestKey3927
'
'Current access rules:
'
'        User: TestDomain\TestUser
'        Type: Allow
'      Rights: SetValue, CreateSubKey, Delete, ReadKey
' Inheritance: ContainerInherit
' Propagation: None
'   Inherited? False
'
'        User: TestDomain\TestUser
'        Type: Allow
'      Rights: ChangePermissions
' Inheritance: ContainerInherit
' Propagation: NoPropagateInherit, InheritOnly
'   Inherited? False
'
'HKEY_CURRENT_USER\TestKey3927\ChildKey
'
'Current access rules:
'
'        User: TestDomain\TestUser
'        Type: Allow
'      Rights: SetValue, CreateSubKey, Delete, ReadKey
' Inheritance: ContainerInherit
' Propagation: None
'   Inherited? True
'
'        User: TestDomain\TestUser
'        Type: Allow
'      Rights: ChangePermissions
' Inheritance: None
' Propagation: None
'   Inherited? True
'
'HKEY_CURRENT_USER\TestKey3927\ChildKey\GrandChildKey
'
'Current access rules:
'
'        User: TestDomain\TestUser
'        Type: Allow
'      Rights: SetValue, CreateSubKey, Delete, ReadKey
' Inheritance: ContainerInherit
' Propagation: None
'   Inherited? True
'</Snippet1>
