' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomTableCellAddAttributesToRender
        Inherits System.Web.UI.WebControls.TableCell

        Protected Overrides Sub AddAttributesToRender(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Write a Title attribute.
            writer.AddAttribute("title", "CustomAddAttributesToRender")

            ' Call the base AddAttributesToRender method.
            MyBase.AddAttributesToRender(writer)
        End Sub
    End Class
End Namespace
' </Snippet2>
