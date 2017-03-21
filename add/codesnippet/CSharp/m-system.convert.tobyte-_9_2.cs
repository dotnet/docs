      // Create a negative hexadecimal value out of range of the Byte type.
      sbyte sourceNumber = SByte.MinValue;
      bool isSigned = Math.Sign((sbyte)sourceNumber.GetType().GetField("MinValue").GetValue(null)) == -1;
      string value = sourceNumber.ToString("X");
      byte targetNumber;
      try
      {
         targetNumber = Convert.ToByte(value, 16);
         if (isSigned && ((targetNumber & 0x80) != 0))
            throw new OverflowException();
         else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber);
      }
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned byte.", value);
      } 
      // Displays the following to the console:
      //    Unable to convert '0x80' to an unsigned byte.     