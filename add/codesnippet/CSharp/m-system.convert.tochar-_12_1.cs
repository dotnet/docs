      byte[] bytes = {Byte.MinValue, 40, 80, 120, 180, Byte.MaxValue};
      char result;
      foreach (byte number in bytes)
      {
         result = Convert.ToChar(number);
         Console.WriteLine("{0} converts to '{1}'.", number, result);
      }
      // The example displays the following output:
      //       0 converts to ' '.
      //       40 converts to '('.
      //       80 converts to 'P'.
      //       120 converts to 'x'.
      //       180 converts to '''.
      //       255 converts to 'ÿ'.      