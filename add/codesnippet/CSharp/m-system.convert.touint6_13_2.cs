      // Create a negative hexadecimal value out of range of the UInt64 type.
      long sourceNumber = Int64.MinValue;
      bool isSigned = Math.Sign((long)sourceNumber.GetType().GetField("MinValue").GetValue(null)) == -1;
      string value = Convert.ToString(sourceNumber, 16);
      UInt64 targetNumber;
      try
      {
         targetNumber = Convert.ToUInt64(value, 16);
         if (isSigned && ((targetNumber & 0x8000000000000000) != 0))
            throw new OverflowException();
         else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber);
      }
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned long integer.", 
                           value);
      } 
      // Displays the following to the console:
      //    Unable to convert '0x8000000000000000' to an unsigned long integer.     