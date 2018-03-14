' This example demonstrates StringBuilder.Replace()
'<snippet1>
Imports System
Imports System.Text

Class Sample
   Public Shared Sub Main()
      '                    0----+----1----+----2----+----3----+----4---
      '                    01234567890123456789012345678901234567890123
      Dim str As String = "The quick br!wn d#g jumps #ver the lazy cat."
      Dim sb As New StringBuilder(str)
      
      Console.WriteLine()
      Console.WriteLine("StringBuilder.Replace method")
      Console.WriteLine()
      
      Console.WriteLine("Original value:")
      Show(sb)
      
      sb.Replace("#"c, "!"c, 15, 29)   ' Some '#' -> '!'
      Show(sb)
      sb.Replace("!"c, "o"c)           ' All '!' -> 'o'
      Show(sb)
      sb.Replace("cat", "dog")         ' All "cat" -> "dog"
      Show(sb)
      sb.Replace("dog", "fox", 15, 20) ' Some "dog" -> "fox"
      Console.WriteLine("Final value:")
      Show(sb)
   End Sub 'Main
   
   Public Shared Sub Show(sbs As StringBuilder)
      Dim rule1 As String = "0----+----1----+----2----+----3----+----4---"
      Dim rule2 As String = "01234567890123456789012345678901234567890123"
      
      Console.WriteLine(rule1)
      Console.WriteLine(rule2)
      Console.WriteLine("{0}", sbs.ToString())
      Console.WriteLine()
   End Sub 'Show
End Class 'Sample
'
'This example produces the following results:
'
'StringBuilder.Replace method
'
'Original value:
'0----+----1----+----2----+----3----+----4---
'01234567890123456789012345678901234567890123
'The quick br!wn d#g jumps #ver the lazy cat.
'
'0----+----1----+----2----+----3----+----4---
'01234567890123456789012345678901234567890123
'The quick br!wn d!g jumps !ver the lazy cat.
'
'0----+----1----+----2----+----3----+----4---
'01234567890123456789012345678901234567890123
'The quick brown dog jumps over the lazy cat.
'
'0----+----1----+----2----+----3----+----4---
'01234567890123456789012345678901234567890123
'The quick brown dog jumps over the lazy dog.
'
'Final value:
'0----+----1----+----2----+----3----+----4---
'01234567890123456789012345678901234567890123
'The quick brown fox jumps over the lazy dog.
'
'</snippet1>