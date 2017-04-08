' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim faIR As New CultureInfo("fa-IR")
      Dim dat As New DateTime(1395, 8, 18, faIR.DateTimeFormat.Calendar)
      Console.WriteLine("Umm-al-Qura date: {0}", dat.ToString("d", faIR))
      Console.WriteLine("Gregorian date:   {0:d}", dat)
   End Sub
End Module
' The example displays the following output:
'       Umm-al-Qura date: 18/08/1395
'       Gregorian date:   11/8/2016
' </Snippet3>
