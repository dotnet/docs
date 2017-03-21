      object[] values = { true, 'a', 123, 1.764e32, "9.78", "1e-02",
                          1.67e03, "A100", "1,033.67", DateTime.Now,
                          Decimal.MaxValue };   
      float result;
      
      foreach (object value in values)
      {
         try {
            result = Convert.ToSingle(value);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              value.GetType().Name, value, 
                              result.GetType().Name, result);
         }
         catch (FormatException) {
            Console.WriteLine("The {0} value {1} is not recognized as a valid Single value.",
                              value.GetType().Name, value);
         }                     
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the Single type.",
                              value.GetType().Name, value);
         }
         catch (InvalidCastException) {
            Console.WriteLine("Conversion of the {0} value {1} to a Single is not supported.",
                              value.GetType().Name, value);
         }                     
      }
      // The example displays the following output:
      //    Converted the Boolean value 'True' to the Single value 1.
      //    Conversion of the Char value a to a Single is not supported.
      //    Converted the Int32 value '123' to the Single value 123.
      //    Converted the Double value '1.764E+32' to the Single value 1.764E+32.
      //    Converted the String value '9.78' to the Single value 9.78.
      //    Converted the String value '1e-02' to the Single value 0.01.
      //    Converted the Double value '1670' to the Single value 1670.
      //    The String value A100 is not recognized as a valid Single value.
      //    Converted the String value '1,033.67' to the Single value 1033.67.
      //    Conversion of the DateTime value 11/7/2008 08:02:35 AM to a Single is not supported.
      //    Converted the Decimal value '79228162514264337593543950335' to the Single value 7.922816E+28.