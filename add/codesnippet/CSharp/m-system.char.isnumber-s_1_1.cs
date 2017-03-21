      int utf32 = 0x10107;      // AEGEAN NUMBER ONE
      string surrogate = Char.ConvertFromUtf32(utf32);
      for (int ctr = 0; ctr < surrogate.Length; ctr++)
         Console.WriteLine("U+{0:X4} at position {1}: {2}", 
                           Convert.ToUInt16(surrogate[ctr]), ctr,  
                           Char.IsNumber(surrogate, ctr));
      // The example displays the following output:
      //       U+D800 at position 0: True
      //       U+DD07 at position 1: False