      // Create a hexadecimal value out of range of the SByte type.
      byte sourceNumber = byte.MaxValue;
      bool isSigned = Math.Sign(Convert.ToDouble(sourceNumber.GetType().GetField("MinValue").GetValue(null))) == -1;
      string value = Convert.ToString(sourceNumber, 16);
      sbyte targetNumber;
      try
      {
         targetNumber = Convert.ToSByte(value, 16);
         if (! isSigned && ((targetNumber & 0x80) != 0))
            throw new OverflowException();
         else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber);
      }
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to a signed byte.", value);
      } 
      // Displays the following to the console:
      //    Unable to convert '0xff' to a signed byte.     