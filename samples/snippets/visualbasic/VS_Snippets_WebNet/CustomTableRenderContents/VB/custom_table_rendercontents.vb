' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomTableRenderContents
        Inherits System.Web.UI.WebControls.Table

        Protected Overrides Sub RenderContents(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Insert a header row.
            writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Tr)
            writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Th)
            writer.Write("Col 0")
            writer.RenderEndTag()
            writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Th)
            writer.Write("Col 1")
            writer.RenderEndTag()
            writer.RenderEndTag()

            ' Call the base RenderContents method.
            MyBase.RenderContents(writer)
        End Sub
    End Class
End Namespace
' </Snippet2>
