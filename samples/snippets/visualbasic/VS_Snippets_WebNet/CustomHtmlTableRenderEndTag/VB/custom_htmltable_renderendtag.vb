' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlTableRenderEndTag
        Inherits System.Web.UI.HtmlControls.HtmlTable

        Protected Overrides Sub RenderEndTag(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Write out the current TagName.
            writer.WriteEndTag(Me.TagName)

            ' Write out a new line.
            writer.WriteLine()
        End Sub
    End Class
End Namespace
' </Snippet2>
