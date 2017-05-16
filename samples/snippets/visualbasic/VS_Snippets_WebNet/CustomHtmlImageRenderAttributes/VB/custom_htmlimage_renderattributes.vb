' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls

    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlImageRenderAttributes
        Inherits System.Web.UI.HtmlControls.HtmlImage

        Protected Overrides Sub RenderAttributes(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Call the base class's RenderAttributes method.
            MyBase.RenderAttributes(writer)

            ' Write out the HtmlImage control's alt tag.
            writer.Write(" alt=""Text from custom RenderAttributes method.""")
        End Sub
    End Class

End Namespace
' </Snippet2>
