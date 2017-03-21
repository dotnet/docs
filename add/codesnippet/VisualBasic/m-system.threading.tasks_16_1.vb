      Dim sw As Stopwatch = Stopwatch.StartNew()
      Dim delay1 = Task.Delay(1000)
      Dim delay2 = delay1.ContinueWith( Function(antecedent)
                              sw.Stop()
                              Return sw.ElapsedMilliseconds
                            End Function)

      Console.WriteLine("Elapsed milliseconds: {0}", delay2.Result)
      ' The example displays output like the following:
      '        Elapsed milliseconds: 1013