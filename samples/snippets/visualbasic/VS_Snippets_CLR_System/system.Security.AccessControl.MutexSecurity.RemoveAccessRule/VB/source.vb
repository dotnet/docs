'<Snippet1>
Imports System
Imports System.Threading
Imports System.Security.AccessControl
Imports System.Security.Principal

Public Class Example

    Public Shared Sub Main()

        ' Create a string representing the current user.
        Dim user As String = Environment.UserDomainName _ 
            & "\" & Environment.UserName

        ' Create a security object that grants no access.
        Dim mSec As New MutexSecurity()

        ' Add a rule that grants the current user the 
        ' right to enter or release the mutex, and to 
        ' read its permissions.
        Dim rule As New MutexAccessRule(user, _
            MutexRights.Synchronize _
            Or MutexRights.Modify _
            Or MutexRights.ReadPermissions, _
            AccessControlType.Allow)
        mSec.AddAccessRule(rule)

        ' Add a rule that denies the current user the 
        ' right to change permissions on the mutex.
        rule = New MutexAccessRule(user, _
            MutexRights.ChangePermissions, _
            AccessControlType.Deny)
        mSec.AddAccessRule(rule)

        ' Display the rules in the security object.
        ShowSecurity(mSec)

        ' Create a rule that grants the current user 
        ' the right to read permissions on the mutex, and
        ' take ownership of the mutex. Use this rule to 
        ' remove the right to read permissions from the 
        ' Allow rule for the current user. The inclusion 
        ' of the right to take ownership has no effect.
        rule = New MutexAccessRule(user, _
            MutexRights.TakeOwnership _
            Or MutexRights.ReadPermissions, _
            AccessControlType.Allow)
        mSec.RemoveAccessRule(rule)

        ShowSecurity(mSec)
        
    End Sub 

    Private Shared Sub ShowSecurity(ByVal security As MutexSecurity)
        Console.WriteLine(vbCrLf & "Current access rules:" & vbCrLf)

        For Each ar As MutexAccessRule In _
            security.GetAccessRules(True, True, GetType(NTAccount))

            Console.WriteLine("        User: {0}", ar.IdentityReference)
            Console.WriteLine("        Type: {0}", ar.AccessControlType)
            Console.WriteLine("      Rights: {0}", ar.MutexRights)
            Console.WriteLine()
        Next

    End Sub
End Class 

'This code example produces output similar to following:
'
'Current access rules:
'
'        User: TestDomain\TestUser
'        Type: Deny
'      Rights: ChangePermissions
'
'        User: TestDomain\TestUser
'        Type: Allow
'      Rights: Modify, ReadPermissions, Synchronize
'
'
'Current access rules:
'
'        User: TestDomain\TestUser
'        Type: Deny
'      Rights: ChangePermissions
'
'        User: TestDomain\TestUser
'        Type: Allow
'      Rights: Modify, Synchronize
'</Snippet1>
