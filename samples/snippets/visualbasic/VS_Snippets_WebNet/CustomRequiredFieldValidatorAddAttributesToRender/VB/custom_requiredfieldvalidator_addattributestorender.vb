' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomRequiredFieldValidatorAddAttributesToRender
        Inherits System.Web.UI.WebControls.RequiredFieldValidator

        Protected Overrides Sub AddAttributesToRender(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Show the RequiredFieldValidator's error message as bold.
            writer.AddStyleAttribute(System.Web.UI.HtmlTextWriterStyle.FontWeight, "bold")

            ' Call the Base's AddAttributesToRender method.
            MyBase.AddAttributesToRender(writer)
        End Sub
    End Class
End Namespace
' </Snippet2>
