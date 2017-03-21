      long[] numbers = { Int64.MinValue, -903, 0, 172, Int64.MaxValue};
      double result;
      
      foreach (long number in numbers)
      {
         result = Convert.ToDouble(number);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                           number.GetType().Name, number, 
                           result.GetType().Name, result);

      }
      // The example displays the following output:
      //    Converted the Int64 value '-9223372036854775808' to the Single value -9.223372E+18.
      //    Converted the Int64 value '-903' to the Single value -903.
      //    Converted the Int64 value '0' to the Single value 0.
      //    Converted the Int64 value '172' to the Single value 172.
      //    Converted the Int64 value '9223372036854775807' to the Single value 9.223372E+18.