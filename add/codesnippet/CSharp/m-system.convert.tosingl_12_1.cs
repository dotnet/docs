      uint[] numbers = { UInt32.MinValue, 121, 12345, UInt32.MaxValue };
      float result;
      
      foreach (uint number in numbers)
      {
         result = Convert.ToSingle(number);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                           number.GetType().Name, number, 
                           result.GetType().Name, result);
      }   
      // The example displays the following output:
      //    Converted the UInt32 value '0' to the Single value 0.
      //    Converted the UInt32 value '121' to the Single value 121.
      //    Converted the UInt32 value '12345' to the Single value 12345.
      //    Converted the UInt32 value '4294967295' to the Single value 4.294967E+09.