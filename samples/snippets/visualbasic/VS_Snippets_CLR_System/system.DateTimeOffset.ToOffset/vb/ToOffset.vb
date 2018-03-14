' Visual Basic .NET Document
Option Strict On
' <Snippet1>
Module DateTimeOffsetConversion
   Private sourceTime As New DateTimeOffset(#9/1/2007 9:30AM#, _
                                            New TimeSpan(-5, 0, 0))
   
   Public Sub Main()
      Dim targetTime As DateTimeOffset
      
      ' Convert to same time (return sourceTime unchanged)
      targetTime = sourceTime.ToOffset(New TimeSpan(-5, 0, 0))
      ShowDateAndTimeInfo(targetTime)
      
      ' Convert to UTC (0 offset)
      targetTime = sourceTime.ToOffset(TimeSpan.Zero)
      ShowDateAndTimeInfo(targetTime)
      
      ' Convert to 8 hours behind UTC
      targetTime = sourceTime.ToOffset(New TimeSpan(-8, 0, 0))
      ShowDateAndTimeInfo(targetTime)
      
      ' Convert to 3 hours ahead of UTC
      targetTime = sourceTime.ToOffset(New TimeSpan(3, 0, 0))
      ShowDateAndTimeInfo(targetTime)
   End Sub
   
   Private Sub ShowDateAndTimeInfo(newTime As DateTimeOffset)
      Console.WriteLine("{0} converts to {1}", sourceTime, newTime)
      Console.WriteLine("{0} and {1} are equal: {2}", _
                        sourceTime, newTime, sourceTime.Equals(newTime))
      Console.WriteLine("{0} and {1} are identical: {2}", _
                        sourceTime, newTime, _
                        sourceTime.EqualsExact(newTime)) 
      Console.WriteLine()
   End Sub
End Module
'
' The example displays the following output:
'    9/1/2007 9:30:00 AM -05:00 converts to 9/1/2007 9:30:00 AM -05:00
'    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 9:30:00 AM -05:00 are equal: True
'    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 9:30:00 AM -05:00 are identical: True
'    
'    9/1/2007 9:30:00 AM -05:00 converts to 9/1/2007 2:30:00 PM +00:00
'    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 2:30:00 PM +00:00 are equal: True
'    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 2:30:00 PM +00:00 are identical: False
'    
'    9/1/2007 9:30:00 AM -05:00 converts to 9/1/2007 6:30:00 AM -08:00
'    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 6:30:00 AM -08:00 are equal: True
'    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 6:30:00 AM -08:00 are identical: False
'    
'    9/1/2007 9:30:00 AM -05:00 converts to 9/1/2007 5:30:00 PM +03:00
'    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 5:30:00 PM +03:00 are equal: True
'    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 5:30:00 PM +03:00 are identical: False
' </Snippet1>
