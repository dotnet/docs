' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomValidationSummaryRender
        Inherits System.Web.UI.WebControls.ValidationSummary

        Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Write out begining Small HTML tag.
            writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Small)

            ' Call the base class's Render method.
            MyBase.Render(writer)

            ' Write out ending Small HTML tag.
            writer.RenderEndTag()
        End Sub
    End Class
End Namespace
' </Snippet2>
