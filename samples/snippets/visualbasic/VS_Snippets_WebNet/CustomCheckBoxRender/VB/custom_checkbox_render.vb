' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomCheckBoxRender
        Inherits System.Web.UI.WebControls.CheckBox

        Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
            ' Call the base class's Render method.
            MyBase.Render(writer)

            ' Render a BR HTML tag
            writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Br)

            ' Create and render a new Image Web control.
            Dim image As New System.Web.UI.WebControls.Image
            image.ID = "Image1"
            image.ImageUrl = "image.jpg"
            image.AlternateText = "Image for CheckBox1."
            image.RenderControl(writer)
        End Sub
    End Class
End Namespace
' </Snippet2>