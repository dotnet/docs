      string[] values= { "-1,035.77219", "1AFF", "1e-35", "1.63f",
                         "1,635,592,999,999,999,999,999,999", "-17.455", 
                         "190.34001", "1.29e325"};
      float result;
      
      foreach (string value in values)
      {
         try {
            result = Convert.ToSingle(value);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              value.GetType().Name, value, 
                              result.GetType().Name, result);
         }   
         catch (FormatException) {
            Console.WriteLine("Unable to convert '{0}' to a Single.", value);
         }               
         catch (OverflowException) {
            Console.WriteLine("'{0}' is outside the range of a Single.", value);
         }
      }       
      // The example displays the following output:
      //    Converted the String value '-1,035.77219' to the Single value -1035.772.
      //    Unable to convert '1AFF' to a Single.
      //    Converted the String value '1e-35' to the Single value 1E-35.
      //    Unable to convert '1.63f' to a Single.
      //    Converted the String value '1,635,592,999,999,999,999,999,999' to the Single value 1.635593E+24.
      //    Converted the String value '-17.455' to the Single value -17.455.
      //    Converted the String value '190.34001' to the Single value 190.34.
      //    1.29e325' is outside the range of a Single.