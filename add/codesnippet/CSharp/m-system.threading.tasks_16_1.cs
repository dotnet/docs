      Stopwatch sw = Stopwatch.StartNew();
      var delay = Task.Delay(1000).ContinueWith(_ =>
                                 { sw.Stop();
                                   return sw.ElapsedMilliseconds; } );

      Console.WriteLine("Elapsed milliseconds: {0}", delay.Result);
      // The example displays output like the following:
      //        Elapsed milliseconds: 1013