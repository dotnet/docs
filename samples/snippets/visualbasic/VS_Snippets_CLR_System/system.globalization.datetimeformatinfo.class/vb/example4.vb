' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim dateValue As New Date(2013, 5, 18, 13, 30, 0)
      Dim formats() As String = { "D", "f", "F" }      
      
      Dim enUS As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
      Dim dtfi As DateTimeFormatInfo = enUS.DateTimeFormat
      Dim originalLongDatePattern As String = dtfi.LongDatePattern

      ' Display the default form of three long date formats.
      For Each fmt In formats
         Console.WriteLine(dateValue.ToString(fmt, dtfi))
      Next
      Console.WriteLine()
      
      ' Modify the long date pattern.
      dtfi.LongDatePattern = originalLongDatePattern + " g"
      For Each fmt In formats
         Console.WriteLine(dateValue.ToString(fmt, dtfi))
      Next
      Console.WriteLine()
      
      ' Change A.D. to C.E. (for Common Era)
      dtfi.LongDatePattern = originalLongDatePattern + " 'C.E.'"
      For Each fmt In formats
         Console.WriteLine(dateValue.ToString(fmt, dtfi))
      Next
   End Sub
End Module
' The example displays the following output:
'       Saturday, May 18, 2013
'       Saturday, May 18, 2013 1:30 PM
'       Saturday, May 18, 2013 1:30:00 PM
'       
'       Saturday, May 18, 2013 A.D.
'       Saturday, May 18, 2013 A.D. 1:30 PM
'       Saturday, May 18, 2013 A.D. 1:30:00 PM
'       
'       Saturday, May 18, 2013 C.E.
'       Saturday, May 18, 2013 C.E. 1:30 PM
'       Saturday, May 18, 2013 C.E. 1:30:00 PM
' </Snippet11>