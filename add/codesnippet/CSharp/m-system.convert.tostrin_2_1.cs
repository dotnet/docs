      float[] numbers = { Single.MinValue, -1011.351f, -17.45f, -3e-16f,
                          0f, 4.56e-12f, 16.0001f, 10345.1221f, Single.MaxValue };
      string result;
      
      foreach (float number in numbers)
      {
         result = Convert.ToString(number);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
      }                            
      // The example displays the following output:
      //    Converted the Single value -3.402823E+38 to the String value -3.402823E+38.
      //    Converted the Single value -1011.351 to the String value -1011.351.
      //    Converted the Single value -17.45 to the String value -17.45.
      //    Converted the Single value -3E-16 to the String value -3E-16.
      //    Converted the Single value 0 to the String value 0.
      //    Converted the Single value 4.56E-12 to the String value 4.56E-12.
      //    Converted the Single value 16.0001 to the String value 16.0001.
      //    Converted the Single value 10345.12 to the String value 10345.12.
      //    Converted the Single value 3.402823E+38 to the String value 3.402823E+38.