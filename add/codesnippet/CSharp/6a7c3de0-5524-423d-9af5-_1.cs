      int utf32 = 0x10380;       // UGARITIC LETTER ALPA
      string surrogate = Char.ConvertFromUtf32(utf32);
      for (int ctr = 0; ctr < surrogate.Length; ctr++)
         Console.WriteLine("U+{0:X4}: {1:G}", 
                           Convert.ToUInt16(surrogate[ctr]), 
                           System.Globalization.CharUnicodeInfo.GetUnicodeCategory(surrogate, ctr));
      // The example displays the following output:
      //       U+D800: OtherLetter
      //       U+DF80: Surrogate      