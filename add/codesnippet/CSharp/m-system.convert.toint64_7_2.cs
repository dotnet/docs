      // Create a negative hexadecimal value out of range of the Byte type.
      ulong sourceNumber = ulong.MaxValue;
      bool isSigned = Math.Sign(Convert.ToDouble(sourceNumber.GetType().GetField("MinValue").GetValue(null))) == -1;
      string value = sourceNumber.ToString("X");
      long targetNumber;
      try
      {
         targetNumber = Convert.ToInt64(value, 16);
         if (! isSigned && ((targetNumber & 0x80000000) != 0))
            throw new OverflowException();
         else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber);
      }
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to a long integer.", value);
      } 
      // Displays the following to the console:
      //    Unable to convert '0xFFFFFFFFFFFFFFFF' to a long integer.     