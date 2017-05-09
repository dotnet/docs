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
        ' right to enter or release the mutex.
        Dim ruleA As New MutexAccessRule(user, _
            MutexRights.Synchronize _
            Or MutexRights.Modify, _
            AccessControlType.Allow)
        mSec.AddAccessRule(ruleA)

        ' Add a rule that denies the current user the 
        ' right to change permissions on the mutex.
        Dim rule As New MutexAccessRule(user, _
            MutexRights.ChangePermissions, _
            AccessControlType.Deny)
        mSec.AddAccessRule(rule)

        ' Display the rules in the security object.
        ShowSecurity(mSec)

        ' Add a rule that allows the current user the 
        ' right to read permissions on the mutex. This rule
        ' is merged with the existing Allow rule.
        rule = New MutexAccessRule(user, _
            MutexRights.ReadPermissions, _
            AccessControlType.Allow)
        mSec.AddAccessRule(rule)

        ShowSecurity(mSec)

        ' Attempt to remove the original rule (granting
        ' the right to enter or release the mutex) with 
        ' RemoveAccessRuleSpecific. The removal fails,
        ' because the right to read the permissions on the 
        ' mutex has been added to the rule, so that it no 
        ' longer matches the original rule.
        Console.WriteLine("Attempt to use RemoveAccessRuleSpecific on the original rule.")
        mSec.RemoveAccessRuleSpecific(ruleA)

        ShowSecurity(mSec)

        ' Create a rule that grants the current user 
        ' the right to enter or release the mutex, and
        ' to read permissions. Use this rule to remove
        ' the Allow rule for the current user.
        Console.WriteLine("Use RemoveAccessRuleSpecific with the correct rights.")
        rule = New MutexAccessRule(user, _
            MutexRights.Synchronize _
            Or MutexRights.Modify _
            Or MutexRights.ReadPermissions, _
            AccessControlType.Allow)
        mSec.RemoveAccessRuleSpecific(rule)

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
'
'Attempt to use RemoveAccessRuleSpecific on the original rule.
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
'Use RemoveAccessRuleSpecific with the correct rights.
'
'Current access rules:
'
'        User: TestDomain\TestUser
'        Type: Deny
'      Rights: ChangePermissions
'</Snippet1>
