      decimal[] numbers = { Decimal.MinValue, -1034.23m, -12m, 0m, 147m,
                                  9214.16m, Decimal.MaxValue };
      ushort result;
      
      foreach (decimal number in numbers)
      {
         try {
            result = Convert.ToUInt16(number);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              number.GetType().Name, number, 
                              result.GetType().Name, result);
         }   
         catch (OverflowException)
         {
            Console.WriteLine("{0} is outside the range of the UInt16 type.",
                              number);
         }   
      }                                  
      // The example displays the following output:
      //    -79228162514264337593543950335 is outside the range of the UInt16 type.
      //    -1034.23 is outside the range of the UInt16 type.
      //    -12 is outside the range of the UInt16 type.
      //    Converted the Decimal value '0' to the UInt16 value 0.
      //    Converted the Decimal value '147' to the UInt16 value 147.
      //    Converted the Decimal value '9214.16' to the UInt16 value 9214.
      //    79228162514264337593543950335 is outside the range of the UInt16 type.