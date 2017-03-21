      int[] bases = { 2, 8, 10, 16};
      short[] numbers = { Int16.MinValue, -13621, -18, 12, 19142, Int16.MaxValue };
      
      foreach (int baseValue in bases)
      {
         Console.WriteLine("Base {0} conversion:", baseValue);
         foreach (short number in numbers)
         {
            Console.WriteLine("   {0,-8}  -->  0x{1}", 
                              number, Convert.ToString(number, baseValue));
         }
      }
      // The example displays the following output:
      //       Base 2 conversion:
      //          -32768    -->  0x1000000000000000
      //          -13621    -->  0x1100101011001011
      //          -18       -->  0x1111111111101110
      //          12        -->  0x1100
      //          19142     -->  0x100101011000110
      //          32767     -->  0x111111111111111
      //       Base 8 conversion:
      //          -32768    -->  0x100000
      //          -13621    -->  0x145313
      //          -18       -->  0x177756
      //          12        -->  0x14
      //          19142     -->  0x45306
      //          32767     -->  0x77777
      //       Base 10 conversion:
      //          -32768    -->  0x-32768
      //          -13621    -->  0x-13621
      //          -18       -->  0x-18
      //          12        -->  0x12
      //          19142     -->  0x19142
      //          32767     -->  0x32767
      //       Base 16 conversion:
      //          -32768    -->  0x8000
      //          -13621    -->  0xcacb
      //          -18       -->  0xffee
      //          12        -->  0xc
      //          19142     -->  0x4ac6
      //          32767     -->  0x7fff