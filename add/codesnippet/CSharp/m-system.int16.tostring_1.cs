      short[] numbers = {0, 14624, 13982, short.MaxValue, 
                         short.MinValue, -16667};
      foreach (short number in numbers)
      {
         Console.WriteLine(number.ToString());
      }            
      // The example displays the following output to the console:
      //       0
      //       14624
      //       13982
      //       32767
      //       -32768
      //       -16667                             