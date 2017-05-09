'<Snippet1>
Imports System.Threading
Imports System.Security.Permissions

<SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.ControlThread)> _
Friend Class MyUtility
    <SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.ControlThread)> _
    Public Sub PerformTask() 
        ' Code that does not have thread affinity goes here.
        '
        Thread.BeginThreadAffinity()
        '
        ' Code that has thread affinity goes here.
        '
        Thread.EndThreadAffinity()
        '
        ' More code that does not have thread affinity.
    End Sub 'PerformTask
End Class 'MyUtility 
'</Snippet1>

Public Class Dummy    
    Public Shared Sub Main() 
    End Sub 'Main
End Class 'Dummy