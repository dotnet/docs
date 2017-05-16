' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomDataListCreateControlStyle
        Inherits System.Web.UI.WebControls.DataList

        Protected Overrides Function CreateControlStyle() As System.Web.UI.WebControls.Style

            ' Create a new TableStyle instance based on ViewState values.
            Dim style As New System.Web.UI.WebControls.TableStyle(ViewState)

            ' Show the GridLines horizontal with no CellSpacing.
            style.GridLines = System.Web.UI.WebControls.GridLines.Horizontal
            style.CellSpacing = 0

            ' Return the Style
            Return style
        End Function
    End Class
End Namespace
' </Snippet2>