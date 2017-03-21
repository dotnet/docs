   array<Byte>^ bytes = gcnew array<Byte> {0, 1, 14, 168, 255};
   for each (Byte byteValue in bytes)
      Console::WriteLine(byteValue);
   // The example displays the following output to the console if the current
   // culture is en-US:
   //       0
   //       1
   //       14
   //       168
   //       255