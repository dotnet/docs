Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomImageAddAttributesToRender
        Inherits System.Web.UI.WebControls.Image

        Protected Overrides Sub AddAttributesToRender(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Show the Image with a thin border.
            writer.AddStyleAttribute("border-width", "thin")

            ' Call the Base's AddAttributesToRender method.
            MyBase.AddAttributesToRender(writer)
        End Sub
    End Class
    ' </Snippet2>
End Namespace