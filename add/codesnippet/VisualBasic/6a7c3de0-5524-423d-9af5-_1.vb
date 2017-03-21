      Dim utf32 As Integer = &h10380       ' UGARITIC LETTER ALPA
      Dim surrogate As String = Char.ConvertFromUtf32(utf32)
      For ctr As Integer = 0 To surrogate.Length - 1
         Console.WriteLine("U+{0:X4}: {1:G}", 
                           Convert.ToUInt16(surrogate(ctr)), 
                           System.Globalization.CharUnicodeInfo.GetUnicodeCategory(surrogate, ctr))
      Next
      ' The example displays the following output:
      '       U+D800: OtherLetter
      '       U+DF80: Surrogate      