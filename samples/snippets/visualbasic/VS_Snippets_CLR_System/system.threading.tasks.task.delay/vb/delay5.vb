' Visual Basic .NET Document
Option Strict On
Option Infer On

Imports System.Diagnostics
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      DelayAtStart()
      Console.WriteLine("---")
      DelayDuring()
      Console.WriteLine("---")
      DelayDuringLang()
   End Sub
   
   Private Sub DelayAtStart()
      ' <Snippet5>
      Dim sw As Stopwatch = Stopwatch.StartNew()
      Dim delay1 = Task.Delay(1000)
      Dim delay2 = delay1.ContinueWith( Function(antecedent)
                              sw.Stop()
                              Return sw.ElapsedMilliseconds
                            End Function)

      Console.WriteLine("Elapsed milliseconds: {0}", delay2.Result)
      ' The example displays output like the following:
      '        Elapsed milliseconds: 1013
      ' </Snippet5>
   End Sub

   Private Sub DelayDuring()
      ' <Snippet6>
      Dim delay = Task.Run( Function()
                               Dim sw As Stopwatch = Stopwatch.StartNew()
                               Task.Delay(2000).Wait()
                               sw.Stop()
                               Return sw.ElapsedMilliseconds
                            End Function )

      Console.WriteLine("Elapsed milliseconds: {0}", delay.Result)
      ' The example displays output like the following:
      '        Elapsed milliseconds: 2006
      ' </Snippet6>
   End Sub

   Private Sub DelayDuringLang()
      ' <Snippet7>
      Dim delay = Task.Run( Async Function()
                               Dim sw As Stopwatch = Stopwatch.StartNew()
                               Await Task.Delay(2500)
                               sw.Stop()
                               Return sw.ElapsedMilliseconds
                            End Function )

      Console.WriteLine("Elapsed milliseconds: {0}", delay.Result)
      ' The example displays output like the following:
      '        Elapsed milliseconds: 2501
      ' </Snippet7>
   End Sub
End Module

