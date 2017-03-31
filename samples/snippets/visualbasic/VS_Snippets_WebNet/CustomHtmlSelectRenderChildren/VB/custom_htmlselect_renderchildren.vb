Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlSelectRenderChildren
        Inherits System.Web.UI.HtmlControls.HtmlSelect

        Protected Overrides Sub RenderChildren(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Create a default OPTION.
            Dim listItem As New System.Web.UI.WebControls.ListItem("<Select an option> ", "")
            Me.Items.Insert(0, listItem)

            ' Call base's RenderChildren method.
            MyBase.RenderChildren(writer)
        End Sub
    End Class
    ' </Snippet2>
End Namespace