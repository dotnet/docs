      short[] numbers= { Int16.MinValue, -1, 0, 121, 340, Int16.MaxValue };
      int result;
      
      foreach (short number in numbers)
      {
         result = Convert.ToInt32(number);
         Console.WriteLine("Converted the {0} value {1} to a {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the Int16 value -32768 to a Int32 value -32768.
      //    Converted the Int16 value -1 to a Int32 value -1.
      //    Converted the Int16 value 0 to a Int32 value 0.
      //    Converted the Int16 value 121 to a Int32 value 121.
      //    Converted the Int16 value 340 to a Int32 value 340.
      //    Converted the Int16 value 32767 to a Int32 value 32767.