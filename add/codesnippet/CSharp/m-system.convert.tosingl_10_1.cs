      decimal[] values = { Decimal.MinValue, -1034.23m, -12m, 0m, 147m, 
                                  199.55m, 9214.16m, Decimal.MaxValue };
      float result;
      
      foreach (float value in values)
      {
         result = Convert.ToSingle(value);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                           value.GetType().Name, value,
                           result.GetType().Name, result);
      }                                  
      // The example displays the following output:
      //    Converted the Decimal value '-79228162514264337593543950335' to the Single value -7.922816E+28.
      //    Converted the Decimal value '-1034.23' to the Single value -1034.23.
      //    Converted the Decimal value '-12' to the Single value -12.
      //    Converted the Decimal value '0' to the Single value 0.
      //    Converted the Decimal value '147' to the Single value 147.
      //    Converted the Decimal value '199.55' to the Single value 199.55.
      //    Converted the Decimal value '9214.16' to the Single value 9214.16.
      //    Converted the Decimal value '79228162514264337593543950335' to the Single value 7.922816E+28.