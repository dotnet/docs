Imports System
Imports System.Runtime.InteropServices

' <Snippet1>
<BestFitMapping(False, ThrowOnUnmappableChar := True)> _
Interface IMyInterface1
     'Insert code here.
End Interface
' </Snippet1>

Public Class InteropBFMA
    Implements IMyInterface1
    Public Shared Sub Main()
        Dim bfma As New InteropBFMA()

        Console.WriteLine(bfma.GetType().GetInterfaces(0).Name)
    End Sub
End Class

