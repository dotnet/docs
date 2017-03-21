      byte[] bytes = { Byte.MinValue, 14, 122, Byte.MaxValue};
      ulong result;
      
      foreach (byte byteValue in bytes)
      {
         result = Convert.ToUInt64(byteValue);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                           byteValue.GetType().Name, byteValue,
                           result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the Byte value 0 to the UInt64 value 0.
      //    Converted the Byte value 14 to the UInt64 value 14.
      //    Converted the Byte value 122 to the UInt64 value 122.
      //    Converted the Byte value 255 to the UInt64 value 255.