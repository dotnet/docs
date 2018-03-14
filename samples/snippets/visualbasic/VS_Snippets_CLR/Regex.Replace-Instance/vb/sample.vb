'<snippet1>
Imports System.Text.RegularExpressions

Module RegExSample
    Function CapText(ByVal m As Match) As String
        ' Get the matched string.
        Dim x As String = m.ToString()
        ' If the first char is lower case...
        If Char.IsLower(x.Chars(0)) Then
            ' Capitalize it.
            Return Char.ToUpper(x.Chars(0)) & x.Substring(1, x.Length - 1)
        End If
        Return x
    End Function

    Sub Main()
        Dim text As String = "four score and seven years ago"

        System.Console.WriteLine("text=[" & text & "]")

        Dim rx As New Regex("\w+")

        Dim result As String = rx.Replace(text, AddressOf RegExSample.CapText)

        System.Console.WriteLine("result=[" & result & "]")
    End Sub
End Module
' The example displays the following output:
'       text=[four score and seven years ago]
'       result=[Four Score And Seven Years Ago]
'</snippet1>