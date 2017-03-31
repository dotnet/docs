Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlInputHiddenOnPreRender
        Inherits System.Web.UI.HtmlControls.HtmlInputHidden

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)

            ' Call the base class's OnPreRender method.
            MyBase.OnPreRender(e)

            ' Encode the Hidden Input value as HTML.
            Me.Value = System.Web.HttpContext.Current.Server.HtmlEncode(Me.Value)
        End Sub
    End Class
    ' </Snippet2>
End Namespace