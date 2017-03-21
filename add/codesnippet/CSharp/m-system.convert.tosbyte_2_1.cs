      // Create a hexadecimal value out of range of the SByte type.
      string value = Convert.ToString(byte.MaxValue, 16);
      // Convert it back to a number.
      try
      {
         sbyte number = Convert.ToSByte(value, 16);
         Console.WriteLine("0x{0} converts to {1}.", value, number);
      }   
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to a signed byte.", value);
      }   