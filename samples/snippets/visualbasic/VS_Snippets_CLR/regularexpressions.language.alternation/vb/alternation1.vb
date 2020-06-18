' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        ' Regular expression using character class.
        Dim pattern1 As String = "\bgr[ae]y\b"
        ' Regular expression using either/or.
        Dim pattern2 As String = "\bgr(a|e)y\b"

        Dim input As String = "The gray wolf blended in among the grey rocks."
        For Each match As Match In Regex.Matches(input, pattern1)
            Console.WriteLine("'{0}' found at position {1}", _
                              match.Value, match.Index)
        Next
        Console.WriteLine()
        For Each match As Match In Regex.Matches(input, pattern2)
            Console.WriteLine("'{0}' found at position {1}", _
                              match.Value, match.Index)
        Next
    End Sub
End Module
' The example displays the following output:
'       'gray' found at position 4
'       'grey' found at position 35
'       
'       'gray' found at position 4
'       'grey' found at position 35           
' </Snippet1>

