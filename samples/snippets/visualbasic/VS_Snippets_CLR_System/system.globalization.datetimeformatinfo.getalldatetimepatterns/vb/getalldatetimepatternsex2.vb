' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture("ru-RU")
      Dim formats() As String = { "d", "D", "f", "F", "g", "G", "m",
                                  "o", "r", "s", "t", "T", "u", "U", "y" }
      Dim date1 = New DateTime(2011, 02, 01, 7, 30, 45, 0)
      Dim date2 As DateTime
      Dim total, noRoundTrip As Integer

      For Each fmt In formats
         total = 0 : noRoundTrip = 0
         For Each pattern In culture.DateTimeFormat.GetAllDateTimePatterns(CChar(fmt))
            total += 1
            If Not DateTime.TryParse(date1.ToString(pattern), date2)
               noRoundTrip += 1
               Console.WriteLine("Unable to parse {0:" + pattern + "} (format '{1}')", 
                                 date1, pattern)
            End If             
         Next
         If noRoundTrip > 0 Then
            Console.WriteLine("{0}: Unable to round-trip {1} of {2} format strings.",
                              fmt, noRoundTrip, total)
            Console.WriteLine()
         Else
            Console.WriteLine("{0}: All custom format strings round trip.", fmt)
            Console.WriteLine()
         End If
      Next
   End Sub
End Module
' The example displays the following output:
'    d: All custom format strings round trip.
'    
'    Unable to parse 1 February 2011 г. (format 'd MMMM yyyy 'г.'')
'    Unable to parse 01 February 2011 г. (format 'dd MMMM yyyy 'г.'')
'    D: Unable to round-trip 2 of 2 format strings.
'    
'    Unable to parse 1 February 2011 г. 7:30 (format 'd MMMM yyyy 'г.' H:mm')
'    Unable to parse 1 February 2011 г. 07:30 (format 'd MMMM yyyy 'г.' HH:mm')
'    Unable to parse 01 February 2011 г. 7:30 (format 'dd MMMM yyyy 'г.' H:mm')
'    Unable to parse 01 February 2011 г. 07:30 (format 'dd MMMM yyyy 'г.' HH:mm')
'    f: Unable to round-trip 4 of 4 format strings.
'    
'    Unable to parse 1 February 2011 г. 7:30:45 (format 'd MMMM yyyy 'г.' H:mm:ss')
'    Unable to parse 1 February 2011 г. 07:30:45 (format 'd MMMM yyyy 'г.' HH:mm:ss')
'    Unable to parse 01 February 2011 г. 7:30:45 (format 'dd MMMM yyyy 'г.' H:mm:ss')
'    Unable to parse 01 February 2011 г. 07:30:45 (format 'dd MMMM yyyy 'г.' HH:mm:ss')
'    F: Unable to round-trip 4 of 4 format strings.
'    
'    g: All custom format strings round trip.
'    
'    G: All custom format strings round trip.
'    
'    m: All custom format strings round trip.
'    
'    o: All custom format strings round trip.
'    
'    r: All custom format strings round trip.
'    
'    s: All custom format strings round trip.
'    
'    t: All custom format strings round trip.
'    
'    T: All custom format strings round trip.
'    
'    u: All custom format strings round trip.
'    
'    Unable to parse 1 February 2011 г. 7:30:45 (format 'd MMMM yyyy 'г.' H:mm:ss')
'    Unable to parse 1 February 2011 г. 07:30:45 (format 'd MMMM yyyy 'г.' HH:mm:ss')
'    Unable to parse 01 February 2011 г. 7:30:45 (format 'dd MMMM yyyy 'г.' H:mm:ss')
'    Unable to parse 01 February 2011 г. 07:30:45 (format 'dd MMMM yyyy 'г.' HH:mm:ss')
'    U: Unable to round-trip 4 of 4 format strings.
'    
'    y: All custom format strings round trip.
' </Snippet2>

