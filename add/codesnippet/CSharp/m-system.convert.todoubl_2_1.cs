      short[] numbers = { Int16.MinValue, -1032, 0, 192, Int16.MaxValue };
      double result;
      
      foreach (short number in numbers)
      {
         result = Convert.ToDouble(number);
         Console.WriteLine("Converted the UInt16 value {0} to {1}.",
                           number, result);
      }                     
      //       Converted the UInt16 value -32768 to -32768.
      //       Converted the UInt16 value -1032 to -1032.
      //       Converted the UInt16 value 0 to 0.
      //       Converted the UInt16 value 192 to 192.
      //       Converted the UInt16 value 32767 to 32767.