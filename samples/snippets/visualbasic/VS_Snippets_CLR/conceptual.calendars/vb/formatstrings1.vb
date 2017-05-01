' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Imports System.Globalization
Imports System.IO
Imports System.Threading

Module Example
   Public Sub Main()
      Dim sw As New StreamWriter(".\eras.txt")
      Dim dt As Date = #05/01/2012#
      
      Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture("ja-JP")
      Dim dtfi As DateTimeFormatInfo = culture.DateTimeFormat
      dtfi.Calendar = New JapaneseCalendar()
      Thread.CurrentThread.CurrentCulture = culture
      
      sw.WriteLine("{0,-43} {1}", "Full Date and Time Pattern:", dtfi.FullDateTimePattern)
      sw.WriteLine(dt.ToString("F"))
      sw.WriteLine()
      
      sw.WriteLine("{0,-43} {1}", "Long Date Pattern:", dtfi.LongDatePattern)
      sw.WriteLine(dt.ToString("D"))
      sw.WriteLine()
      
      sw.WriteLine("{0,-43} {1}", "Short Date Pattern:", dtfi.ShortDatePattern)
      sw.WriteLine(dt.ToString("d"))
      sw.WriteLine()
      sw.Close()
   End Sub
End Module
' The example writes the following output to a file:
'    Full Date and Time Pattern:                 gg y'年'M'月'd'日' H:mm:ss
'    平成 24年5月1日 0:00:00
'    
'    Long Date Pattern:                          gg y'年'M'月'd'日'
'    平成 24年5月1日
'    
'    Short Date Pattern:                         gg y/M/d
'    平成 24/5/1 
' </Snippet8>
