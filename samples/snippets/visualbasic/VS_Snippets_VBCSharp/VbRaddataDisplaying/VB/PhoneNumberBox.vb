'<Snippet3>
<System.ComponentModel.DefaultBindingProperty("PhoneNumber")>
Public Class PhoneNumberBox

    Public Property PhoneNumber() As String
        Get
            Return MaskedTextBox1.Text
        End Get
        Set(ByVal value As String)
            MaskedTextBox1.Text = value
        End Set
    End Property
End Class
'</Snippet3>
