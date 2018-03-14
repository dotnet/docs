Module Module1
    '<Snippet1>
    Sub Main()
        Dim GStart As Guid = Guid.NewGuid()
        Dim guidB As String = GStart.ToString("B")

        Dim GCurrent As Guid = Guid.Parse(guidB)
        Dim guidX As String = GCurrent.ToString("X")

        If Guid.TryParse(guidX, GCurrent) Then
            Console.WriteLine(GCurrent.ToString("X"))
        Else
            Console.WriteLine("Last parse operation unsuccessful.")
        End If

        If Guid.TryParseExact(guidX, "X", GCurrent) Then
            Console.WriteLine(GCurrent.ToString("X"))
        Else
            Console.WriteLine("Last parse operation unsuccessful.")
        End If
    End Sub
    ' </Snippet1>

End Module
