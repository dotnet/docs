'<snippet1>
Class Sample
   Public Shared Sub Main()
      Dim letterA As Integer = &H41    'U+00041 = LATIN CAPITAL LETTER A
      Dim music As Integer   = &H1D161 'U+1D161 = MUSICAL SYMBOL SIXTEENTH NOTE
      Dim s1 As String
      Dim comment   As String = "Create a UTF-16 encoded string from a code point."
      Dim comment1b As String = "Create a code point from a UTF-16 encoded string."
      Dim comment2b As String = "Create a code point from a surrogate pair at a certain position in a string."
      Dim comment2c As String = "Create a code point from a high surrogate and a low surrogate code point."
      
      '  Convert code point U+0041 to UTF-16. The UTF-16 equivalent of 
      '  U+0041 is a Char with hexadecimal value 0041.

      Console.WriteLine(comment)
      s1 = [Char].ConvertFromUtf32(letterA)
      Console.Write("    1a) 0x{0:X} => ", letterA)
      Show(s1)
      Console.WriteLine()
      
      '  Convert the lone UTF-16 character to a code point.

      Console.WriteLine(comment1b)
      letterA = [Char].ConvertToUtf32(s1, 0)
      Console.Write("    1b) ")
      Show(s1)
      Console.WriteLine(" => 0x{0:X}", letterA)
      Console.WriteLine()
      
      ' -------------------------------------------------------------------

      '  Convert the code point U+1D161 to UTF-16. The UTF-16 equivalent of 
      '  U+1D161 is a surrogate pair with hexadecimal values D834 and DD61.

      Console.WriteLine(comment)
      s1 = [Char].ConvertFromUtf32(music)
      Console.Write("    2a) 0x{0:X} => ", music)
      Show(s1)
      Console.WriteLine()
      
      '  Convert the surrogate pair in the string at index position 
      '  zero to a code point.

      Console.WriteLine(comment2b)
      music = [Char].ConvertToUtf32(s1, 0)
      Console.Write("    2b) ")
      Show(s1)
      Console.WriteLine(" => 0x{0:X}", music)
      
      '  Convert the high and low characters in the surrogate pair into a code point.

      Console.WriteLine(comment2c)
      music = [Char].ConvertToUtf32(s1.Chars(0), s1.Chars(1))
      Console.Write("    2c) ")
      Show(s1)
      Console.WriteLine(" => 0x{0:X}", music)
   End Sub
   
   Private Shared Sub Show(s As String)
      Dim x As Integer
      If s.Length = 0 Then Exit Sub
      For x = 0 To s.Length - 1
         Console.Write("0x{0:X}{1}", _
                        AscW(s.Chars(x)), _
                        IIf(x = s.Length - 1, [String].Empty, ", "))
      Next 
   End Sub 
End Class 
'
'This example produces the following results:
'
'Create a UTF-16 encoded string from a code point.
'    1a) 0x41 => 0x41
'Create a code point from a UTF-16 encoded string.
'    1b) 0x41 => 0x41
'
'Create a UTF-16 encoded string from a code point.
'    2a) 0x1D161 => 0xD834, 0xDD61
'Create a code point from a surrogate pair at a certain position in a string.
'    2b) 0xD834, 0xDD61 => 0x1D161
'Create a code point from a high surrogate and a low surrogate code point.
'    2c) 0xD834, 0xDD61 => 0x1D161
'
'</snippet1>