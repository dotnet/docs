'<Snippet4>
<System.ComponentModel.ComplexBindingProperties("DataSource", "DataMember")>
Public Class ComplexDataGridView

    Public Property DataSource() As Object
        Get
            Return DataGridView1.DataSource
        End Get
        Set(ByVal value As Object)
            DataGridView1.DataSource = value
        End Set
    End Property

    Public Property DataMember() As String
        Get
            Return DataGridView1.DataMember
        End Get
        Set(ByVal value As String)
            DataGridView1.DataMember = value
        End Set
    End Property
End Class
'</Snippet4>
