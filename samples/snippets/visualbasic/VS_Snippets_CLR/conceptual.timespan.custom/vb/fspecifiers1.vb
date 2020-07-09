' Visual Basic .NET Document
Option Strict On

Module Example
    Public Sub Main()
        ShowSingleSpecifier()
    End Sub

    Private Sub ShowSingleSpecifier()
        ' <Snippet20>
        Dim ts As New TimeSpan(1003498765432)
        Dim fmt As String
        Console.WriteLine(ts.ToString("c"))
        Console.WriteLine()

        For ctr = 1 To 7
            fmt = New String("f"c, ctr)
            If fmt.Length = 1 Then fmt = "%" + fmt
            Console.WriteLine("{0,10}: {1:" + fmt + "}", fmt, ts)
        Next
        Console.WriteLine()

        For ctr = 1 To 7
            fmt = New String("f"c, ctr)
            Console.WriteLine("{0,10}: {1:s\." + fmt + "}", "s\." + fmt, ts)
        Next
        ' The example displays the following output:
        '            %f: 8
        '            ff: 87
        '           fff: 876
        '          ffff: 8765
        '         fffff: 87654
        '        ffffff: 876543
        '       fffffff: 8765432
        '    
        '           s\.f: 29.8
        '          s\.ff: 29.87
        '         s\.fff: 29.876
        '        s\.ffff: 29.8765
        '       s\.fffff: 29.87654
        '      s\.ffffff: 29.876543
        '     s\.fffffff: 29.8765432
        ' </Snippet20>
    End Sub
End Module

