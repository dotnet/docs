Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlSelectOnPreRender
        Inherits System.Web.UI.HtmlControls.HtmlSelect

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)

            ' Call the base's OnPreRender method.
            MyBase.OnPreRender(e)

            ' Allow multiple selections.
            Me.Multiple = True
        End Sub
    End Class
    ' </Snippet2>
End Namespace