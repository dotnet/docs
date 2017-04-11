Namespace Samples.AspNet.VB.Controls
' <Snippet2>
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class CustomButtonRaisePostBackEvent
    Inherits System.Web.UI.WebControls.Button

    Private message As String = System.String.Empty

    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        ' Render a HTML submit button.
        writer.Write("<INPUT TYPE='submit' name='" + Me.UniqueID + "' value='Click Me' />")
        writer.Write("<BR>" + message)
    End Sub

    ' Note: VB.NET does not allow one to re-implement a base class interface, whereas C# does.
    ' Hence, just use the base class's PostBackEventHandler's RaisePostBackEvent method,
    ' which calls the OnClick method.

    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        message = "RaisePostBackEvent method successful!"
    End Sub
End Class
' </Snippet2>
End Namespace