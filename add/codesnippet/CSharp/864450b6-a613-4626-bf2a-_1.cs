        // ConvertTo method.
        Console.WriteLine("Original Value: {0}",
          testStrVal.ToString());
        resultStrVal = myLCStrConverter.ConvertTo
          (ctx,ci,testStrVal, testStrVal.GetType());
        Console.WriteLine("ConvertTo result: {0}",
          resultStrVal.ToString());