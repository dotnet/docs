     // Create a hexadecimal value out of range of the Integer type.
     string value = Convert.ToString((long) int.MaxValue + 1, 16);
     // Convert it back to a number.
     try
     {
        int number = Convert.ToInt32(value, 16);
        Console.WriteLine("0x{0} converts to {1}.", value, number.ToString());
     }
     catch (OverflowException)
     {
        Console.WriteLine("Unable to convert '0x{0}' to an integer.", value);
     }   