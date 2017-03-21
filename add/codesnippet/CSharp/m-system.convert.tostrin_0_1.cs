      bool falseFlag = false;
      bool trueFlag = true;
      
      Console.WriteLine(Convert.ToString(falseFlag));
      Console.WriteLine(Convert.ToString(falseFlag).Equals(Boolean.FalseString));
      Console.WriteLine(Convert.ToString(trueFlag));
      Console.WriteLine(Convert.ToString(trueFlag).Equals(Boolean.TrueString));
      // The example displays the following output:
      //       False
      //       True
      //       True
      //       True