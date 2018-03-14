' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization
Imports System.Text

Module Example
   Public Sub Main()
      Dim sb As New StringBuilder()
      Dim value As Decimal = 16.95d
      Dim enGB As CultureInfo = CultureInfo.CreateSpecificCulture("en-GB")
      Dim dateToday As DateTime = Date.Now
      sb.AppendFormat(enGB, "Final Price: {0:C2}", value)
      sb.AppendLine()
      sb.AppendFormat(enGB, "Date and Time: {0:d} at {0:t}", dateToday)
      Console.WriteLine(sb.ToString())
   End Sub
End Module
' The example displays output like the following:
'       Final Price: £16.95
'       Date and Time: 01/10/2014 at 10:22
' </Snippet2>
