' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlTextAreaOnPreRender
        Inherits System.Web.UI.HtmlControls.HtmlTextArea

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)

            ' Call the base class's OnPreRender method.
            MyBase.OnPreRender(e)

            ' Always display this control with 5 rows and 75 columns.
            Me.Rows = 5
            Me.Cols = 75
        End Sub
    End Class
End Namespace
' </Snippet2>
