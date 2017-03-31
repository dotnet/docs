' <Snippet2>

Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Samples
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlInputRadioButtonRenderAttributes
        Inherits System.Web.UI.HtmlControls.HtmlInputRadioButton

        Protected Overrides Sub RenderAttributes(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Call the base class's RenderAttributes method.
            MyBase.RenderAttributes(writer)

            ' Write out the control's Title tag.
            writer.Write((" Title=""Option " + Me.Value + """"))

        End Sub
    End Class
End Namespace

' </Snippet2>
