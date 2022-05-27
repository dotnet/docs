' Visual Basic .NET Document
Option Strict On

Module ConvertibleExample
    Public Sub Main()
        CallEII()
        Console.WriteLine("-----")

    End Sub

    Private Sub CallEII()
        ' <Snippet7>
        Dim codePoint As Integer = 1067
        Dim iConv As IConvertible = codePoint
        Dim ch As Char = iConv.ToChar(Nothing)
        Console.WriteLine("Converted {0} to {1}.", codePoint, ch)
        ' </Snippet7>
    End Sub
End Module

