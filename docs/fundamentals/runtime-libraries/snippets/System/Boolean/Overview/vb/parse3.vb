' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Module Example8
    Public Sub Main()
        Dim values() As String = {"09", "12.6", "0", "-13 "}
        For Each value In values
            Dim success, result As Boolean
            Dim number As Integer
            success = Int32.TryParse(value, number)
            If success Then
                ' The method throws no exceptions.
                result = Convert.ToBoolean(number)
                Console.WriteLine("Converted '{0}' to {1}", value, result)
            Else
                Console.WriteLine("Unable to convert '{0}'", value)
            End If
        Next
    End Sub
End Module
' The example displays the following output:
'       Converted '09' to True
'       Unable to convert '12.6'
'       Converted '0' to False
'       Converted '-13 ' to True
' </Snippet9>
