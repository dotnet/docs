Public Class CodeForm
    '<SNIPPET1>
    Public Property Code() As String
        Get
            If (RichTextBox1.Text IsNot Nothing) Then
                Code = RichTextBox1.Text
            Else
                Code = ""
            End If
        End Get

        Set(ByVal value As String)
            RichTextBox1.Text = value
        End Set
    End Property
    '</SNIPPET1>
End Class