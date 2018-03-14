'<snippet1>
' Sample for String.LastIndexOfAny(Char[], Int32, Int32)
Imports System
 _

Class Sample
   
   Public Shared Sub Main()
      
      Dim br1 As String = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-"
      Dim br2 As String = "0123456789012345678901234567890123456789012345678901234567890123456"
      Dim str As String = "Now is the time for all good men to come to the aid of their party."
      Dim start As Integer
      Dim at As Integer
      Dim count As Integer
      Dim target As String = "aid"
      Dim anyOf As Char() = target.ToCharArray()
      
      start =(str.Length - 1) * 2 / 3
      count =(str.Length - 1) / 3
      Console.WriteLine("The last character occurrence from position {0} for {1} characters.", start, count)
      Console.WriteLine("{1}{0}{2}{0}{3}{0}", Environment.NewLine, br1, br2, str)
      Console.Write("A character in '{0}' occurs at position: ", target)
      
      at = str.LastIndexOfAny(anyOf, start, count)
      If at > - 1 Then
         Console.Write(at)
      Else
         Console.Write("(not found)")
      End If
      Console.Write("{0}{0}{0}", Environment.NewLine)
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'The last character occurrence from position 44 for 22 characters.
'0----+----1----+----2----+----3----+----4----+----5----+----6----+-
'0123456789012345678901234567890123456789012345678901234567890123456
'Now is the time for all good men to come to the aid of their party.
'
'A character in 'aid' occurs at position: 27
'
'</snippet1>