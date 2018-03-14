' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomButtonAddAttributesToRender
        Inherits System.Web.UI.WebControls.Button

        Protected Overrides Sub AddAttributesToRender(ByVal writer As System.Web.UI.HtmlTextWriter)
            ' Add a client-side onclick event to the button.
            writer.AddAttribute(System.Web.UI.HtmlTextWriterAttribute.Onclick, "alert('Hello World');")

            ' Update the text of the button to be shown in the color Red
            writer.AddStyleAttribute(System.Web.UI.HtmlTextWriterStyle.Color, "Red")

            ' Call the base's AddAttributesToRender method
            MyBase.AddAttributesToRender(writer)
        End Sub
    End Class
End Namespace ' Samples.AspNet
' </Snippet2>