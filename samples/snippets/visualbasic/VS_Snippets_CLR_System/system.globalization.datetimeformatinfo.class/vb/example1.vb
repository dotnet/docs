' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim dateValue As New Date(2013, 08, 18) 
      Dim enUS As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
      Dim dtfi As DateTimeFormatInfo = enUS.DateTimeFormat
      
      Console.WriteLine("Before modifying DateTimeFormatInfo object: ")
      Console.WriteLine("{0}: {1}", dtfi.ShortDatePattern, 
                                    dateValue.ToString("d", enUS))
      Console.WriteLine()
      
      ' Modify the short date pattern.
      dtfi.ShortDatePattern = "yyyy-MM-dd"
      Console.WriteLine("After modifying DateTimeFormatInfo object: ")
      Console.WriteLine("{0}: {1}", dtfi.ShortDatePattern, 
                                    dateValue.ToString("d", enUS))
   End Sub
End Module
' The example displays the following output:
'       Before modifying DateTimeFormatInfo object:
'       M/d/yyyy: 8/18/2013
'       
'       After modifying DateTimeFormatInfo object:
'       yyyy-MM-dd: 2013-08-18
' </Snippet10>
