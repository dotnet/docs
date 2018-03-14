'<snippet1>
' Sample for String.IndexOf(String, Int32, Int32)
Imports System

Class Sample
   
   Public Shared Sub Main()
      
      Dim br1 As String = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-"
      Dim br2 As String = "0123456789012345678901234567890123456789012345678901234567890123456"
      Dim str As String = "Now is the time for all good men to come to the aid of their party."
      Dim start As Integer
      Dim at As Integer
      Dim [end] As Integer
      Dim count As Integer
      
      [end] = str.Length
      start = [end] / 2
      Console.WriteLine()
      Console.WriteLine("All occurrences of 'he' from position {0} to {1}.", start, [end] - 1)
      Console.WriteLine("{1}{0}{2}{0}{3}{0}", Environment.NewLine, br1, br2, str)
      Console.Write("The string 'he' occurs at position(s): ")
      
      count = 0
      at = 0
      While start <= [end] AndAlso at > - 1
         ' start+count must be a position within -str-.
         count = [end] - start
         at = str.IndexOf("he", start, count)
         If at = - 1 Then
            Exit While
         End If
         Console.Write("{0} ", at)
         start = at + 1
      End While
      Console.WriteLine()
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'All occurrences of 'he' from position 33 to 66.
'0----+----1----+----2----+----3----+----4----+----5----+----6----+-
'0123456789012345678901234567890123456789012345678901234567890123456
'Now is the time for all good men to come to the aid of their party.
'
'The string 'he' occurs at position(s): 45 56
'
'
'</snippet1>