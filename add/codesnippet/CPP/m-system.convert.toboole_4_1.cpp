   array<Int16>^ numbers = gcnew array<Int16> { Int16::MinValue, -10000, -154, 0, 216, 21453, 
                                          Int16::MaxValue };
   bool result;
      
   for each (Int16 number in numbers)
   {
      result = Convert::ToBoolean(number);                                 
      Console::WriteLine("{0,-7:N0}  -->  {1}", number, result);
   }
   // The example displays the following output:
   //       -32,768  -->  True
   //       -10,000  -->  True
   //       -154     -->  True
   //       0        -->  False
   //       216      -->  True
   //       21,453   -->  True
   //       32,767   -->  True