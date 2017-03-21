   // Create a hexadecimal value out of range of the integer type. 
   String^ value1 = Convert::ToString((static_cast<__int64>(int::MaxValue)) + 1, 16);
   // Convert it back to a number.
   try {
      int number = Convert::ToInt32(value1, 16);
      Console::WriteLine("0x{0} converts to {1}.", value1, number);
   }
   catch (OverflowException ^e) {
      Console::WriteLine("Unable to convert '0x{0}' to an integer.", value1);
   }
   // The example displays the following output:
   //      0x80000000 converts to -2147483648.