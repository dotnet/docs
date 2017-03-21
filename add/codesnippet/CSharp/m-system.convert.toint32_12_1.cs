      ushort[] numbers = { UInt16.MinValue, 121, 340, UInt16.MaxValue };
      int result;
      foreach (ushort number in numbers)
      {
         try {
            result = Convert.ToInt32(number);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the Int32 type.",
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //    Converted the UInt16 value 0 to the Int32 value 0.
      //    Converted the UInt16 value 121 to the Int32 value 121.
      //    Converted the UInt16 value 340 to the Int32 value 340.
      //    Converted the UInt16 value 65535 to the Int32 value 65535.