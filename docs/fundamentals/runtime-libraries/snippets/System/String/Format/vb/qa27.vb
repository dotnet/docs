' Visual Basic .NET Document
Option Strict On

' <Snippet27>
Module Example8
    Public Sub Main()
        Dim value As Decimal = 16309.5436D
        Dim result As String = String.Format("{0,12:#.00000} {0,12:0,000.00} {0,12:000.00#}",
                                           value)
        Console.WriteLine(result)
    End Sub
End Module
' The example displays the following output:
'    16309.54360    16,309.54    16309.544
' </Snippet27>

