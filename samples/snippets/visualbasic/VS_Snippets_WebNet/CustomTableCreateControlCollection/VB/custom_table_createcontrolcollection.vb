' <Snippet2>
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class CustomTableCreateControlCollection
        Inherits Table

        Protected Overrides Function CreateControlCollection() As ControlCollection
            ' Return a new ControlCollection
            Return New ControlCollection(Me)
        End Function
    End Class
End Namespace
' </Snippet2>
