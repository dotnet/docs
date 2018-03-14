' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim chars() As Char = { "e"c, "E"c, "6"c, ","c, "ж"c, "ä"c }
      For Each ch In chars
         Console.WriteLine("{0} --> {1} {2}", ch, Char.ToUpper(ch),
                           If(ch = Char.ToUpper(ch), "(Same Character)", ""))
      Next
   End Sub
End Module
' The example displays the following output:
'       e --> E
'       E --> E (Same Character)
'       6 --> 6 (Same Character)
'       , --> , (Same Character)
'       ж --> Ж
'       ä --> Ä
' </Snippet1>
