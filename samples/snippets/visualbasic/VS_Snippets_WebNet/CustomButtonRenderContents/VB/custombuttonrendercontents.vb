' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
<AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomButtonRenderContents
        Inherits System.Web.UI.WebControls.Button

        Protected Overrides Sub RenderContents(ByVal writer As System.Web.UI.HtmlTextWriter)
            MyBase.RenderContents(writer)

            ' Append some text after the button.
            writer.Write("<br>Click this button for more information.")
        End Sub
    End Class
End Namespace
' </Snippet2>