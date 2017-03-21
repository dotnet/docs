      bool falseFlag = false;
      bool trueFlag = true;
      
      Console.WriteLine("{0} converts to {1}.", falseFlag,
                        Convert.ToInt32(falseFlag));
      Console.WriteLine("{0} converts to {1}.", trueFlag,
                        Convert.ToInt32(trueFlag));
      // The example displays the following output:
      //       False converts to 0.
      //       True converts to 1.