Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomImageRenderContents
        Inherits System.Web.UI.WebControls.Image

        Protected Overrides Sub RenderContents(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Call the base RenderContents method.
            MyBase.RenderContents(writer)

            ' Append some text to the Image.
            writer.Write("<BR>Experience Windows Server 2003 and Visual Studio .NET 2003.")
        End Sub
    End Class
    ' </Snippet2>
End Namespace