 ' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls

    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlInputCheckBoxOnPreRender
        Inherits System.Web.UI.HtmlControls.HtmlInputCheckBox

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)

            ' Call the base class's OnPreRender method.
            MyBase.OnPreRender(e)

            ' Add a Title attribute to each HtmlInputCheckBox.
            Me.Attributes.Add("title", "If you like " + Me.Value + ", then select this check box.")
        End Sub
    End Class

End Namespace
' </Snippet2>
