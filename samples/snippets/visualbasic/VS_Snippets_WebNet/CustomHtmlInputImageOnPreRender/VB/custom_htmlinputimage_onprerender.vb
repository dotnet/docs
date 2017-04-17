' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlInputImageOnPreRender
        Inherits System.Web.UI.HtmlControls.HtmlInputImage

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)

            ' Call the base class's OnPreRender method.
            MyBase.OnPreRender(e)

            ' Always display the HtmlInputImage control with no border.
            Me.Border = 0
        End Sub
    End Class
End Namespace
' </Snippet2>
