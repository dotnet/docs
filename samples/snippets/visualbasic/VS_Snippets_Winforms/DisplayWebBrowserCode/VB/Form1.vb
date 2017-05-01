Public Class Form1

    '<SNIPPET2>
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim elem As HtmlElement

        If (WebBrowser1.Document IsNot Nothing) Then
            Dim cf As New CodeForm()
            Dim elems As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("HTML")
            If (elems.Count = 1) Then
                elem = elems(0)
                cf.Code = elem.OuterHtml
                cf.Show()
            End If
        End If
    End Sub
    '</SNIPPET2>
End Class
