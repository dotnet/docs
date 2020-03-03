' <Snippet1>
Public Module TipCalculator
    Private Const tipRate As Double = 0.18
   
    Public Sub Main(args As String())
        Dim billTotal As Double
        If (args.Length = 0) OrElse (Not Double.TryParse(args(0), billTotal)) Then
            Console.WriteLine("usage: TIPCALC total")
            Return
        End If

        Dim tip As Double = billTotal * tipRate
        Console.WriteLine()
        Console.WriteLine($"Bill total:{vbTab}{billTotal,8:c}")
        Console.WriteLine($"Tip total/rate:{vbTab}{tip,8:c} ({tipRate:p1})")
        Console.WriteLine("".PadRight(24, "-"c))
        Console.WriteLine($"Grand total:{vbTab}{billTotal + tip,8:c}")
    End Sub

End Module

'Example Output:
'---------------
' >tipcalc 52.23
' 
' Bill total:       $52.23
' Tip total/rate:    $9.40 (18.0 %)
' ------------------------
' Grand total:      $61.63
' </Snippet1>
