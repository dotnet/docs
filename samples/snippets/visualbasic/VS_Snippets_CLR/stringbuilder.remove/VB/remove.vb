' This example demonstrates StringBuilder.Remove()
'<snippet1>
Imports System
Imports System.Text

Class Sample
   Public Shared Sub Main()
      Dim rule1 As String = "0----+----1----+----2----+----3----+----4---"
      Dim rule2 As String = "01234567890123456789012345678901234567890123"
      Dim str As String   = "The quick brown fox jumps over the lazy dog."
      Dim sb As New StringBuilder(str)
      
      Console.WriteLine()
      Console.WriteLine("StringBuilder.Remove method")
      Console.WriteLine()
      Console.WriteLine("Original value:")
      Console.WriteLine(rule1)
      Console.WriteLine(rule2)
      Console.WriteLine("{0}", sb.ToString())
      Console.WriteLine()
      
      sb.Remove(10, 6) ' Remove "brown "

      Console.WriteLine("New value:")
      Console.WriteLine(rule1)
      Console.WriteLine(rule2)
      Console.WriteLine("{0}", sb.ToString())
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'StringBuilder.Remove method
'
'Original value:
'0----+----1----+----2----+----3----+----4---
'01234567890123456789012345678901234567890123
'The quick brown fox jumps over the lazy dog.
'
'New value:
'0----+----1----+----2----+----3----+----4---
'01234567890123456789012345678901234567890123
'The quick fox jumps over the lazy dog.
'
'</snippet1>