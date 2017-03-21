      short[] numbers = { Int16.MinValue, -138, 0, 19, Int16.MaxValue };
      string result;
      
      foreach (short number in numbers)
      {
         result = Convert.ToString(number);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
      }     
      // The example displays the following output:
      //    Converted the Int16 value -32768 to the String value -32768.
      //    Converted the Int16 value -138 to the String value -138.
      //    Converted the Int16 value 0 to the String value 0.
      //    Converted the Int16 value 19 to the String value 19.
      //    Converted the Int16 value 32767 to the String value 32767.