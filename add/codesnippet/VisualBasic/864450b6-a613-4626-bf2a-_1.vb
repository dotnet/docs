        ' ConvertTo method.
        Console.WriteLine("Original Value: {0}", _
          testStrVal.ToString())
        resultStrVal = myLCStrConverter.ConvertTo _
          (ctx, ci, testStrVal, testStrVal.GetType())
        Console.WriteLine("ConvertTo result: {0}", _
          resultStrVal.ToString())