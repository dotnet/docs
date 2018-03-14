'<snippet1>
Imports System


Module Application

    Sub Main()
        ' Create a string that will be trimmed.
        Dim path As String = "c:/temp//"

        ' Create an array of characters 
        ' that represent characters to trim.
        Dim charsToTrim As Char() = "/"

        ' Trim the string.
        Dim trimmedPath As String = path.TrimEnd(charsToTrim)

        Console.WriteLine("The trimmed value is: {0}.", trimmedPath)

        ' Create a string that will be trimmed.
        Dim pathWhitespace As String = "c:/temp/  "

        ' Trim whitespaces by passing Nothing.
        Dim trimmedWhiteSpace As String = pathWhitespace.TrimEnd(Nothing)

        Console.WriteLine("The trimmed value is: {0}.", trimmedWhiteSpace)

    End Sub
End Module
' This code example displays the following output:
'       The trimmed value is: c:/temp.
'       The trimmed value is: c:/temp/.
'</snippet1>
