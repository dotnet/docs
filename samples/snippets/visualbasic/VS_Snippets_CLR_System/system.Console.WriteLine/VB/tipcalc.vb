' <Snippet1>
Public Class TipCalculator
   Private Const tipRate As Double = 0.18
   
   Public Shared Sub Main()
      System.Environment.ExitCode = Calculator(System.Environment.GetCommandLineArgs())
   End Sub
   
   Public Shared Function Calculator(args() As String) As Integer
      Dim billTotal As Double
      If args.Length < 2 Then
         Console.WriteLine("usage: TIPCALC total")
         Return 1
      Else
         If Not Double.TryParse(args(1), billTotal) Then
            Console.WriteLine("usage: TIPCALC total")
            Return 1
         End If
         
         Dim tip As Double = billTotal * tipRate
         Console.WriteLine()
         Console.WriteLine("Bill total:{1}{0,8:c}", billTotal, vbTab)
         Console.WriteLine("Tip total/rate:{2}{0,8:c} ({1:p1})", tip, tipRate, vbTab)
         Console.WriteLine("".PadRight(24, "-"c))
         Console.WriteLine("Grand total:{1}{0,8:c}", billTotal + tip, vbTab)
         Return 0
      End If
   End Function 
End Class 

'Example Output:
'---------------
' >tipcalc 52.23
' 
' Bill total:       $52.23
' Tip total/rate:    $9.40 (18.0 %)
' ------------------------
' Grand total:      $61.63
' </Snippet1>