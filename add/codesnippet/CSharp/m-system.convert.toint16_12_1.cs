      double[] values = { Double.MinValue, -1.38e10, -1023.299, -12.98,
                          0, 9.113e-16, 103.919, 17834.191, Double.MaxValue };
      short result;
      
      foreach (double value in values)
      {
         try {
            result = Convert.ToInt16(value);
            Console.WriteLine("Converted {0} to {1}.", value, result);
         }   
         catch (OverflowException)
         {
            Console.WriteLine("{0} is outside the range of the Int16 type.", value);
         }   
      }                                 
      //       -1.79769313486232E+308 is outside the range of the Int16 type.
      //       -13800000000 is outside the range of the Int16 type.
      //       Converted -1023.299 to -1023.
      //       Converted -12.98 to -13.
      //       Converted 0 to 0.
      //       Converted 9.113E-16 to 0.
      //       Converted 103.919 to 104.
      //       Converted 17834.191 to 17834.
      //       1.79769313486232E+308 is outside the range of the Int16 type.