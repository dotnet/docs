' Visual Basic .NET Document
Option Strict On

Module modMain
   Public Sub Main()
      ' <Snippet1>
      Dim time1 As New TimeSpan(1, 0, 0, 0)   ' TimeSpan equivalent to 1 day.
      Dim time2 As New TimeSpan(12, 0, 0)     ' TimeSpan equivalent to 1/2 day.
      Dim time3 As TimeSpan = time1 + time2   ' Add the two time spans.
      
      Console.WriteLine("  {0,12}{3} +  {1,10}{3}   {4}{3}    {2,10}", _
                        time1, time2, time3, vbCrLf, New String("_"c, 10))
      ' The example displays the following output:
      '           1.00:00:00
      '        +    12:00:00
      '          __________
      '           1.12:00:00
      ' </Snippet1>
   End Sub
End Module

