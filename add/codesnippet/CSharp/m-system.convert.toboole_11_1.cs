      decimal[] numbers = { Decimal.MinValue, -12034.87m, -100m, 0m, 
                                   300m, 6790823.45m, Decimal.MaxValue };
      bool result;
      
      foreach (decimal number in numbers)
      {
         result = Convert.ToBoolean(number); 
         Console.WriteLine("{0,-30}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       -79228162514264337593543950335  -->  True
      //       -12034.87                       -->  True
      //       -100                            -->  True
      //       0                               -->  False
      //       300                             -->  True
      //       6790823.45                      -->  True
      //       79228162514264337593543950335   -->  True