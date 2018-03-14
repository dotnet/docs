' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim dat As Date = Date.Now
      Console.WriteLine("The time: {0:d} at {0:t}", dat)
      Dim tz As TimeZoneInfo = TimeZoneInfo.Local
      Console.WriteLine("The time zone: {0}", 
                        If(tz.IsDaylightSavingTime(dat),
                           tz.DaylightName, tz.StandardName))
      Console.WriteLine()
      Console.Write("Press <Enter> to exit... ")
      Do While Console.ReadKey(True).Key <> ConsoleKey.Enter
      Loop
   End Sub
End Module
' The example displays the following output:
'     The time: 11/11/2015 at 4:02 PM
'     The time zone: Pacific Standard Time
' </Snippet2>
