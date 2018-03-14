' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      ' Define an interval of 1 day, 15+ hours.
      Dim interval As New TimeSpan(1, 15, 42, 45, 750) 
      Console.WriteLine("Value of TimeSpan: {0}", interval)
      
      Console.WriteLine("{0:N5} seconds, as follows:", interval.TotalSeconds)
      Console.WriteLine("   Seconds:      {0,8:N0}", interval.Days * 24 * 60 * 60 + _
                                                  interval.Hours *60 * 60 + _
                                                  interval.Minutes * 60 + _
                                                  interval.Seconds)
      Console.WriteLine("   Milliseconds: {0,8}", interval.Milliseconds)
   End Sub
End Module
' The example displays the following output:
'       Value of TimeSpan: 1.15:42:45.7500000
'       142,965.75000 seconds, as follows:
'          Seconds:       142,965
'          Milliseconds:      750
' </Snippet1>
