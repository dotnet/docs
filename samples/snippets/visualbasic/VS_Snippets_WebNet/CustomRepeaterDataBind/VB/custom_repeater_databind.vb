' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomRepeaterDataBind
        Inherits System.Web.UI.WebControls.Repeater

        Public Overrides Sub DataBind()

            ' Raise the DataBinding event.
            Me.OnDataBinding(System.EventArgs.Empty)
        End Sub
    End Class
End Namespace
' </Snippet2>
