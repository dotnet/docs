' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      Overload1()
      Console.WriteLine()
      Overload2()
   End Sub
   
   Private Sub Overload1()
      ' <Snippet1>
      Dim utf32 As Integer = &h10107      ' AEGEAN NUMBER ONE
      Dim surrogate As String = Char.ConvertFromUtf32(utf32)
      For Each ch In surrogate
         Console.WriteLine("U+{0:X4}: {1}", Convert.ToUInt16(ch), 
                                          Char.IsNumber(ch))
      Next
      ' The example displays the following output:
      '       U+D800: False
      '       U+DD07: False
      '  </Snippet1>
   End Sub
   
   Private Sub Overload2()
      ' <Snippet2>
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
      '  </Snippet2>
   End Sub
End Module

