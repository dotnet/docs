Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls

    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class CustomADRotatorOnPreRender
        Inherits System.Web.UI.WebControls.AdRotator

' <Snippet2>
        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)
            ' Run the OnPreRender method on the base class.
            MyBase.OnPreRender(e)

            ' Always display the Ad with a border.
            Me.BorderWidth = System.Web.UI.WebControls.Unit.Point(1)
        End Sub
' </Snippet2>

    End Class
End Namespace ' Samples.AspNet