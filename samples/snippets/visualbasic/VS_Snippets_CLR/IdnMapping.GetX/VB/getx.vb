'<snippet1>
' This example demonstrates the GetAscii and GetUnicode methods.
' For sake of illustration, this example uses the most complex
' form of those methods, not the most convenient.

Imports System
Imports System.Globalization

Class Sample
    Public Shared Sub Main() 

'   Define a domain name consisting of the labels: GREEK SMALL LETTER 
'   PI (U+03C0); IDEOGRAPHIC FULL STOP (U+3002); GREEK SMALL LETTER 
'   THETA (U+03B8); FULLWIDTH FULL STOP (U+FF0E); and "com".

        Dim name As String = "π。θ．com"
        Dim international As String
        Dim nonInternational As String
        
        Dim msg1 As String = "the original non-internationalized " & vbCrLf & "domain name:"
        Dim msg2 As String = "Allow unassigned characters?:     {0}"
        Dim msg3 As String = "Use non-internationalized rules?: {0}"
        Dim msg4 As String = "Convert the non-internationalized domain name to international format..."
        Dim msg5 As String = "Display the encoded domain name:" & vbCrLf & """{0}"""
        Dim msg6 As String = "the encoded domain name:"
        Dim msg7 As String = "Convert the internationalized domain name to non-international format..."
        Dim msg8 As String = "the reconstituted non-internationalized " & vbCrLf & "domain name:"
        Dim msg9 As String = "Visually compare the code points of the reconstituted string to the " & _
                             "original." & vbCrLf & _
                             "Note that the reconstituted string contains standard label " & _
                             "separators (U+002e)."
        ' ----------------------------------------------------------------------------
        Console.Clear()
        CodePoints(name, msg1)
        ' ----------------------------------------------------------------------------
        Dim idn As New IdnMapping()
        
        Console.WriteLine(msg2, idn.AllowUnassigned)
        Console.WriteLine(msg3, idn.UseStd3AsciiRules)
        Console.WriteLine()
        ' ----------------------------------------------------------------------------
        Console.WriteLine(msg4)
        international = idn.GetAscii(name, 0, name.Length)
        Console.WriteLine(msg5, international)
        Console.WriteLine()
        CodePoints(international, msg6)
        ' ----------------------------------------------------------------------------
        Console.WriteLine(msg7)
        nonInternational = idn.GetUnicode(international, 0, international.Length)
        CodePoints(nonInternational, msg8)
        Console.WriteLine(msg9)
    End Sub 'Main
    
    ' ----------------------------------------------------------------------------
    Shared Sub CodePoints(ByVal value As String, ByVal title As String) 
        Console.WriteLine("Display the Unicode code points of {0}", title)
        Dim c As Char
        For Each c In  value
            Console.Write("{0:x4} ", Convert.ToInt32(c))
        Next c
        Console.WriteLine()
        Console.WriteLine()
    
    End Sub 'CodePoints
End Class 'Sample
'
'This code example produces the following results:
'
'Display the Unicode code points of the original non-internationalized
'domain name:
'03c0 3002 03b8 ff0e 0063 006f 006d
'
'Allow unassigned characters?:     False
'Use non-internationalized rules?: False
'
'Convert the non-internationalized domain name to international format...
'Display the encoded domain name:
'"xn--1xa.xn--txa.com"
'
'Display the Unicode code points of the encoded domain name:
'0078 006e 002d 002d 0031 0078 0061 002e 0078 006e 002d 002d 0074 0078 0061 002e 0063 006f
'006d
'
'Convert the internationalized domain name to non-international format...
'Display the Unicode code points of the reconstituted non-internationalized
'domain name:
'03c0 002e 03b8 002e 0063 006f 006d
'
'Visually compare the code points of the reconstituted string to the original.
'Note that the reconstituted string contains standard label separators (U+002e).
'
'</snippet1>