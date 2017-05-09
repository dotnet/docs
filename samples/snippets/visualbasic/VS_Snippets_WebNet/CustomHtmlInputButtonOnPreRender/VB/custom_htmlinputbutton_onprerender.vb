' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls

    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlInputButtonOnPreRender
        Inherits System.Web.UI.HtmlControls.HtmlInputButton

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)

            ' Call the base class's OnPreRender method.
            MyBase.OnPreRender(e)

            ' Always display the HtmlInputButton with bold text.
            Me.Style.Add("font-weight", "bold")
        End Sub
    End Class

End Namespace
' </Snippet2>
