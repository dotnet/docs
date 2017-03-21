Imports System.ComponentModel.Composition

'<snippet2>
<Export()>
Public Class Test1
    Public ReadOnly Property data As String
        Get
            Return "The data!"
        End Get
    End Property
End Class
'</snippet2>
