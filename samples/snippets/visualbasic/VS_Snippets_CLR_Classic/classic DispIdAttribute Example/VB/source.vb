' <Snippet1>
Imports System.Runtime.InteropServices

Class SampleClass
    
    Public Sub New()
        'Insert code here.
    End Sub
    
    <DispIdAttribute(8)> _ 
    Public Sub MyMethod()
        'Insert code here.
    End Sub    
    
    Public Function MyOtherMethod() As Integer
        'Insert code here.
        Return 0
    End Function
    
    <DispId(9)> _
    Public MyField As Boolean
End Class
' </Snippet1>
