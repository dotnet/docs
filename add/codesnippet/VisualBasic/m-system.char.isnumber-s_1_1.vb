      Dim utf32 As Integer = &h10107      ' AEGEAN NUMBER ONE
      Dim surrogate As String = Char.ConvertFromUtf32(utf32)
      For ctr As Integer = 0 To surrogate.Length - 1
         Console.WriteLine("U+{0:X4} at position {1}: {2}", 
                           Convert.ToUInt16(surrogate(ctr)), ctr,  
                           Char.IsNumber(surrogate, ctr))
      Next
      ' The example displays the following output:
      '       U+D800 at position 0: True
      '       U+DD07 at position 1: False