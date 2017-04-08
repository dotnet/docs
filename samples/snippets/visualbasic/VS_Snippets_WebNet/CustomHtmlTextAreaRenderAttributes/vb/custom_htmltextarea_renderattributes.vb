' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlTextAreaRenderAttributes
        Inherits System.Web.UI.HtmlControls.HtmlTextArea

        Protected Overrides Sub RenderAttributes(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Write out the Title attribute.
            writer.Write(" Title=""Text from RenderAttributes.""")

            ' Call the base class's RenderAttributes method.
            MyBase.RenderAttributes(writer)
        End Sub
    End Class
End Namespace
' </Snippet2>
