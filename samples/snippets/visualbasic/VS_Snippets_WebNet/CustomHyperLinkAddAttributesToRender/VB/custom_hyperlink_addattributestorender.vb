' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHyperLinkAddAttributesToRender
        Inherits System.Web.UI.WebControls.HyperLink

        Protected Overrides Sub AddAttributesToRender(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Show the HyperLink text as Bold 
            writer.AddStyleAttribute(System.Web.UI.HtmlTextWriterStyle.FontWeight, "bold")

            ' Call the Base's AddAttributesToRender method.
            MyBase.AddAttributesToRender(writer)
        End Sub
    End Class
End Namespace
' </Snippet2>
