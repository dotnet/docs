Imports System
Imports System.Security
Imports System.Security.Policy
Imports System.Security.Permissions

Public Class PrincipalPermTest
    Public Shared Sub Main()
        Dummy1()
    End Sub

    Private Shared Sub Dummy1()
    ' <Snippet1>
        Dim ppBob As New PrincipalPermission("Bob", "Administrator")
        Dim ppLouise As New PrincipalPermission("Louise", "Administrator")
        Dim pp1 As IPermission = ppBob.Intersect(ppLouise)
    ' </Snippet1>
    End Sub

    Private Shared Sub Dummy2()
        ' <Snippet2>
         Dim pp1 As IPermission = New PrincipalPermission("", "Administrator")
        ' </Snippet2>
    End Sub

    Private Shared Sub Dummy3()
        ' <Snippet3>
        Dim ppBob As New PrincipalPermission("Bob", "Administrator")
        Dim ppLouise As New PrincipalPermission("Louise", "Administrator")
        ' </Snippet3>
    End Sub
End Class

