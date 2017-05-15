Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomLinkButtonOnPreRender
        Inherits System.Web.UI.WebControls.LinkButton

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)

            ' Run the OnPreRender method on the base class.
            MyBase.OnPreRender(e)

            ' Always display the LinkButton without a border.
            Me.BorderWidth = System.Web.UI.WebControls.Unit.Point(0)
        End Sub
    End Class
    ' </Snippet2>
End Namespace