      // Create a negative hexadecimal value out of range of the UInt32 type.
      int sourceNumber = Int32.MinValue;
      bool isSigned = Math.Sign((int)sourceNumber.GetType().GetField("MinValue").GetValue(null)) == -1;
      string value = Convert.ToString(sourceNumber, 16);
      UInt32 targetNumber;
      try
      {
         targetNumber = Convert.ToUInt32(value, 16);
         if (isSigned && ((targetNumber & 0x80000000) != 0))
            throw new OverflowException();
         else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber);
      }
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned integer.", 
                           value);
      } 
      // Displays the following to the console:
      //    Unable to convert '0x80000000' to an unsigned integer.     