'<snippet1>
' This example demonstrates the Console.Read() method.
Imports System
Imports Microsoft.VisualBasic

Class Sample
   Public Shared Sub Main()
      Dim m1 As String = _
                vbCrLf & _
                "Type a string of text then press Enter. " & _
                "Type '+' anywhere in the text to quit:" & _
                vbCrLf
      Dim m2 As String = "Character '{0}' is hexadecimal 0x{1:x4}."
      Dim m3 As String = "Character     is hexadecimal 0x{0:x4}."
      Dim ch As Char
      Dim x As Integer
      '
      Console.WriteLine(m1)
      Do
         x = Console.Read()
         Try
            ch = Convert.ToChar(x)
            If Char.IsWhiteSpace(ch) Then
               Console.WriteLine(m3, x)
               If ch = vbLf Then
                  Console.WriteLine(m1)
               End If
            Else
               Console.WriteLine(m2, ch, x)
            End If
         Catch e As OverflowException
            Console.WriteLine("{0} Value read = {1}.", e.Message, x)
            ch = Char.MinValue
            Console.WriteLine(m1)
         End Try
      Loop While ch <> "+"c
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'Type a string of text then press Enter. Type '+' anywhere in the text to quit:
'
'The quick brown fox.
'Character 'T' is hexadecimal 0x0054.
'Character 'h' is hexadecimal 0x0068.
'Character 'e' is hexadecimal 0x0065.
'Character     is hexadecimal 0x0020.
'Character 'q' is hexadecimal 0x0071.
'Character 'u' is hexadecimal 0x0075.
'Character 'i' is hexadecimal 0x0069.
'Character 'c' is hexadecimal 0x0063.
'Character 'k' is hexadecimal 0x006b.
'Character     is hexadecimal 0x0020.
'Character 'b' is hexadecimal 0x0062.
'Character 'r' is hexadecimal 0x0072.
'Character 'o' is hexadecimal 0x006f.
'Character 'w' is hexadecimal 0x0077.
'Character 'n' is hexadecimal 0x006e.
'Character     is hexadecimal 0x0020.
'Character 'f' is hexadecimal 0x0066.
'Character 'o' is hexadecimal 0x006f.
'Character 'x' is hexadecimal 0x0078.
'Character '.' is hexadecimal 0x002e.
'Character     is hexadecimal 0x000d.
'Character     is hexadecimal 0x000a.
'
'Type a string of text then press Enter. Type '+' anywhere in the text to quit:
'
'^Z
'Value was either too large or too small for a character. Value read = -1.
'
'Type a string of text then press Enter. Type '+' anywhere in the text to quit:
'
'+
'Character '+' is hexadecimal 0x002b.
'
'</snippet1>