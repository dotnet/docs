imports Microsoft.VisualBasic
' <snippet3>
imports System

Module IsControlSample

    Sub Main()

        Dim chTab As Char
        chTab = Chr(9)      ' Tab character
        Dim str As String
        str = "sample string"

        Console.WriteLine(Char.IsControl(chTab))    ' Output: "True"
        Console.WriteLine(Char.IsControl(str, 6))   ' Output: "False"

    End Sub

End Module
' </snippet3>
