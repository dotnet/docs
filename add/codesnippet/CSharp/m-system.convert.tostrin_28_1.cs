      int[] bases = { 2, 8, 10, 16};
      byte[] numbers = { Byte.MinValue, 12, 103, Byte.MaxValue};
      
      foreach (int baseValue in bases)
      {
         Console.WriteLine("Base {0} conversion:", baseValue);
         foreach (byte number in numbers)
         {
            Console.WriteLine("   {0,-5}  -->  0x{1}", 
                              number, Convert.ToString(number, baseValue));
         }
      }
      // The example displays the following output:
      //       Base 2 conversion:
      //          0      -->  0x0
      //          12     -->  0x1100
      //          103    -->  0x1100111
      //          255    -->  0x11111111
      //       Base 8 conversion:
      //          0      -->  0x0
      //          12     -->  0x14
      //          103    -->  0x147
      //          255    -->  0x377
      //       Base 10 conversion:
      //          0      -->  0x0
      //          12     -->  0x12
      //          103    -->  0x103
      //          255    -->  0x255
      //       Base 16 conversion:
      //          0      -->  0x0
      //          12     -->  0xc
      //          103    -->  0x67
      //          255    -->  0xff