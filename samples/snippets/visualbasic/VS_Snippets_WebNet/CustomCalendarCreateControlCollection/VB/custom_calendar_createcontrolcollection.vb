' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomCalendarCreateControlCollection
        Inherits System.Web.UI.WebControls.Calendar

        Protected Overrides Function CreateControlCollection() As System.Web.UI.ControlCollection
            ' Return a new EmptyControlCollection
            Return New System.Web.UI.EmptyControlCollection(Me)
        End Function
    End Class
End Namespace
' </Snippet2>