'<Snippet5>
<System.ComponentModel.LookupBindingProperties("DataSource", "DisplayMember", "ValueMember", "LookupMember")>
Public Class LookupBox

    Public Property DataSource() As Object
        Get
            Return ComboBox1.DataSource
        End Get
        Set(ByVal value As Object)
            ComboBox1.DataSource = value
        End Set
    End Property

    Public Property DisplayMember() As String
        Get
            Return ComboBox1.DisplayMember
        End Get
        Set(ByVal value As String)
            ComboBox1.DisplayMember = value
        End Set
    End Property

    Public Property ValueMember() As String
        Get
            Return ComboBox1.ValueMember
        End Get
        Set(ByVal value As String)
            ComboBox1.ValueMember = value
        End Set
    End Property

    Public Property LookupMember() As String
        Get
            Return ComboBox1.SelectedValue.ToString()
        End Get
        Set(ByVal value As String)
            ComboBox1.SelectedValue = value
        End Set
    End Property
End Class
'</Snippet5>
