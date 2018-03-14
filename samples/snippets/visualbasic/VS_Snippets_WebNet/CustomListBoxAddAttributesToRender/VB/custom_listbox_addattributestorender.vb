Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomListBoxAddAttributesToRender
        Inherits System.Web.UI.WebControls.ListBox

        Protected Overrides Sub AddAttributesToRender(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Show the ListItem text as Bold 
            writer.AddStyleAttribute(System.Web.UI.HtmlTextWriterStyle.FontWeight, "bold")

            ' Call the Base's AddAttributesToRender method.
            MyBase.AddAttributesToRender(writer)
        End Sub
    End Class
    ' </Snippet2>
End Namespace