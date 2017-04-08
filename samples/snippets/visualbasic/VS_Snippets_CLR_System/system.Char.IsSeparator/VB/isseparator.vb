' <snippet10>
Imports System

Module IsSeparatorSample

    Sub Main()

        Dim str As String
        str = "twain1 twain2"

        Console.WriteLine(Char.IsSeparator("a"c))       ' Output: "False"
        Console.WriteLine(Char.IsSeparator(str, 6))     ' Output: "True"

    End Sub

End Module
' </snippet10>
