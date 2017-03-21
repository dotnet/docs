        // ConvertFrom method.
        Console.WriteLine("Original Value: {0}",
          testStrVal.ToString());
        resultStrVal = myLCStrConverter.ConvertFrom(ctx, ci, testStrVal);
        Console.WriteLine("ConvertFrom result: {0}", 
          resultStrVal.ToString());