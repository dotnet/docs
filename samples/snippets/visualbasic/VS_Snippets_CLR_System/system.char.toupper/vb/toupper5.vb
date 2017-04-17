' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim cultures() As CultureInfo = { CultureInfo.CreateSpecificCulture("en-US"), 
                                        CultureInfo.InvariantCulture, 
                                        CultureInfo.CreateSpecificCulture("tr-TR") }
      Dim chars() As Char = {"ä"c, "e"c, "E"c, "i"c, "I"c }

      Console.WriteLine("Character     en-US     Invariant     tr-TR")
      For Each ch In chars
         Console.Write("    {0}", ch)
         For Each culture In cultures
            Console.Write("{0,12}", Char.ToUpper(ch, culture))
         Next
         Console.WriteLine()
      Next   
   End Sub
End Module
' The example displays the following output:
'       Character     en-US     Invariant     tr-TR
'           ä           Ä           Ä           Ä
'           e           E           E           E
'           E           E           E           E
'           i           I           I           İ
'           I           I           I           I    
' </Snippet2>
