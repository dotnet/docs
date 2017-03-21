      sbyte[] numbers = { SByte.MinValue, -23, 0, 17, SByte.MaxValue };
      float result;
      
      foreach (sbyte number in numbers)
      {
         result = Convert.ToSingle(number);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                           number.GetType().Name, number, 
                           result.GetType().Name, result);

      }
      // The example displays the following output:
      //    Converted the SByte value '-128' to the Single value -128.
      //    Converted the SByte value '-23' to the Single value -23.
      //    Converted the SByte value '0' to the Single value 0.
      //    Converted the SByte value '17' to the Single value 17.
      //    Converted the SByte value '127' to the Single value 127.