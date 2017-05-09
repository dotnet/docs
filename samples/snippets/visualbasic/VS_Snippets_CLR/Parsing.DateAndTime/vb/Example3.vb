' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim MyCultureInfo As CultureInfo = new CultureInfo("de-DE")
      Dim MyString As String = "12 Juni 2008"
      Dim MyDateTime As DateTime = DateTime.Parse(MyString, MyCultureInfo, _
                                   DateTimeStyles.NoCurrentDateDefault)
      Console.WriteLine(MyDateTime)
   End Sub
End Module
' The example displays the following output if the current culture is en-US:
'       6/12/2008 12:00:00 AM
' </Snippet3>
