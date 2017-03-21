      // Create a hexadecimal value out of range of the long type.
      string value = ulong.MaxValue.ToString("X");
      // Use Convert.ToInt64 to convert it back to a number.
      try
      {
         long number = Convert.ToInt64(value, 16);
         Console.WriteLine("0x{0} converts to {1}.", value, number);
      }   
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to a long integer.", value);
      }   