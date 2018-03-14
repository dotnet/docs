Imports System
Imports System.Security
Imports System.Security.Policy
Imports System.Security.Permissions



Public Class Sample
    
    Sub Method()
        Dim codeGroup As New FirstMatchCodeGroup(Nothing, New PolicyStatement(New PermissionSet(PermissionState.None)))
        ' <Snippet1>
        codeGroup.PolicyStatement = New PolicyStatement(New NamedPermissionSet("MyPermissionSet"))
        ' </Snippet1>
    End Sub 'Method 
End Class 'Sample
