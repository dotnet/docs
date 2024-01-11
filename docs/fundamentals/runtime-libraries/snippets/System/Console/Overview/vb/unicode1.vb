' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      ' Create a Char array for the modern Cyrillic alphabet, 
      ' from U+0410 to U+044F.
      Dim nChars As Integer = &h44F - &h0410
      Dim chars(nChars) As Char
      Dim codePoint As UInt16 = &h0410
      For ctr As Integer = 0 To chars.Length - 1
        chars(ctr) = ChrW(codePoint)
        codePoint += CType(1, UShort)
      Next   
         
      Console.WriteLine("Current code page: {0}", 
                        Console.OutputEncoding.CodePage)
      Console.WriteLine()
      ' Display the characters.
      For Each ch In chars
         Console.Write("{0}  ", ch)
         If Console.CursorLeft >= 70 Then Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'       Current code page: 437
'       
'       ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?
'       ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?
'       ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?
' </Snippet1> 
