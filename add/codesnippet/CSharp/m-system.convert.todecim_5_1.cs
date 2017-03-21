      ushort[] numbers = { UInt16.MinValue, 121, 12345, UInt16.MaxValue };
      decimal result;
      
      foreach (ushort number in numbers)
      {
         result = Convert.ToDecimal(number);
         Console.WriteLine("Converted the UInt16 value {0} to {1}.",
                           number, result);
      }   
      // The example displays the following output:
      //       Converted the UInt16 value 0 to 0.
      //       Converted the UInt16 value 121 to 121.
      //       Converted the UInt16 value 12345 to 12345.
      //       Converted the UInt16 value 65535 to 65535.      