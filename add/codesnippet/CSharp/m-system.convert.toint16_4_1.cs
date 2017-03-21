      decimal[] values = { Decimal.MinValue, -1034.23m, -12m, 0m, 147m,
                                  9214.16m, Decimal.MaxValue };
      short result;
      
      foreach (decimal value in values)
      {
         try {
            result = Convert.ToInt16(value);
            Console.WriteLine("Converted {0} to {1}.", value, result);
         }   
         catch (OverflowException)
         {
            Console.WriteLine("{0} is outside the range of the Int16 type.",
                              value);
         }   
      }                                  
      // The example displays the following output:
      //    -79228162514264337593543950335 is outside the range of the Int16 type.
      //    Converted -1034.23 to -1034.
      //    Converted -12 to -12.
      //    Converted 0 to 0.
      //    Converted 147 to 147.
      //    Converted 9214.16 to 9214.
      //    79228162514264337593543950335 is outside the range of the Int16 type.