'' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Globalization
Imports System.Reflection

Module Example
   Public Sub Main()
      ' Get the properties of an en-US DateTimeFormatInfo object.
      Dim dtfi As DateTimeFormatInfo = CultureInfo.GetCultureInfo("en-US").DateTimeFormat
      Dim typ As Type = dtfi.GetType()
      Dim props() As PropertyInfo = typ.GetProperties()
      Dim value As Date = #05/28/2012 11:35AM# 
      
      For Each prop In props
         ' Is this a format pattern-related property?
         If prop.Name.Contains("Pattern") Then
            Dim fmt As String = CStr(prop.GetValue(dtfi, Nothing))
            Console.WriteLine("{0,-33} {1} {2}{3,-37}Example: {4}", 
                              prop.Name + ":", fmt, vbCrLf, "",
                              value.ToString(fmt)) 
            Console.WriteLine()
         End If
      Next
   End Sub
End Module
' The example displays the following output:
'    FullDateTimePattern:              dddd, MMMM dd, yyyy h:mm:ss tt
'                                         Example: Monday, May 28, 2012 11:35:00 AM
'    
'    LongDatePattern:                  dddd, MMMM dd, yyyy
'                                         Example: Monday, May 28, 2012
'    
'    LongTimePattern:                  h:mm:ss tt
'                                         Example: 11:35:00 AM
'    
'    MonthDayPattern:                  MMMM dd
'                                         Example: May 28
'    
'    RFC1123Pattern:                   ddd, dd MMM yyyy HH':'mm':'ss 'GMT'
'                                         Example: Mon, 28 May 2012 11:35:00 GMT
'    
'    ShortDatePattern:                 M/d/yyyy
'                                         Example: 5/28/2012
'    
'    ShortTimePattern:                 h:mm tt
'                                         Example: 11:35 AM
'    
'    SortableDateTimePattern:          yyyy'-'MM'-'dd'T'HH':'mm':'ss
'                                         Example: 2012-05-28T11:35:00
'    
'    UniversalSortableDateTimePattern: yyyy'-'MM'-'dd HH':'mm':'ss'Z'
'                                         Example: 2012-05-28 11:35:00Z
'    
'    YearMonthPattern:                 MMMM, yyyy
'                                         Example: May, 2012
' </Snippet5>
