Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomImageButtonTagKey
        Inherits System.Web.UI.WebControls.ImageButton

        Protected Overrides ReadOnly Property TagKey() As System.Web.UI.HtmlTextWriterTag
            Get
                ' Specify that only the Input HTML tag can be passed to the HtmlTextWriter.
                Return System.Web.UI.HtmlTextWriterTag.Input
            End Get
        End Property
    End Class
    ' </Snippet2>
End Namespace