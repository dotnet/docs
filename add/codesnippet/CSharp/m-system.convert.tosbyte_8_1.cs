      decimal[] numbers = { Decimal.MinValue, -129.5m, -12.7m, 0m, 16m,
                            103.6m, 255.0m, Decimal.MaxValue };
      sbyte result;
      
      foreach (decimal number in numbers)
      {
         try {
            result = Convert.ToSByte(number);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the SByte type.",
                              number.GetType().Name, number);
         }
      }                         
      // The example displays the following output:
      //    The Decimal value -79228162514264337593543950335 is outside the range of the SByte type.
      //    The Decimal value -129.5 is outside the range of the SByte type.
      //    Converted the Decimal value -12.7 to the SByte value -13.
      //    Converted the Decimal value 0 to the SByte value 0.
      //    Converted the Decimal value 16 to the SByte value 16.
      //    Converted the Decimal value 103.6 to the SByte value 104.
      //    The Decimal value 255 is outside the range of the SByte type.
      //    The Decimal value 79228162514264337593543950335 is outside the range of the SByte type.