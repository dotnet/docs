      short[] numbers = { Int16.MinValue, -1000, 0, 1000, Int16.MaxValue };
      decimal result;
      
      foreach (short number in numbers)
      {
         result = Convert.ToDecimal(number);
         Console.WriteLine("Converted the Int16 value {0} to the Decimal value {1}.",
                           number, result);
      }
      // The example displays the following output:
      //       Converted the Int16 value -32768 to the Decimal value -32768.
      //       Converted the Int16 value -1000 to the Decimal value -1000.
      //       Converted the Int16 value 0 to the Decimal value 0.
      //       Converted the Int16 value 1000 to the Decimal value 1000.
      //       Converted the Int16 value 32767 to the Decimal value 32767.