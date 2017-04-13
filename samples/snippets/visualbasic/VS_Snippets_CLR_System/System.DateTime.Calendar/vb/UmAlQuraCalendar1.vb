' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim faIR As New CultureInfo("fa-IR")
      Dim value As New DateTime(2016, 5, 28)

      Console.WriteLine(value.ToString(faIR))

      faIR.DateTimeFormat.Calendar = New GregorianCalendar()
      Console.WriteLine(value.ToString(faIR))
   End Sub
End Module
' The example displays the following output:
'       08/03/1395 12:00:00 ?.?
'       28/05/2016 12:00:00 ?.?
' </Snippet1>
