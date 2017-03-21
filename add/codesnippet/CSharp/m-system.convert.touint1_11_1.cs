      double[] numbers = { Double.MinValue, -1.38e10, -1023.299, -12.98,
                          0, 9.113e-16, 103.919, 17834.191, Double.MaxValue };
      ushort result;
      
      foreach (double number in numbers)
      {
         try {
            result = Convert.ToUInt16(number);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              number.GetType().Name, number, 
                              result.GetType().Name, result);
         }   
         catch (OverflowException)
         {
            Console.WriteLine("{0} is outside the range of the UInt16 type.", number);
         }   
      }                                 
      // The example displays the following output:
      //    -1.79769313486232E+308 is outside the range of the UInt16 type.
      //    -13800000000 is outside the range of the UInt16 type.
      //    -1023.299 is outside the range of the UInt16 type.
      //    -12.98 is outside the range of the UInt16 type.
      //    Converted the Double value '0' to the UInt16 value 0.
      //    Converted the Double value '9.113E-16' to the UInt16 value 0.
      //    Converted the Double value '103.919' to the UInt16 value 104.
      //    Converted the Double value '17834.191' to the UInt16 value 17834.
      //    1.79769313486232E+308 is outside the range of the UInt16 type.