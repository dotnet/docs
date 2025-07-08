' Visual Basic .NET Document
Option Strict On

' <Snippet13>
Module Example5
    Public Sub Main()
        ' Search for "oe" and "œu" in "œufs" and "oeufs".
        Dim s1 As String = "œufs"
        Dim s2 As String = "oeufs"
        FindInString(s1, "oe", StringComparison.CurrentCulture)
        FindInString(s1, "oe", StringComparison.Ordinal)
        FindInString(s2, "œu", StringComparison.CurrentCulture)
        FindInString(s2, "œu", StringComparison.Ordinal)
        Console.WriteLine()

        Dim softHyphen As String = ChrW(&HAD)
        Dim s3 As String = "co" + softHyphen + "operative"
        FindInString(s3, softHyphen, StringComparison.CurrentCulture)
        FindInString(s3, softHyphen, StringComparison.Ordinal)
    End Sub

    Private Sub FindInString(s As String, substring As String,
                            options As StringComparison)
        Dim result As Integer = s.IndexOf(substring, options)
        If result <> -1 Then
            Console.WriteLine("'{0}' found in {1} at position {2}",
                           substring, s, result)
        Else
            Console.WriteLine("'{0}' not found in {1}",
                           substring, s)
        End If
    End Sub
End Module
' The example displays the following output:
'       'oe' found in œufs at position 0
'       'oe' not found in œufs
'       'œu' found in oeufs at position 0
'       'œu' not found in oeufs
'       
'       '­' found in co­operative at position 0
'       '­' found in co­operative at position 2
' </Snippet13>
