' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module modMain
   Public Sub Main()
      ' Get the current date.
      Dim thisDay As DateTime = DateTime.Today
      ' Display the date in the default (general) format.
      Console.WriteLine(thisDay.ToString())
      Console.WriteLine()
      ' Display the date in a variety of formats.
      Console.WriteLine(thisDay.ToString("d"))
      Console.WriteLine(thisDay.ToString("D"))
      Console.WriteLine(thisDay.ToString("g"))
   End Sub
End Module
' The example displays output similar to the following:
'    5/3/2012 12:00:00 AM
'    
'    5/3/2012
'    Thursday, May 03, 2012
'    5/3/2012 12:00 AM
' </Snippet1>


