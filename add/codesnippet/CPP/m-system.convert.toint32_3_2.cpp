   __int64 sourceNumber2 = (static_cast<__int64>(int::MaxValue)) + 1;
   bool isNegative = Math::Sign(sourceNumber2) == -1;
   String^ value2 = Convert::ToString(sourceNumber2, 16);
   int targetNumber;
   try {
      targetNumber = Convert::ToInt32(value2, 16);
      if (!(isNegative) & (targetNumber & 0x80000000) != 0)
         throw gcnew OverflowException();
      else
         Console::WriteLine("0x{0} converts to {1}.", value2, targetNumber);
   }
   catch (OverflowException ^e) {
      Console::WriteLine("Unable to convert '0x{0}' to an integer.", value2);
   }
   // The example displays the following output:
   //       Unable to convert '0x80000000' to an integer.