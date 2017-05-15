Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomLiteralRender
        Inherits System.Web.UI.WebControls.Literal

        Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Write out some literal text.
            writer.Write("Literal Text: ")

            ' Call the base Render method.
            MyBase.Render(writer)
        End Sub
    End Class
    ' </Snippet2>
End Namespace