      int utf32 = 0x10380;       // UGARITIC LETTER ALPA
      string surrogate = Char.ConvertFromUtf32(utf32);
      foreach (var ch in surrogate)
         Console.WriteLine("U+{0:X4}: {1:G}", 
                           Convert.ToUInt16(ch), 
                           System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch));
      // The example displays the following output:
      //       U+D800: Surrogate
      //       U+DF80: Surrogate