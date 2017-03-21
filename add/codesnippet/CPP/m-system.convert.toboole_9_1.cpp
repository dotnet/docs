   array<Int64>^ numbers = gcnew array<Int64> { Int64::MinValue, -2016493, -689, 0, 6121, 
                                              403890774, Int64::MaxValue };
   bool result;
      
   for each (Int64 number in numbers)
   {
      result = Convert::ToBoolean(number);                                 
      Console::WriteLine("{0,-26:N0}  -->  {1}", number, result);
   }
   // The example displays the following output:
   //       -9,223,372,036,854,775,808  -->  True
   //       -2,016,493                  -->  True
   //       -689                        -->  True
   //       0                           -->  False
   //       6,121                       -->  True
   //       403,890,774                 -->  True
   //       9,223,372,036,854,775,807   -->  True