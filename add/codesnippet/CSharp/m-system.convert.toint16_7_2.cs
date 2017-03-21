      // Create a hexadecimal value out of range of the Short type.
      int sourceNumber = (int) short.MaxValue + 1;
      bool isNegative = (Math.Sign(sourceNumber) == -1);
      string value = Convert.ToString(sourceNumber, 16);
      short targetNumber;
      try
      {
         targetNumber = Convert.ToInt16(value, 16);
         if (! isNegative && ((targetNumber & 0x8000) != 0))
            throw new OverflowException();
         else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber);
      }
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to a 16-bit integer.", value);
      } 
      // Displays the following to the console:
      //    Unable to convert '0x8000' to a 16-bit integer.     