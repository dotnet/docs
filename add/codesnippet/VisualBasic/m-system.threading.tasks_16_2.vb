      Dim delay = Task.Run( Async Function()
                               Dim sw As Stopwatch = Stopwatch.StartNew()
                               Await Task.Delay(2500)
                               sw.Stop()
                               Return sw.ElapsedMilliseconds
                            End Function )

      Console.WriteLine("Elapsed milliseconds: {0}", delay.Result)
      ' The example displays output like the following:
      '        Elapsed milliseconds: 2501