' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks
Imports Timers = System.Timers

Module Example
   Dim ts As CancellationTokenSource

   Public Sub Main(args() As String)
      Dim upperBound As Integer = If(args.Length >= 1, CInt(args(0)), 200)
      ts = New CancellationTokenSource()
      Dim token As CancellationToken = ts.Token
      Dim timer As New Timers.Timer(100)
      AddHandler timer.Elapsed, AddressOf TimedOutEvent
      timer.AutoReset = False
      timer.Enabled = True

      Dim t1 = Task.Run(Function()
                          ' True = composite.
                          ' False = prime.
                          Dim values(upperBound) As Boolean
                          For ctr = 2 To CInt(Math.Sqrt(upperBound))
                             If values(ctr) = False Then
                                For product = ctr * ctr To upperBound Step ctr
                                   values(product) = True
                                Next
                             End If
                             token.ThrowIfCancellationRequested()
                          Next
                          Return values
                       End Function, token)

      Dim t2 = t1.ContinueWith(Sub(antecedent)
                                  ' Create a list of prime numbers.
                                  Dim primes As New List(Of Integer)()
                                  token.ThrowIfCancellationRequested()
                                  Dim numbers As Boolean() = antecedent.Result
                                  Dim output As String = String.Empty
                                  
                                  For ctr As Integer = 1 To numbers.GetUpperBound(0)
                                     If numbers(ctr) = False Then primes.Add(ctr)
                                  Next

                                  ' Create the output string.
                                  For ctr As Integer = 0 To primes.Count - 1
                                     token.ThrowIfCancellationRequested()
                                     output += primes(ctr).ToString("N0")
                                     If ctr < primes.Count - 1 Then output += ",  "
                                     If (ctr + 1) Mod 8 = 0 Then output += vbCrLf
                                  Next
                                  'Display the result.
                                  Console.WriteLine("Prime numbers from 1 to {0}:{1}",
                                                    upperBound, vbCrLf)
                                  Console.WriteLine(output)
                               End Sub, token)
      Try
         t2.Wait()
      Catch ae As AggregateException
         For Each e In ae.InnerExceptions
            If e.GetType Is GetType(TaskCanceledException) Then
               Console.WriteLine("The operation was cancelled.")
            Else
               Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message)
            End If
         Next
      Finally
         ts.Dispose()
      End Try
   End Sub
   
   Private Sub TimedOutEvent(source As Object, e As Timers.ElapsedEventArgs)
      ts.Cancel()
   End Sub
End Module
' If cancellation is not requested, the example displays output like the following:
'       Prime numbers from 1 to 400:
'
'       1,  2,  3,  5,  7,  11,  13,  17,
'       19,  23,  29,  31,  37,  41,  43,  47,
'       53,  59,  61,  67,  71,  73,  79,  83,
'       89,  97,  101,  103,  107,  109,  113,  127,
'       131,  137,  139,  149,  151,  157,  163,  167,
'       173,  179,  181,  191,  193,  197,  199,  211,
'       223,  227,  229,  233,  239,  241,  251,  257,
'       263,  269,  271,  277,  281,  283,  293,  307,
'       311,  313,  317,  331,  337,  347,  349,  353,
'       359,  367,  373,  379,  383,  389,  397,  401
' If cancellation is requested, the example displays output like the following:
'       The operation was cancelled.
' </Snippet1>
