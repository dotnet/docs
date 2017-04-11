' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomValidationSummaryAddAttributesToRender
        Inherits System.Web.UI.WebControls.ValidationSummary

        Protected Overrides Sub AddAttributesToRender(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Show the error message as bold.
            writer.AddStyleAttribute(System.Web.UI.HtmlTextWriterStyle.FontWeight, "bold")

            ' Call the Base's AddAttributesToRender method.
            MyBase.AddAttributesToRender(writer)
        End Sub
    End Class
End Namespace
' </Snippet2>
