      // Create a hexadecimal value out of range of the UInt64 type.
      string value = Convert.ToString(Int64.MinValue, 16);
      // Convert it back to a number.
      try
      {
         UInt64 number = Convert.ToUInt64(value, 16);
         Console.WriteLine("0x{0} converts to {1}.", value, number);
      }   
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned long integer.", 
                           value);
      }   