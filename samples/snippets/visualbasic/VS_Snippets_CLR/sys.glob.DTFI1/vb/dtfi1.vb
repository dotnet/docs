'<snippet1>

' This code example demonstrates the DateTimeFormatInfo 
' MonthGenitiveNames, AbbreviatedMonthGenitiveNames, 
' ShortestDayNames, and NativeCalendarName properties, and
' the GetShortestDayName() and SetAllDateTimePatterns() methods.

Imports System
Imports System.Globalization

Class Sample
    Public Shared Sub Main() 
        Dim myDateTimePatterns() As String = {"MM/dd/yy", "MM/dd/yyyy"}
        Dim name As String = ""
        
        ' Get the en-US culture.
        Dim ci As New CultureInfo("en-US")
        ' Get the DateTimeFormatInfo for the en-US culture.
        Dim dtfi As DateTimeFormatInfo = ci.DateTimeFormat
        
        ' Display the effective culture.
        Console.WriteLine("This code example uses the {0} culture.", ci.Name)
        
        ' Display the native calendar name.    
        Console.WriteLine(vbCrLf & "NativeCalendarName...")
        Console.WriteLine("""{0}""", dtfi.NativeCalendarName)
        
        ' Display month genitive names.
        Console.WriteLine(vbCrLf & "MonthGenitiveNames...")
        For Each name In dtfi.MonthGenitiveNames
            Console.WriteLine("""{0}""", name)
        Next name
        
        ' Display abbreviated month genitive names.
        Console.WriteLine(vbCrLf & "AbbreviatedMonthGenitiveNames...")
        For Each name In dtfi.AbbreviatedMonthGenitiveNames
            Console.WriteLine("""{0}""", name)
        Next name
        
        ' Display shortest day names.
        Console.WriteLine(vbCrLf & "ShortestDayNames...")
        For Each name In dtfi.ShortestDayNames
            Console.WriteLine("""{0}""", name)
        Next name
        
        ' Display shortest day name for a particular day of the week.
        Console.WriteLine(vbCrLf & "GetShortestDayName(DayOfWeek.Sunday)...")
        Console.WriteLine("""{0}""", dtfi.GetShortestDayName(DayOfWeek.Sunday))
        
        ' Display the initial DateTime format patterns for the 'd' format specifier.
        Console.WriteLine(vbCrLf & "Initial DateTime format patterns for " & _
                          "the 'd' format specifier...")
        For Each name In dtfi.GetAllDateTimePatterns("d"c)
            Console.WriteLine("""{0}""", name)
        Next name
        
        ' Change the initial DateTime format patterns for the 'd' DateTime format specifier.
        Console.WriteLine(vbCrLf & "Change the initial DateTime format patterns for the " & _
                          vbCrLf & "'d' format specifier to my format patterns...")
        dtfi.SetAllDateTimePatterns(myDateTimePatterns, "d"c)
        
        ' Display the new DateTime format patterns for the 'd' format specifier.
        Console.WriteLine(vbCrLf & _
                          "New DateTime format patterns for the 'd' format specifier...")
        For Each name In dtfi.GetAllDateTimePatterns("d"c)
            Console.WriteLine("""{0}""", name)
        Next name
    
    End Sub 'Main
End Class 'Sample
'
'This code example produces the following results:
'
'This code example uses the en-US culture.
'
'NativeCalendarName...
'"Gregorian Calendar"
'
'MonthGenitiveNames...
'"January"
'"February"
'"March"
'"April"
'"May"
'"June"
'"July"
'"August"
'"September"
'"October"
'"November"
'"December"
'""
'
'AbbreviatedMonthGenitiveNames...
'"Jan"
'"Feb"
'"Mar"
'"Apr"
'"May"
'"Jun"
'"Jul"
'"Aug"
'"Sep"
'"Oct"
'"Nov"
'"Dec"
'""
'
'ShortestDayNames...
'"Su"
'"Mo"
'"Tu"
'"We"
'"Th"
'"Fr"
'"Sa"
'
'GetShortestDayName(DayOfWeek.Sunday)...
'"Su"
'
'Initial DateTime format patterns for the 'd' format specifier...
'"M/d/yyyy"
'"M/d/yy"
'"MM/dd/yy"
'"MM/dd/yyyy"
'"yy/MM/dd"
'"yyyy-MM-dd"
'"dd-MMM-yy"
'
'Change the initial DateTime format patterns for the
''d' format specifier to my format patterns...
'
'New DateTime format patterns for the 'd' format specifier...
'"MM/dd/yy"
'"MM/dd/yyyy"
'
'</snippet1>