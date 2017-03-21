        ' ConvertFrom method.
        Console.WriteLine("Original Value: {0}", _
          testStrVal.ToString())
        resultStrVal = myLCStrConverter.ConvertFrom(ctx, ci, testStrVal)
        Console.WriteLine("ConvertFrom result: {0}", _
          resultStrVal.ToString())