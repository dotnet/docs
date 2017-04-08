' <Snippet2>
Imports System
Imports System.Web
IMports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class CustomCheckBoxListOnPreRender
        Inherits System.Web.UI.WebControls.CheckBoxList

        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)

            ' Run the OnPreRender method on the base class.
            MyBase.OnPreRender(e)

            ' Display the CheckBoxList with a 3 point border.
            Me.BorderWidth = Unit.Point(3)
        End Sub
    End Class
End Namespace
' </Snippet2>
