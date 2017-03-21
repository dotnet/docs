      int[] numbers = { Int32.MinValue, -1203, 0, 121, 1340, Int32.MaxValue };
      uint result;
      foreach (int number in numbers)
      {
         try {
            result = Convert.ToUInt32(number);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt32 type.",
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //    The Int32 value -2147483648 is outside the range of the UInt32 type.
      //    The Int32 value -1203 is outside the range of the UInt32 type.
      //    Converted the Int32 value 0 to the UInt32 value 0.
      //    Converted the Int32 value 121 to the UInt32 value 121.
      //    Converted the Int32 value 1340 to the UInt32 value 1340.
      //    Converted the Int32 value 2147483647 to the UInt32 value 2147483647.