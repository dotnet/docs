'<SNIPPET2>
<System.Security.Permissions.PermissionSet(Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class Form1

    Dim SG As StyleGenerator = Nothing
    Dim Elem As HtmlElement = Nothing
    Dim WithEvents DocumentEvents As HtmlDocument

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        SG = New StyleGenerator()
        DocumentEvents = WebBrowser1.Document
    End Sub

    Private Sub Document_MouseOver(ByVal sender As Object, ByVal e As HtmlElementEventArgs) Handles DocumentEvents.MouseOver
        Elem = WebBrowser1.Document.GetElementFromPoint(e.MousePosition)
        If Elem.TagName.Equals("DIV") Then
            SG.ParseStyleString(Elem.Style)
            SG.SetStyle("font-style", "italic")
            Elem.Style = SG.GetStyleString()
        End If
    End Sub

    Private Sub Document_MouseLeave(ByVal sender As Object, ByVal e As HtmlElementEventArgs) Handles DocumentEvents.MouseLeave
        If (Elem IsNot Nothing) Then
            SG.RemoveStyle("font-style")
            Elem.Style = SG.GetStyleString()
            ' Reset, since we may mouse over a new DIV element next time.
            SG.Clear()
        End If
    End Sub
End Class
'</SNIPPET2>