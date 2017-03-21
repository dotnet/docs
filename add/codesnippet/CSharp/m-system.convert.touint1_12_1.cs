      short[] numbers = { Int16.MinValue, -132, 0, 121, 16103, Int16.MaxValue  };
      ushort result;
      
      foreach (short number in numbers)
      {
         try {
            result = Convert.ToUInt16(number);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              number.GetType().Name, number, 
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt16 type.",
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //    The Int16 value -32768 is outside the range of the UInt16 type.
      //    The Int16 value -132 is outside the range of the UInt16 type.
      //    Converted the Int16 value '0' to the UInt16 value 0.
      //    Converted the Int16 value '121' to the UInt16 value 121.
      //    Converted the Int16 value '16103' to the UInt16 value 16103.
      //    Converted the Int16 value '32767' to the UInt16 value 32767.