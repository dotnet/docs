' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example2
    Public Sub Main()
        Dim baseValues() As Integer = {2, 8, 10, 16}
        Dim value As Short = Int16.MaxValue
        For Each baseValue In baseValues
            Dim s As String = Convert.ToString(value, baseValue)
            Dim value2 As Short = Convert.ToInt16(s, baseValue)

            Console.WriteLine("{0} --> {1} (base {2}) --> {3}",
                           value, s, baseValue, value2)
        Next
    End Sub
End Module
' The example displays the following output:
'     32767 --> 111111111111111 (base 2) --> 32767
'     32767 --> 77777 (base 8) --> 32767
'     32767 --> 32767 (base 10) --> 32767
'     32767 --> 7fff (base 16) --> 32767
' </Snippet2>
