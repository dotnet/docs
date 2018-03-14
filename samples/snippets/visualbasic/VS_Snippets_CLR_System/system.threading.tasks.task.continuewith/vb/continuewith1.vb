' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim firstTask = Task.Factory.StartNew( Function()
                               Dim rnd As New Random()
                               Dim dates(99) As Date
                               Dim buffer(7) As Byte
                               Dim ctr As Integer = dates.GetLowerBound(0)
                               Do While ctr <= dates.GetUpperBound(0)
                                  rnd.NextBytes(buffer)
                                  Dim ticks As Long = BitConverter.ToInt64(buffer, 0)
                                  If ticks <= DateTime.MinValue.Ticks Or ticks >= DateTime.MaxValue.Ticks Then Continue Do

                                  dates(ctr) = New Date(ticks)
                                  ctr += 1
                               Loop
                               Return dates
                            End Function )
                         
      Dim continuationTask As Task = firstTask.ContinueWith( Sub(antecedent)
                             Dim dates() As Date = antecedent.Result
                             Dim earliest As Date = dates(0)
                             Dim latest As Date = earliest
                             
                             For ctr As Integer = dates.GetLowerBound(0) + 1 To dates.GetUpperBound(0)
                                If dates(ctr) < earliest Then earliest = dates(ctr)
                                If dates(ctr) > latest Then latest = dates(ctr)
                             Next
                             Console.WriteLine("Earliest date: {0}", earliest)
                             Console.WriteLine("Latest date: {0}", latest)
                          End Sub)                      
      ' Since a console application otherwise terminates, wait for the continuation to complete.
      continuationTask.Wait()
   End Sub
End Module
' The example displays output like the following:
'       Earliest date: 2/11/0110 12:03:41 PM
'       Latest date: 7/29/9989 2:14:49 PM
' </Snippet1>
