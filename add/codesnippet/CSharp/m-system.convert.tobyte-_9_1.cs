      // Create a hexadecimal value out of range of the Byte type.
      string value = SByte.MinValue.ToString("X");
      // Convert it back to a number.
      try
      {
         byte number = Convert.ToByte(value, 16);
         Console.WriteLine("0x{0} converts to {1}.", value, number);
      }   
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to a byte.", value);
      }   