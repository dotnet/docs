      sbyte[] numbers = { SByte.MinValue, -23, 0, 17, SByte.MaxValue };
      decimal result;
      
      foreach (sbyte number in numbers)
      {
         result = Convert.ToDecimal(number);
         Console.WriteLine("Converted the SByte value {0} to {1}.", number, result);
      }
      //       Converted the SByte value -128 to -128.
      //       Converted the SByte value -23 to -23.
      //       Converted the SByte value 0 to 0.
      //       Converted the SByte value 17 to 17.
      //       Converted the SByte value 127 to 127.