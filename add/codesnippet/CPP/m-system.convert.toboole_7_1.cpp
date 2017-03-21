   array<Byte>^ bytes = gcnew array<Byte> { Byte::MinValue, 100, 200, Byte::MaxValue };
   bool result;
      
   for each (Byte byteValue in bytes)
   {
      result = Convert::ToBoolean(byteValue); 
      Console::WriteLine("{0,-5}  -->  {1}", byteValue, result);
   }           
   // The example displays the following output:
   //       0      -->  False
   //       100    -->  True
   //       200    -->  True
   //       255    -->  True