     // Create a hexadecimal value out of range of the Int16 type.
     string value = Convert.ToString((int) short.MaxValue + 1, 16);
     // Convert it back to a number.
     try
     {
        short number = Convert.ToInt16(value, 16);
        Console.WriteLine("0x{0} converts to {1}.", value, number);
     }
     catch (OverflowException)
     {
        Console.WriteLine("Unable to convert '0x{0}' to a 16-bit integer.", value);
     }   