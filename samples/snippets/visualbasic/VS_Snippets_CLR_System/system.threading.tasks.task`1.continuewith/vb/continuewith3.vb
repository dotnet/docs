' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet3>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim cts As New CancellationTokenSource()
      Dim token As CancellationToken = cts.Token

      ' Get an integer to generate a list of its exponents.
      Dim rnd As New Random()
      Dim number As Integer = rnd.Next(2, 21)

      Dim t = Task.Factory.StartNew( Function(value)
                                        Dim n As Integer = CInt(value)
                                        Dim values(9) As Long
                                        For ctr As Integer = 1 To 10
                                           values(ctr - 1) = CLng(Math.Pow(n, ctr))
                                        Next
                                        return values
                                     End Function, number)
      Dim continuation = t.ContinueWith( Sub(antecedent, value)
                                            Console.WriteLine("Exponents of {0}:", value)
                                            For ctr As Integer = 0 To 9
                                               Console.WriteLine("   {0} {1} {2} = {3:N0}",
                                                                 value, ChrW(&h02C6), ctr + 1,
                                                                 antecedent.Result(ctr))
                                            Next
                                            Console.WriteLine()
                                         End Sub, number)
      continuation.Wait()

      cts.Dispose()
   End Sub
End Module
' The example displays output like the following:
'       Exponents of 2:
'          2 ^ 1 = 2
'          2 ^ 2 = 4
'          2 ^ 3 = 8
'          2 ^ 4 = 16
'          2 ^ 5 = 32
'          2 ^ 6 = 64
'          2 ^ 7 = 128
'          2 ^ 8 = 256
'          2 ^ 9 = 512
'          2 ^ 10 = 1,024
' </Snippet3>
