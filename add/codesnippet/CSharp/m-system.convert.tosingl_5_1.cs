      double[] values = { Double.MinValue, -1.38e10, -1023.299, -12.98, 
                          0, 9.113e-16, 103.919, 17834.191, Double.MaxValue };
      float result;
      
      foreach (double value in values)
      {
         result = Convert.ToSingle(value);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                           value.GetType().Name, value, 
                           result.GetType().Name, result);
      }                                 
      // The example displays the following output:
      //    Converted the Double value '-1.79769313486232E+308' to the Single value -Infinity.
      //    Converted the Double value '-13800000000' to the Single value -1.38E+10.
      //    Converted the Double value '-1023.299' to the Single value -1023.299.
      //    Converted the Double value '-12.98' to the Single value -12.98.
      //    Converted the Double value '0' to the Single value 0.
      //   Converted the Double value '9.113E-16' to the Single value 9.113E-16.
      //    Converted the Double value '103.919' to the Single value 103.919.
      //    Converted the Double value '17834.191' to the Single value 17834.19.
      //    Converted the Double value '1.79769313486232E+308' to the Single value Infinity.