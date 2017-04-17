' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomDataListRenderContents
        Inherits System.Web.UI.WebControls.DataList

        Protected Overrides Sub RenderContents(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Place some text before the DataList.
            writer.Write("Here is some text from the RenderContent method.<br>")

            ' Call the base RenderContents method.
            MyBase.RenderContents(writer)
        End Sub
    End Class
End Namespace
' </Snippet2>