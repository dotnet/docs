' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example7
    Public Sub Main()
        Dim values() As String = {Nothing, String.Empty, "True", "False",
                                 "true", "false", "    true    ",
                                 "TrUe", "fAlSe", "fa lse", "0",
                                 "1", "-1", "string"}
        ' Parse strings using the Boolean.Parse method.                    
        For Each value In values
            Try
                Dim flag As Boolean = Boolean.Parse(value)
                Console.WriteLine("'{0}' --> {1}", value, flag)
            Catch e As ArgumentException
                Console.WriteLine("Cannot parse a null string.")
            Catch e As FormatException
                Console.WriteLine("Cannot parse '{0}'.", value)
            End Try
        Next
        Console.WriteLine()
        ' Parse strings using the Boolean.TryParse method.                    
        For Each value In values
            Dim flag As Boolean = False
            If Boolean.TryParse(value, flag) Then
                Console.WriteLine("'{0}' --> {1}", value, flag)
            Else
                Console.WriteLine("Cannot parse '{0}'.", value)
            End If
        Next
    End Sub
End Module
' The example displays the following output:
'       Cannot parse a null string.
'       Cannot parse ''.
'       'True' --> True
'       'False' --> False
'       'true' --> True
'       'false' --> False
'       '    true    ' --> True
'       'TrUe' --> True
'       'fAlSe' --> False
'       Cannot parse 'fa lse'.
'       Cannot parse '0'.
'       Cannot parse '1'.
'       Cannot parse '-1'.
'       Cannot parse 'string'.
'       
'       Unable to parse ''
'       Unable to parse ''
'       'True' --> True
'       'False' --> False
'       'true' --> True
'       'false' --> False
'       '    true    ' --> True
'       'TrUe' --> True
'       'fAlSe' --> False
'       Cannot parse 'fa lse'.
'       Unable to parse '0'
'       Unable to parse '1'
'       Unable to parse '-1'
'       Unable to parse 'string'
' </Snippet2>

