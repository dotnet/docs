      int utf32 = 0x10107;      // AEGEAN NUMBER ONE
      string surrogate = Char.ConvertFromUtf32(utf32);
      foreach (var ch in surrogate)
         Console.WriteLine("U+{0:X4}: {1}", Convert.ToUInt16(ch), 
                                          Char.IsNumber(ch));

      // The example displays the following output:
      //       U+D800: False
      //       U+DD07: False       