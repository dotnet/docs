'<snippet1>
Imports System.Globalization

Module Example
    Public Sub Main() 
        ' Initialize a DateTime object.
        Console.WriteLine($"Initialize the DateTime object to May 16, 2001 3:02:15 AM.{vbCrLf}")
        Dim dateAndTime As New DateTime(2001, 5, 16, 3, 2, 15)
        
        ' Display the name of the current culture.
        Console.WriteLine($"Current culture: ""{CultureInfo.CurrentCulture.Name}""{vbCrLf}")
        Dim dtfi = CultureInfo.CurrentCulture.DateTimeFormat
        
        ' Display the long date pattern and string.
        Console.WriteLine($"Long date pattern: ""{dtfi.LongDatePattern}""")
        Console.WriteLine($"Long date string:  ""{dateAndTime.ToLongDateString()}{vbCrLf}")
        
        ' Display the long time pattern and string.
        Console.WriteLine($"Long time pattern: ""{0}""", dtfi.LongTimePattern)
        Console.WriteLine($"Long time string:  ""{dateAndTime.ToLongTimeString()}{vbCrLf}")
        
        ' Display the short date pattern and string.
        Console.WriteLine($"Short date pattern: ""{dtfi.ShortDatePattern}""")
        Console.WriteLine($"Short date string:  ""{dateAndTime.ToShortDateString()}{vbCrLf}")
        
        ' Display the short time pattern and string.
        Console.WriteLine($"Short time pattern: ""{dtfi.ShortTimePattern}""")
        Console.WriteLine($"Short time string:  ""{dateAndTime.ToShortTimeString()}{vbCrLf}")
    End Sub
End Module
' The example displays output like the following:
'       Initialize the DateTime object to May 16, 2001 3:02:15 AM.
'
'       Current culture: "en-US"
'
'       Long date pattern: "dddd, MMMM d, yyyy"
'       Long date string:  "Wednesday, May 16, 2001
'
'       Long time pattern: "0"
'       Long time string:  "3:02:15 AM
'
'       Short date pattern: "M/d/yyyy"
'       Short date string:  "5/16/2001
'
'       Short time pattern: "h:mm tt"
'       Short time string:  "3:02 AM
' </snippet1>