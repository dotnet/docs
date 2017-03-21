      float[] values = { Single.MinValue, -1.38e10f, -1023.299f, -12.98f,
                         0f, 9.113e-16f, 103.919f, 17834.191f, Single.MaxValue };
      short result;
      
      foreach (float value in values)
      {
         try {
            result = Convert.ToInt16(value);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              value.GetType().Name, value, result.GetType().Name, result);
         }                     
         catch (OverflowException) {
            Console.WriteLine("{0} is outside the range of the Int16 type.", value);
         }   
      }                                 
      // The example displays the following output:
      //    -3.40282346638529E+38 is outside the range of the Int16 type.
      //    -13799999488 is outside the range of the Int16 type.
      //    Converted the Double value -1023.29901123047 to the Int16 value -1023.
      //    Converted the Double value -12.9799995422363 to the Int16 value -13.
      //    Converted the Double value 0 to the Int16 value 0.
      //    Converted the Double value 9.11299983940444E-16 to the Int16 value 0.
      //    Converted the Double value 103.918998718262 to the Int16 value 104.
      //    Converted the Double value 17834.19140625 to the Int16 value 17834.
      //    3.40282346638529E+38 is outside the range of the Int16 type.