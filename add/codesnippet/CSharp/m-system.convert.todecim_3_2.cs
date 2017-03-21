      float[] numbers = { Single.MinValue, -3e10f, -1093.54f, 0f, 1e-03f,
                          1034.23f, Single.MaxValue };
      decimal result;
      
      foreach (float number in numbers)
      {
         try {
            result = Convert.ToDecimal(number);
            Console.WriteLine("Converted the Single value {0} to {1}.", number, result);
         }   
         catch (OverflowException) {
            Console.WriteLine("{0} is out of range of the Decimal type.", number);
         }
      }                                  
      // The example displays the following output:
      //       -3.402823E+38 is out of range of the Decimal type.
      //       Converted the Single value -3E+10 to -30000000000.
      //       Converted the Single value -1093.54 to -1093.54.
      //       Converted the Single value 0 to 0.
      //       Converted the Single value 0.001 to 0.001.
      //       Converted the Single value 1034.23 to 1034.23.
      //       3.402823E+38 is out of range of the Decimal type.