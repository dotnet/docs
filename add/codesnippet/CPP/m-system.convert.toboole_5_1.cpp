      array<UInt64>^ numbers = gcnew array<UInt64> { UInt64::MinValue, 6121, 403890774, UInt64::MaxValue };
      bool result;
      
      for each (UInt64 number in numbers)
      {
         result = Convert::ToBoolean(number);                                 
         Console::WriteLine("{0,-26:N0}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       0                           -->  False
      //       6,121                       -->  True
      //       403,890,774                 -->  True
      //       18,446,744,073,709,551,615  -->  True