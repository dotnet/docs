' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomTextBoxRender
        Inherits System.Web.UI.WebControls.TextBox

        Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Create and render a new Image Web control.
            Dim image As New System.Web.UI.WebControls.Image
            image.ID = "Image1"
            image.ImageUrl = "image.jpg"
            image.AlternateText = "Image for TextBox1."
            image.RenderControl(writer)

            ' Create a BR tag.
            writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Br)

            ' Call the base class's Render method.
            MyBase.Render(writer)
        End Sub
    End Class
End Namespace
' </Snippet2>
