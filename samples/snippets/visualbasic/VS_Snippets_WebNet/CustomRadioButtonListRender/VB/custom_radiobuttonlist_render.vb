' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomRadioButtonListRender
        Inherits System.Web.UI.WebControls.RadioButtonList

        Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Call the base RenderContents method.
            MyBase.Render(writer)

            ' Append some text to the Image.
            writer.Write("Experience Windows Server 2003 and Visual Studio .NET 2003.")
        End Sub 'Render
    End Class
End Namespace
' </Snippet2>
