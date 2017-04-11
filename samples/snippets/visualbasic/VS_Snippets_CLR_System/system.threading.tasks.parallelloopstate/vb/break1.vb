' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim rnd As New Random()
      Dim breakIndex As Integer = rnd.Next(1, 11)
      Dim lowest As New Nullable(Of Long)()

      Console.WriteLine("Will call Break at iteration {0}", breakIndex)
      Console.WriteLine()

      Dim result = Parallel.For(1, 101, Sub(i, state)
                                            Console.WriteLine("Beginning iteration {0}", i)
                                            Dim delay As Integer
                                            Monitor.Enter(rnd)
                                               delay = rnd.Next(1, 1001)
                                            Monitor.Exit(rnd)
                                            Thread.Sleep(delay)

                                            If state.ShouldExitCurrentIteration Then
                                               If state.LowestBreakIteration < i Then
                                                  Return
                                               End If
                                            End If

                                            If i = breakIndex Then
                                               Console.WriteLine("Break in iteration {0}", i)
                                               state.Break()
                                               If state.LowestBreakIteration.HasValue Then
                                                  If lowest < state.LowestBreakIteration Then
                                                     lowest = state.LowestBreakIteration
                                                  Else
                                                     lowest = state.LowestBreakIteration
                                                  End If
                                               End If
                                            End If

                                            Console.WriteLine("Completed iteration {0}", i)
                                       End Sub )
         Console.WriteLine()
         If lowest.HasValue Then
            Console.WriteLine("Lowest Break Iteration: {0}", lowest)
         Else
            Console.WriteLine("No lowest break iteration.")
         End If
   End Sub
End Module
' The example displays output like the following:
'       Will call Break at iteration 8
'
'       Beginning iteration 1
'       Beginning iteration 13
'       Beginning iteration 97
'       Beginning iteration 25
'       Beginning iteration 49
'       Beginning iteration 37
'       Beginning iteration 85
'       Beginning iteration 73
'       Beginning iteration 61
'       Completed iteration 85
'       Beginning iteration 86
'       Completed iteration 61
'       Beginning iteration 62
'       Completed iteration 86
'       Beginning iteration 87
'       Completed iteration 37
'       Beginning iteration 38
'       Completed iteration 38
'       Beginning iteration 39
'       Completed iteration 25
'       Beginning iteration 26
'       Completed iteration 26
'       Beginning iteration 27
'       Completed iteration 73
'       Beginning iteration 74
'       Completed iteration 62
'       Beginning iteration 63
'       Completed iteration 39
'       Beginning iteration 40
'       Completed iteration 40
'       Beginning iteration 41
'       Completed iteration 13
'       Beginning iteration 14
'       Completed iteration 1
'       Beginning iteration 2
'       Completed iteration 97
'       Beginning iteration 98
'       Completed iteration 49
'       Beginning iteration 50
'       Completed iteration 87
'       Completed iteration 27
'       Beginning iteration 28
'       Completed iteration 50
'       Beginning iteration 51
'       Beginning iteration 88
'       Completed iteration 14
'       Beginning iteration 15
'       Completed iteration 15
'       Completed iteration 2
'       Beginning iteration 3
'       Beginning iteration 16
'       Completed iteration 63
'       Beginning iteration 64
'       Completed iteration 74
'       Beginning iteration 75
'       Completed iteration 41
'       Beginning iteration 42
'       Completed iteration 28
'       Beginning iteration 29
'       Completed iteration 29
'       Beginning iteration 30
'       Completed iteration 98
'       Beginning iteration 99
'       Completed iteration 64
'       Beginning iteration 65
'       Completed iteration 42
'       Beginning iteration 43
'       Completed iteration 88
'       Beginning iteration 89
'       Completed iteration 51
'       Beginning iteration 52
'       Completed iteration 16
'       Beginning iteration 17
'       Completed iteration 43
'       Beginning iteration 44
'       Completed iteration 44
'       Beginning iteration 45
'       Completed iteration 99
'       Beginning iteration 4
'       Completed iteration 3
'       Beginning iteration 8
'       Completed iteration 4
'       Beginning iteration 5
'       Completed iteration 52
'       Beginning iteration 53
'       Completed iteration 75
'       Beginning iteration 76
'       Completed iteration 76
'       Beginning iteration 77
'       Completed iteration 65
'       Beginning iteration 66
'       Completed iteration 5
'       Beginning iteration 6
'       Completed iteration 89
'       Beginning iteration 90
'       Completed iteration 30
'       Beginning iteration 31
'       Break in iteration 8
'       Completed iteration 8
'       Completed iteration 6
'       Beginning iteration 7
'       Completed iteration 7
'
'       Lowest Break Iteration: 8
' </Snippet2>
