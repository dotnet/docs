   array<int>^ numbers = gcnew array<int> { Int32::MinValue, -201649, -68, 0, 612, 4038907, 
                                            Int32::MaxValue };
   bool result;
      
   for each (int number in numbers)
   {
      result = Convert::ToBoolean(number);                                 
      Console::WriteLine("{0,-15:N0}  -->  {1}", number, result);
   }
   // The example displays the following output:
   //       -2,147,483,648   -->  True
   //       -201,649         -->  True
   //       -68              -->  True
   //       0                -->  False
   //       612              -->  True
   //       4,038,907        -->  True
   //       2,147,483,647    -->  True