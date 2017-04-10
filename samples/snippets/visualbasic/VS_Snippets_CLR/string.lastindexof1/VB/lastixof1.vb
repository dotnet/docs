'<snippet1>
' Sample for String.LastIndexOf(Char, Int32)
Imports System 
 _

Class Sample
   
   Public Shared Sub Main()
      
      Dim br1 As String = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-"
      Dim br2 As String = "0123456789012345678901234567890123456789012345678901234567890123456"
      Dim str As String = "Now is the time for all good men to come to the aid of their party."
      Dim start As Integer
      Dim at As Integer
      
      start = str.Length - 1
      Console.WriteLine("All occurrences of 't' from position {0} to 0.", start)
      Console.WriteLine("{1}{0}{2}{0}{3}{0}", Environment.NewLine, br1, br2, str)
      Console.Write("The letter 't' occurs at position(s): ")
      
      at = 0
      While start > - 1 And at > - 1
         at = str.LastIndexOf("t"c, start)
         If at > - 1 Then
            Console.Write("{0} ", at)
            start = at - 1
         End If
      End While
      Console.Write("{0}{0}{0}", Environment.NewLine)
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'All occurrences of 't' from position 66 to 0.
'0----+----1----+----2----+----3----+----4----+----5----+----6----+-
'0123456789012345678901234567890123456789012345678901234567890123456
'Now is the time for all good men to come to the aid of their party.
'
'The letter 't' occurs at position(s): 64 55 44 41 33 11 7
'
'</snippet1>