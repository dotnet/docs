' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Module CompareTimes
   Private Enum TimeComparison As Integer
      Earlier = -1
      Same = 0
      Later = 1
   End Enum
      
   Public Sub Main()
      Dim firstTime As New DateTimeOffset(#09/01/2007 6:45:00AM#, _
                       New TimeSpan(-7, 0, 0))
  
      Dim secondTime As DateTimeOffset = firstTime
      Console.WriteLine("Comparing {0} and {1}: {2}", _
                        firstTime, secondTime, _
                        CType(DateTimeOffset.Compare(firstTime, secondTime), _
                              TimeComparison))

      secondTime = New DateTimeOffset(#09/01/2007 6:45:00AM#, _
                       New TimeSpan(-6, 0, 0))      
      Console.WriteLine("Comparing {0} and {1}: {2}", _
                       firstTime, secondTime, _
                       CType(DateTimeOffset.Compare(firstTime, secondTime), _
                             TimeComparison))
      
      secondTime = New DateTimeOffset(#09/01/2007 8:45:00AM#, _
                       New TimeSpan(-5, 0, 0))
      Console.WriteLine("Comparing {0} and {1}: {2}", _
                       firstTime, secondTime, _
                       CType(DateTimeOffset.Compare(firstTime, secondTime), _
                             TimeComparison))
      ' The example displays the following output to the console:
      '       Comparing 9/1/2007 6:45:00 AM -07:00 and 9/1/2007 6:45:00 AM -07:00: Same
      '       Comparing 9/1/2007 6:45:00 AM -07:00 and 9/1/2007 6:45:00 AM -06:00: Later
      '       Comparing 9/1/2007 6:45:00 AM -07:00 and 9/1/2007 8:45:00 AM -05:00: Same      
   End Sub
End Module
' </Snippet7>

