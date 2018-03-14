' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomTableCellRenderContents
        Inherits System.Web.UI.WebControls.TableCell

        Protected Overrides Sub RenderContents(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Insert text into each TableCell.
            writer.Write("TableCell: ")

            ' Call the base RenderContents method.
            MyBase.RenderContents(writer)

        End Sub

    End Class

End Namespace
' </Snippet2>
