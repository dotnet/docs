Public Class UserControl1

    '<SNIPPET1>
    Private Sub UserControl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (Me.Site IsNot Nothing) Then
            Dim Doc As HtmlDocument = CType(Me.Site.GetService(Type.GetType("System.Windows.Forms.HtmlDocument")), HtmlDocument)
        End If
    End Sub
    '</SNIPPET1>
End Class