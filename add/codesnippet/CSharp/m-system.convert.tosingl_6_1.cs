      byte[] numbers = { Byte.MinValue, 10, 100, Byte.MaxValue };
      float result;
      
      foreach (byte number in numbers)
      {
         result = Convert.ToSingle(number);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                           number.GetType().Name, number,
                           result.GetType().Name, result);
      }
      // The example displays the following output:
      //       Converted the Byte value 0 to the Single value 0.
      //       Converted the Byte value 10 to the Single value 10.
      //       Converted the Byte value 100 to the Single value 100.
      //       Converted the Byte value 255 to the Single value 255.