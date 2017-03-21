      Dim utf32 As Integer = &h10380       ' UGARITIC LETTER ALPA
      Dim surrogate As String = Char.ConvertFromUtf32(utf32)
      For Each ch In surrogate
         Console.WriteLine("U+{0:X4}: {1:G}", 
                           Convert.ToUInt16(ch), 
                           System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch))
      Next
      ' The example displays the following output:
      '       U+D800: Surrogate
      '       U+DF80: Surrogate