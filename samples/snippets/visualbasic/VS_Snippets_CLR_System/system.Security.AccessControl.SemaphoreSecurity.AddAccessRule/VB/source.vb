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
        Dim mSec As New SemaphoreSecurity()

        ' Add a rule that grants the current user the 
        ' right to enter or release the semaphore.
        Dim rule As New SemaphoreAccessRule(user, _
            SemaphoreRights.Synchronize _
            Or SemaphoreRights.Modify, _
            AccessControlType.Allow)
        mSec.AddAccessRule(rule)

        ' Add a rule that denies the current user the 
        ' right to change permissions on the semaphore.
        rule = New SemaphoreAccessRule(user, _
            SemaphoreRights.ChangePermissions, _
            AccessControlType.Deny)
        mSec.AddAccessRule(rule)

        ' Display the rules in the security object.
        ShowSecurity(mSec)

        ' Add a rule that allows the current user the 
        ' right to read permissions on the semaphore. This 
        ' rule is merged with the existing Allow rule.
        rule = New SemaphoreAccessRule(user, _
            SemaphoreRights.ReadPermissions, _
            AccessControlType.Allow)
        mSec.AddAccessRule(rule)

        ShowSecurity(mSec)

    End Sub 

    Private Shared Sub ShowSecurity(ByVal security As SemaphoreSecurity)
        Console.WriteLine(vbCrLf & "Current access rules:" & vbCrLf)

        For Each ar As SemaphoreAccessRule In _
            security.GetAccessRules(True, True, GetType(NTAccount))

            Console.WriteLine("        User: {0}", ar.IdentityReference)
            Console.WriteLine("        Type: {0}", ar.AccessControlType)
            Console.WriteLine("      Rights: {0}", ar.SemaphoreRights)
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
'      Rights: Modify, Synchronize
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
'      Rights: Modify, ReadPermissions, Synchronize
'</Snippet1>
