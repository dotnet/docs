 ' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class CustomCheckBoxOnPreRender
        Inherits System.Web.UI.WebControls.CheckBox

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)
            ' Run the OnPreRender method on the base class.
            MyBase.OnPreRender(e)

            ' Display a LightGray BackColor for the CheckBox.
            Me.BackColor = System.Drawing.Color.LightGray
        End Sub 'OnPreRender
    End Class 'CustomCheckBoxOnPreRender
End Namespace
' </Snippet2>