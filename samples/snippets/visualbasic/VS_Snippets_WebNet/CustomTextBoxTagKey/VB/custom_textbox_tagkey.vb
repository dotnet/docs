' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomTextBoxTagKey
        Inherits System.Web.UI.WebControls.TextBox

        Protected Overrides ReadOnly Property TagKey() As System.Web.UI.HtmlTextWriterTag
            Get
                ' If the TextMode is MultiLine, return a Textarea tag, else return an Input tag.
                If Me.TextMode = System.Web.UI.WebControls.TextBoxMode.MultiLine Then
                    Return System.Web.UI.HtmlTextWriterTag.Textarea
                Else
                    Return System.Web.UI.HtmlTextWriterTag.Input
                End If
            End Get
        End Property
    End Class
End Namespace
' </Snippet2>
