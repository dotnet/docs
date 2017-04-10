' <Snippet1>
Imports System.Runtime.InteropServices

<ComVisible(False)> _
Class SampleClass
    
    Public Sub New()
        'Insert code here.
    End Sub
    
    <ComVisible(False)> _
    Public Function MyMethod(param As String) As Integer
        Return 0
    End Function    
    
    Public Function MyOtherMethod() As Boolean
        Return True
    End Function
    
    <ComVisible(False)> _
    Public ReadOnly Property MyProperty() As Integer
        Get
            Return MyProperty
        End Get
    End Property
    
End Class
' </Snippet1>
