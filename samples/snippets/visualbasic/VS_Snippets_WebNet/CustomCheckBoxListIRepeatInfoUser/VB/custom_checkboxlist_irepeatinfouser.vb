' <Snippet2>
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls

    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class CustomCheckBoxListIRepeatInfoUser
        Inherits CheckBoxList

        Private _hasFooter As Boolean
        Private _hasHeader As Boolean
        Private _hasSeparators As Boolean
        Private _repeatedItemCount As Integer
        Private _itemStyleItem As Style

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)
            ' Call the base class's OnPreRender method
            MyBase.OnPreRender(e)

            ' Get a self-referencing IRepeatInfoUser object
            Dim repeatInfoUser As IRepeatInfoUser
            repeatInfoUser = CType(Me, IRepeatInfoUser)

            ' Get the IRepeatInfoUser member values.
            _hasFooter = repeatInfoUser.HasFooter
            _hasHeader = repeatInfoUser.HasHeader
            _hasSeparators = repeatInfoUser.HasSeparators
            _repeatedItemCount = repeatInfoUser.RepeatedItemCount
            _itemStyleItem = repeatInfoUser.GetItemStyle(ListItemType.Item, 0)
        End Sub

        Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
            ' Create and setup a RepeatInfo class.
            Dim repeatInfo As New RepeatInfo
            repeatInfo.RepeatColumns = 0
            repeatInfo.RepeatDirection = RepeatDirection.Horizontal
            repeatInfo.RepeatLayout = RepeatLayout.Table

            ' Get a self-referencing IRepeatInfoUser object
            Dim repeatInfoUser As IRepeatInfoUser
            repeatInfoUser = CType(Me, IRepeatInfoUser)

            ' Render the items using the above RepeatInfo and IRepeatInfoUser classes.
            repeatInfoUser.RenderItem(ListItemType.Item, 0, repeatInfo, writer)
            repeatInfoUser.RenderItem(ListItemType.Item, 1, repeatInfo, writer)
            repeatInfoUser.RenderItem(ListItemType.Item, 2, repeatInfo, writer)
            repeatInfoUser.RenderItem(ListItemType.Item, 3, repeatInfo, writer)
            repeatInfoUser.RenderItem(ListItemType.Item, 4, repeatInfo, writer)
            repeatInfoUser.RenderItem(ListItemType.Item, 5, repeatInfo, writer)
        End Sub
    End Class

End Namespace
' </Snippet2>
