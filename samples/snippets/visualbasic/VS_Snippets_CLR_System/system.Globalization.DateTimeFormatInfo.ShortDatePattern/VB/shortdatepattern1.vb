' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim dtfi As DateTimeFormatInfo = CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat
      Dim date1 As DateTime = #05/01/2011#
      Console.WriteLine("Original Short Date Pattern:")
      Console.WriteLine("   {0}: {1}", dtfi.ShortDatePattern, 
                                       date1.ToString("d", dtfi))
      dtfi.DateSeparator = "-"
      dtfi.ShortDatePattern = "yyyy/MM/dd"
      Console.WriteLine("Revised Short Date Pattern:")
      Console.WriteLine("   {0}: {1}", dtfi.ShortDatePattern, 
                                       date1.ToString("d", dtfi))
   End Sub
End Module
' The example displays the following output:
'    Original Short Date Pattern:
'       M/d/yyyy: 5/1/2011
'    Revised Short Date Pattern:
'       YYYY/MM/dd: 2011-05-01
' </Snippet2>
