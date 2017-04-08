Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlInputRadioButtonOnPreRender
        Inherits System.Web.UI.HtmlControls.HtmlInputRadioButton

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)

            ' Run the OnPreRender method on the base class.
            MyBase.OnPreRender(e)

            ' Add a Title attribute.
            Me.Attributes.Add("title", "Option " + Me.Value)
        End Sub
    End Class
    ' </Snippet2>
End Namespace