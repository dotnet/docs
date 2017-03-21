      int utf32 = 0x10107;       // AEGEAN NUMBER ONE
      string surrogate = Char.ConvertFromUtf32(utf32);
      foreach (var ch in surrogate)
         Console.WriteLine("U+{0:X4}: {1}    ", Convert.ToUInt16(ch), 
                           System.Globalization.CharUnicodeInfo.GetNumericValue(ch));

      // The example displays the following output:
      //       U+D800: -1
      //       U+DD07: -1