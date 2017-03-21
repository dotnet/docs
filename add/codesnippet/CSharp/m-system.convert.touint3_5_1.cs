      decimal[] values= { Decimal.MinValue, -1034.23m, -12m, 0m, 147m,
                          199.55m, 9214.16m, Decimal.MaxValue };
      uint result;
      
      foreach (decimal value in values)
      {
         try {
            result = Convert.ToUInt32(value);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                              value.GetType().Name, value,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt32 type.",
                              value.GetType().Name, value);
         }   
      }                                  
      // The example displays the following output:
      //    The Decimal value -79228162514264337593543950335 is outside the range of the UInt32 type.
      //    The Decimal value -1034.23 is outside the range of the UInt32 type.
      //    The Decimal value -12 is outside the range of the UInt32 type.
      //    Converted the Decimal value '0' to the UInt32 value 0.
      //    Converted the Decimal value '147' to the UInt32 value 147.
      //    Converted the Decimal value '199.55' to the UInt32 value 200.
      //    Converted the Decimal value '9214.16' to the UInt32 value 9214.
      //    The Decimal value 79228162514264337593543950335 is outside the range of the UInt32 type.