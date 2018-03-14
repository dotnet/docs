' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomRepeaterCreateItem
        Inherits System.Web.UI.WebControls.Repeater

        Protected Overrides Function CreateItem(ByVal itemIndex As Integer, ByVal itemType As System.Web.UI.WebControls.ListItemType) As System.Web.UI.WebControls.RepeaterItem

            ' Return a new RepeaterItem with the corresponding item index and type.
            Return New System.Web.UI.WebControls.RepeaterItem(itemIndex, itemType)
        End Function
    End Class
End Namespace
' </Snippet2>
