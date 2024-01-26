' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example2
    Public Sub Main()
        Dim value1 As Byte = 12
        Dim value2 As Integer = 12

        Dim object1 As Object = value1
        Dim object2 As Object = value2

        Console.WriteLine("{0} ({1}) = {2} ({3}): {4}",
                        object1, object1.GetType().Name,
                        object2, object2.GetType().Name,
                        object1.Equals(object2))
    End Sub
End Module
' The example displays the following output:
'       12 (Byte) = 12 (Int32): False
' </Snippet3>
