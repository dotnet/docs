Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlInputTextOnPreRender
        Inherits System.Web.UI.HtmlControls.HtmlInputText

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)

            ' Call the base class's OnPreRender method.
            MyBase.OnPreRender(e)

            ' Set the HtmlInputText object's MaxLength property to 30 characters.
            Me.MaxLength = 30
        End Sub
    End Class
    ' </Snippet2>
End Namespace