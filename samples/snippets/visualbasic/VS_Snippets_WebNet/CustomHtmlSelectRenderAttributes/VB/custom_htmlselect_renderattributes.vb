Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlSelectRenderAttributes
        Inherits System.Web.UI.HtmlControls.HtmlSelect

        Protected Overrides Sub RenderAttributes(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Write out Title tag
            writer.Write(" Title=""Text from RenderAttributes.""")

            ' Call the base's RenderAttributes method.
            MyBase.RenderAttributes(writer)
        End Sub
    End Class
    ' </Snippet2>
End Namespace