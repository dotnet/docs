' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomTableAddAttributesToRender
        Inherits System.Web.UI.WebControls.Table

        Protected Overrides Sub AddAttributesToRender(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Add a client-side onclick event to the button.
            writer.AddAttribute(System.Web.UI.HtmlTextWriterAttribute.Onclick, "alert('Hello World');")

            ' Call the base's AddAttributesToRender method.
            MyBase.AddAttributesToRender(writer)
        End Sub
    End Class
End Namespace
' </Snippet2>
