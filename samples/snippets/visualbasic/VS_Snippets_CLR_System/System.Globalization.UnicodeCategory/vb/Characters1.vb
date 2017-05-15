Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim ctr As Integer = 0
      Dim category As UnicodeCategory = UnicodeCategory.UppercaseLetter
      
      For codePoint As UShort = 0 To UShort.MaxValue - 1
         Dim ch As Char = Convert.ToChar(codePoint)

         If CharUnicodeInfo.GetUnicodeCategory(ch) = category Then
            If ctr Mod 5 = 0 Then Console.WriteLine()
            Console.Write("{0} (U+{1:X4})     ", ch, codePoint)
            ctr += 1
         End If 
      Next
      Console.WriteLine()
      Console.WriteLine()
      Console.WriteLine("{0} characters are in the {1:G} category", 
                        ctr, category)   
   End Sub
End Module
' </Snippet1>
