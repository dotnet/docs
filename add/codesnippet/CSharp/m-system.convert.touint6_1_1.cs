      object[] values = { true, -12, 163, 935, 'x', new DateTime(2009, 5, 12),
                          "104", "103.0", "-1",
                          "1.00e2", "One", 1.00e2, 16.3e42};
      ulong result;
      
      foreach (object value in values)
      {
         try {
            result = Convert.ToUInt64(value);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              value.GetType().Name, value,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt64 type.",
                              value.GetType().Name, value);
         }                     
         catch (FormatException) {
            Console.WriteLine("The {0} value {1} is not in a recognizable format.",
                              value.GetType().Name, value);
         }
         catch (InvalidCastException) {
            Console.WriteLine("No conversion to a UInt64 exists for the {0} value {1}.",
                              value.GetType().Name, value);
                              
         }
      }                           
      // The example displays the following output:
      //    Converted the Boolean value True to the UInt64 value 1.
      //    The Int32 value -12 is outside the range of the UInt64 type.
      //    Converted the Int32 value 163 to the UInt64 value 163.
      //    Converted the Int32 value 935 to the UInt64 value 935.
      //    Converted the Char value x to the UInt64 value 120.
      //    No conversion to a UInt64 exists for the DateTime value 5/12/2009 12:00:00 AM.
      //    Converted the String value 104 to the UInt64 value 104.
      //    The String value 103.0 is not in a recognizable format.
      //    The String value -1 is outside the range of the UInt64 type.
      //    The String value 1.00e2 is not in a recognizable format.
      //    The String value One is not in a recognizable format.
      //    Converted the Double value 100 to the UInt64 value 100.
      //    The Double value 1.63E+43 is outside the range of the UInt64 type.