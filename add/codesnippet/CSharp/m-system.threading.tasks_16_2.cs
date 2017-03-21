      var delay = Task.Run( async () => { Stopwatch sw = Stopwatch.StartNew();
                                          await Task.Delay(2500);
                                          sw.Stop();
                                          return sw.ElapsedMilliseconds; });

      Console.WriteLine("Elapsed milliseconds: {0}", delay.Result);
      // The example displays output like the following:
      //        Elapsed milliseconds: 2501