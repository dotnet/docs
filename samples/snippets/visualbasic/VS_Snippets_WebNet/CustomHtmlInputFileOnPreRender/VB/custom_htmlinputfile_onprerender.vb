 ' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls

    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlInputFileOnPreRender
        Inherits System.Web.UI.HtmlControls.HtmlInputFile

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)

            ' Call the base OnPreRender method.
            MyBase.OnPreRender(e)

            ' Add a Title attribute to the HtmlInputFile control.
            Me.Attributes.Add("title", "Click the Browse button to select a file to upload.")
        End Sub
    End Class

End Namespace
' </Snippet2>
