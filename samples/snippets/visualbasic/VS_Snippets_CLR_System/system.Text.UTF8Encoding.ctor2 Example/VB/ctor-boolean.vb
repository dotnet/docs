' <Snippet1>
Imports System
Imports System.Text

Class UTF8EncodingExample
    
    Public Shared Sub Main()
        Dim utf8 As New UTF8Encoding()
        Dim utf8EmitBOM As New UTF8Encoding(True)
        
        Console.WriteLine("utf8 preamble:")
        ShowArray(utf8.GetPreamble())
        
        Console.WriteLine("utf8EmitBOM:")
        ShowArray(utf8EmitBOM.GetPreamble())
    End Sub 'Main
    
    
    Public Shared Sub ShowArray(theArray As Array)
        Dim o As Object
        For Each o In  theArray
            Console.Write("[{0}]", o)
        Next o
        Console.WriteLine()
    End Sub 'ShowArray
End Class 'UTF8EncodingExample
' </Snippet1>
