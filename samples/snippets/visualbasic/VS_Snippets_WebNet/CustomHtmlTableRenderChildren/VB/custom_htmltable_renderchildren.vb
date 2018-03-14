' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlTableRenderChildren
        Inherits System.Web.UI.HtmlControls.HtmlTable

        Protected Overrides Sub RenderChildren(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Call the base class's RenderChildren method.
            MyBase.RenderChildren(writer)

            ' Write out a new table row.
            writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Tr)
            writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Td)
            writer.Write("4,1")
            writer.RenderEndTag()
            writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Td)
            writer.Write("4,2")
            writer.RenderEndTag()
            writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Td)
            writer.Write("4,3")
            writer.RenderEndTag()
            writer.RenderEndTag()
        End Sub
    End Class
End Namespace
' </Snippet2>
