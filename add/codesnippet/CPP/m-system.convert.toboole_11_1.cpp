      array<Decimal>^ numbers = gcnew array<Decimal> { Decimal::MinValue, (Decimal) -12034.87, 
                                                       (Decimal) -100, (Decimal) 0, (Decimal) 300, 
                                                       (Decimal) 6790823.45, Decimal::MaxValue };
      bool result;
      
      for each (Decimal number in numbers)
      {
         result = Convert::ToBoolean(number); 
         Console::WriteLine("{0,-30}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       -79228162514264337593543950335  -->  True
      //       -12034.87                       -->  True
      //       -100                            -->  True
      //       0                               -->  False
      //       300                             -->  True
      //       6790823.45                      -->  True
      //       79228162514264337593543950335   -->  True