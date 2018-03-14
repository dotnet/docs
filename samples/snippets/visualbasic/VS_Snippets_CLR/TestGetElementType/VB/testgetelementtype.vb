' <Snippet1>
Imports System

Class TestGetElementType

    Public Shared Sub Main()
        Dim array As Integer() = {1, 2, 3}
        Dim t As Type = array.GetType()
        Dim t2 As Type = t.GetElementType()
        Console.WriteLine("The element type of {0} is {1}.", array, t2.ToString())
        Dim newMe As New TestGetElementType()
        t = newMe.GetType()
        t2 = t.GetElementType()
        If t2 Is Nothing Then
            Console.WriteLine("The element type of {0} is {1}.", newMe, "null")
        Else
            Console.WriteLine("The element type of {0} is {1}.", newMe, t2.ToString())
        End If
    End Sub 'Main
End Class 'TestGetElementType

' This code produces the following output:
'
'The element type of System.Int32[] is System.Int32.
'The element type of TestGetElementType is null.
' </Snippet1>