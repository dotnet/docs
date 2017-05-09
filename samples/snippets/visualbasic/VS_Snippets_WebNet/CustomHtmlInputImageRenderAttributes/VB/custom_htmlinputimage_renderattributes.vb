' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlInputImageRenderAttributes
        Inherits System.Web.UI.HtmlControls.HtmlInputImage

        Protected Overrides Sub RenderAttributes(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Add an Alt attribute to the the HtmlInputImage control.
            writer.Write(" alt='Alternate text from RenderAttributes'")

            ' Call the base class's RenderAttributes method.
            MyBase.RenderAttributes(writer)
        End Sub
    End Class
End Namespace
' </Snippet2>
