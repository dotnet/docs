' Visual Basic .NET Document
Option Strict On

' <Snippet22>
Module Example
    Public Sub Main()
        Dim header As String = "* A Short String. *"
        Console.WriteLine(header)
        Console.WriteLine(header.Trim({" "c, "*"c, "."c}))
    End Sub
End Module
' The example displays the following output:
'       * A Short String. *
'       A Short String
' </Snippet22>
