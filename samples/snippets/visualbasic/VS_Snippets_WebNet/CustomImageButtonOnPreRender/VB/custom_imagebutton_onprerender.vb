Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class CustomImageButtonOnPreRender
        Inherits ImageButton

        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)

            ' Run the OnPreRender method on the base class.
            MyBase.OnPreRender(e)

            ' Always display the ImageButton with a thin border.
            Me.BorderWidth = Unit.Point(1)
        End Sub
    End Class
    ' </Snippet2>
End Namespace