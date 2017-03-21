      float[] numbers = { Single.MinValue, -193.0012f, 20e-15f, 0f, 
                          10551e-10f, 100.3398f, Single.MaxValue };
      bool result;
      
      foreach (float number in numbers)
      {
         result = Convert.ToBoolean(number);                                 
         Console.WriteLine("{0,-15}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       -3.402823E+38    -->  True
      //       -193.0012        -->  True
      //       2E-14            -->  True
      //       0                -->  False
      //       1.0551E-06       -->  True
      //       100.3398         -->  True
      //       3.402823E+38     -->  True