      bool falseFlag = false;
      bool trueFlag = true;
      
      Console.WriteLine("{0} converts to {1}.", falseFlag,
                        Convert.ToSByte(falseFlag));
      Console.WriteLine("{0} converts to {1}.", trueFlag,
                        Convert.ToSByte(trueFlag));
      // The example displays the following output:
      //       false converts to 0.
      //       true converts to 1.