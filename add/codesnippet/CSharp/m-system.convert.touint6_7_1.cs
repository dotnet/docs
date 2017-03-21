      short[] numbers= { Int16.MinValue, -1, 0, 121, 340, Int16.MaxValue };
      ulong result;
      
      foreach (short number in numbers)
      {
         try {
            result = Convert.ToUInt64(number);
            Console.WriteLine("Converted the {0} value {1} to a {2} value {3}.",
                                 number.GetType().Name, number,
                                 result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("{0} is outside the range of the UInt64 type.", number);
         }   
      
      }
      // The example displays the following output:
      //    -32768 is outside the range of the UInt64 type.
      //    -1 is outside the range of the UInt64 type.
      //    Converted the Int16 value 0 to a UInt64 value 0.
      //    Converted the Int16 value 121 to a UInt64 value 121.
      //    Converted the Int16 value 340 to a UInt64 value 340.
      //    Converted the Int16 value 32767 to a UInt64 value 32767.