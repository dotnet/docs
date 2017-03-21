      ushort[] numbers = { UInt16.MinValue, 40, 160, 255, 1028, 
                           2011, UInt16.MaxValue };
      char result;
      foreach (ushort number in numbers)
      {
         result = Convert.ToChar(number);
         Console.WriteLine("{0} converts to '{1}'.", number, result);
      }   
      // The example displays the following output:
      //       0 converts to ' '.
      //       40 converts to '('.
      //       160 converts to ' '.
      //       255 converts to 'ÿ'.
      //       1028 converts to '?'.
      //       2011 converts to '?'.
      //       65535 converts to '?'.