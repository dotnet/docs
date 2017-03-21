      byte[] bytes = { Byte.MinValue, 14, 122, Byte.MaxValue};
      short result;
      
      foreach (byte byteValue in bytes)
      {
         result = Convert.ToInt16(byteValue);
         Console.WriteLine("The Byte value {0} converts to {1}.",
                           byteValue, result);
      }
      // The example displays the following output:
      //       The Byte value 0 converts to 0.
      //       The Byte value 14 converts to 14.
      //       The Byte value 122 converts to 122.
      //       The Byte value 255 converts to 255.