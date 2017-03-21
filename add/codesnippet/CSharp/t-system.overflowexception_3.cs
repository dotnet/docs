      byte value = 241;
      try {
         sbyte newValue = (sbyte) value;
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", 
                           value.GetType().Name, value, 
                           newValue.GetType().Name, newValue);
      }
      catch (OverflowException) {
         Console.WriteLine("Exception: {0} > {1}.", value, SByte.MaxValue);
      }
      // The example displays the following output:
      //       Converted the Byte value 241 to the SByte value -15.