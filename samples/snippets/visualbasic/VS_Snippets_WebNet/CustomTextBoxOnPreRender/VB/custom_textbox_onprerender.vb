' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomTextBoxOnPreRender
        Inherits System.Web.UI.WebControls.TextBox

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)

            ' Run the OnPreRender method on the base class.
            MyBase.OnPreRender(e)

            ' Display the TextBox with a 1 point border.
            Me.BorderWidth = System.Web.UI.WebControls.Unit.Point(1)
        End Sub
    End Class
End Namespace
' </Snippet2>
