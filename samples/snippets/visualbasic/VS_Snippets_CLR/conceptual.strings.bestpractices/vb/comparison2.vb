' Visual Basic .NET Document
Option Strict On

<Assembly: CLSCompliant(True)>
Module modMain

    Public Sub Main()
        Dim strA As String = "Владимир"
        Dim strB As String = "ВЛАДИМИР"

        ' <Snippet4>
        String.Compare(strA, strB, StringComparison.OrdinalIgnoreCase)
        ' </Snippet4> 
        Console.WriteLine(String.Compare(strA, strB, StringComparison.OrdinalIgnoreCase))

        ' <Snippet5>
        String.Compare(strA.ToUpperInvariant(), strB.ToUpperInvariant(),
                       StringComparison.Ordinal)
        ' </Snippet5>
        Console.WriteLine(String.Compare(strA.ToUpperInvariant(), strB.ToUpperInvariant(), StringComparison.Ordinal))
    End Sub
End Module

