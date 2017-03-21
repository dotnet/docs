      Dim utf32 As Integer = &h10107       ' AEGEAN NUMBER ONE
      Dim surrogate As String = Char.ConvertFromUtf32(utf32)
      For Each ch In surrogate
         Console.WriteLine("U+{0:X4}: {1}    ", Convert.ToUInt16(ch), 
                           System.Globalization.CharUnicodeInfo.GetNumericValue(ch))
      Next
      ' The example displays the following output:
      '       U+D800: -1
      '       U+DD07: -1