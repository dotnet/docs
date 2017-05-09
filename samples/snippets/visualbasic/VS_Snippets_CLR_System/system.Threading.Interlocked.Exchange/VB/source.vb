' <Snippet1>
Imports System
Imports System.Threading

Public Class AtomicTest

    <MTAThread> _
    Shared Sub Main()
        Dim atomicExchange As New AtomicExchange()
        Dim firstThread As New Thread(AddressOf atomicExchange.Switch)
        firstThread.Start()
    End Sub

End Class

Public Class AtomicExchange

    Public Class SomeType
    End Class

    ' To use Interlocked.Exchange, someType1 
    ' must be declared as type Object.
    Dim someType1 As Object   
    Dim someType2 As SomeType 

    Sub New() 
        someType1 = New SomeType()
        someType2 = New SomeType()
    End Sub

    Sub Switch()
        someType2 = CType(Interlocked.Exchange( _
            someType1, CType(someType2, Object)), SomeType)
    End Sub

End Class
' </Snippet1>
