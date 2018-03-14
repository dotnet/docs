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

        Dim user As String = Environment.UserDomainName _ 
            & "\" & Environment.UserName

        ' Create a security object that grants no access.
        Dim mSec As New RegistrySecurity()

        ' Add a rule that grants the current user ReadKey
        ' rights. ReadKey is a combination of four other 
        ' rights. The rule is inherited by all 
        ' contained subkeys.
        Dim rule As New RegistryAccessRule(user, _
            RegistryRights.ReadKey, _
            InheritanceFlags.ContainerInherit, _
            PropagationFlags.None, _
            AccessControlType.Allow)
        mSec.AddAccessRule(rule)

        ' Create a rule that allows the current user only the 
        ' right to query the key/value pairs of a key, using  
        ' the same inheritance and propagation flags as the
        ' first rule. QueryValues is a constituent of 
        ' ReadKey, so when this rule is removed, using the 
        ' RemoveAccessRule method, ReadKey is broken into
        ' its constituent parts.
        rule = New RegistryAccessRule(user, _
            RegistryRights.QueryValues, _
            InheritanceFlags.ContainerInherit, _
            PropagationFlags.None, _
            AccessControlType.Allow)
        mSec.RemoveAccessRule(rule)

        ' Display the rules in the security object.
        ShowSecurity(mSec)

        ' Add the second rule back. It merges with the 
        ' existing rule, so that the rule is now displayed
        ' as ReadKey.
        mSec.AddAccessRule(rule)

        ' Display the rules in the security object.
        ShowSecurity(mSec)

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
'      Rights: EnumerateSubKeys, Notify, ReadPermissions
' Inheritance: ContainerInherit
' Propagation: None
'   Inherited? False
'
'
'Current access rules:
'
'        User: TestDomain\TestUser
'        Type: Allow
'      Rights: ReadKey
' Inheritance: ContainerInherit
' Propagation: None
'   Inherited? False
'
'</Snippet1>
