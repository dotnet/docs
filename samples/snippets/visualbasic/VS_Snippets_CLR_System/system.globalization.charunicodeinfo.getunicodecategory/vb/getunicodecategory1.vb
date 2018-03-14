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
      ' </Snippet1>
   End Sub
   
   Private Sub Overload2()
      ' <Snippet2>
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
      ' </Snippet2>
   End Sub   
End Module
