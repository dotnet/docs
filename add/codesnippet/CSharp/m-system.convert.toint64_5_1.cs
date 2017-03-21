      int[] numbers = { Int32.MinValue, -1, 0, 121, 340, Int32.MaxValue };
      long result;
      foreach (int number in numbers)
      {
         result = Convert.ToInt64(number);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                           number.GetType().Name, number,
                           result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the Int32 value -2147483648 to the Int64 value -2147483648.
      //    Converted the Int32 value -1 to the Int64 value -1.
      //    Converted the Int32 value 0 to the Int64 value 0.
      //    Converted the Int32 value 121 to the Int64 value 121.
      //    Converted the Int32 value 340 to the Int64 value 340.
      //    Converted the Int32 value 2147483647 to the Int64 value 2147483647.