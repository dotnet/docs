'<Snippet1>
Imports System
Imports System.Security.Permissions

Namespace SecurityLibrary

    <EnvironmentPermission(SecurityAction.LinkDemand, Read:="PATH")> _
    Public Class TypesWithLinkDemands
    
        Protected Overridable Sub UnsecuredMethod()
        End Sub

        <EnvironmentPermission(SecurityAction.InheritanceDemand, Read:="PATH")> _
        Protected Overridable Sub SecuredMethod()
        End Sub
        
    End Class
    
End Namespace
'</Snippet1>
