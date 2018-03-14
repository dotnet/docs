' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim dateFormat As String = "MM/dd/yyyy hh:mm:ss"
      Dim date1 As Date = #09/08/2014 16:00#
      Console.WriteLine("Original date: {0} ({1:N0} ticks)", _
                        date1.ToString(dateFormat), date1.Ticks)
      Console.WriteLine()
      
      Dim date2 As Date = date1.AddSeconds(30)
      Console.WriteLine("Second date:   {0} ({1:N0} ticks)", _
                        date2.ToString(dateFormat), date2.Ticks)
      Console.WriteLine("Difference between dates: {0} ({1:N0} ticks)", _
                        date2 - date1, date2.Ticks - date1.Ticks)                        
      Console.WriteLine()
      
      ' Add 1 day's worth of seconds (60 secs. * 60 mins * 24 hrs.
      Dim date3 As Date = date1.AddSeconds(60 * 60 * 24)
      Console.WriteLine("Third date:    {0} ({1:N0} ticks)", _
                        date3.ToString(dateFormat), date3.Ticks)
      Console.WriteLine("Difference between dates: {0} ({1:N0} ticks)", _
                        date3 - date1, date3.Ticks - date1.Ticks)                        
   End Sub
End Module
' The example displays the following output:
'    Original date: 09/08/2014 04:00:00 (635,457,888,000,000,000 ticks)
'
'    Second date:   09/08/2014 04:00:30 (635,457,888,300,000,000 ticks)
'    Difference between dates: 00:00:30 (300,000,000 ticks)
'
'    Third date:    09/09/2014 04:00:00 (635,458,752,000,000,000 ticks)
'    Difference between dates: 1.00:00:00 (864,000,000,000 ticks)
' </Snippet1>

