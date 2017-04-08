' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module DateArithmetic
   Public Sub Main()
      Dim date1, date2 As Date
      Dim dateOffset1, dateOffset2 As DateTimeOffset
      Dim difference As TimeSpan
      
      ' Find difference between Date.Now and Date.UtcNow
      date1 = Date.Now
      date2 = Date.UtcNow
      difference = date1 - date2
      Console.WriteLine("{0} - {1} = {2}", date1, date2, difference)
      
      ' Find difference between Now and UtcNow using DateTimeOffset
      dateOffset1 = date.Now
      dateOffset2 = date.UtcNow
      difference = dateOffset1 - dateOffset2
      Console.WriteLine("{0} - {1} = {2}", _
                        dateOffset1, dateOffset2, difference)
      ' If run in the Pacific Standard time zone on 4/2/2007, the example
      ' displays the following output to the console:
      '    4/2/2007 7:23:57 PM - 4/3/2007 2:23:57 AM = -07:00:00
      '    4/2/2007 7:23:57 PM -07:00 - 4/3/2007 2:23:57 AM +00:00 = 00:00:00                        
   End Sub
End Module
' </Snippet1>

