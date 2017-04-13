' Char.IsSeparator() example
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      For ctr As Integer = Convert.ToInt32(Char.MinValue) To Convert.ToInt32(Char.MaxValue)
         Dim ch As Char = ChrW(ctr)
         If Char.IsSeparator(ch) Then
            Console.WriteLine("\u{0:X4} ({1})", AscW(ch), Char.GetUnicodeCategory(ch).ToString())
         End If
      Next
   End Sub
End Module
' The example displays the following output:
'       \u0020 (SpaceSeparator)
'       \u00A0 (SpaceSeparator)
'       \u1680 (SpaceSeparator)
'       \u180E (SpaceSeparator)
'       \u2000 (SpaceSeparator)
'       \u2001 (SpaceSeparator)
'       \u2002 (SpaceSeparator)
'       \u2003 (SpaceSeparator)
'       \u2004 (SpaceSeparator)
'       \u2005 (SpaceSeparator)
'       \u2006 (SpaceSeparator)
'       \u2007 (SpaceSeparator)
'       \u2008 (SpaceSeparator)
'       \u2009 (SpaceSeparator)
'       \u200A (SpaceSeparator)
'       \u2028 (LineSeparator)
'       \u2029 (ParagraphSeparator)
'       \u202F (SpaceSeparator)
'       \u205F (SpaceSeparator)
'       \u3000 (SpaceSeparator)
' </Snippet1>
