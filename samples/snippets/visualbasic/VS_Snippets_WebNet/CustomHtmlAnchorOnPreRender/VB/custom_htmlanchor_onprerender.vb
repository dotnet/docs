' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlAnchorOnPreRender
        Inherits System.Web.UI.HtmlControls.HtmlAnchor

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)

            ' Call the base OnPreRender method.
            MyBase.OnPreRender(e)

            ' Write out the HtmlAnchor control's Title tag.
            Me.Title = "Text from OnPreRender."
        End Sub
    End Class
End Namespace
' </Snippet2>
