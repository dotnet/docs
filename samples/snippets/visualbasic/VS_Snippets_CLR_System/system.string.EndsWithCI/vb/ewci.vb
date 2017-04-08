'<snippet1>
' This code example demonstrates the 
' System.String.EndsWith(String, ..., CultureInfo) method.

Imports System
Imports System.Threading
Imports System.Globalization

Class Sample
    Public Shared Sub Main() 
        Dim msg1 As String = "Search for the target string ""{0}"" in the string ""{1}""." & vbCrLf
        Dim msg2 As String = "Using the {0} - ""{1}"" culture:"
        Dim msg3 As String = "  The string to search ends with the target string: {0}"
        Dim result As Boolean = False
        Dim ci As CultureInfo
        
        ' Define a target string to search for.
        ' U+00c5 = LATIN CAPITAL LETTER A WITH RING ABOVE
        Dim capitalARing As String = "Å"
        
        ' Define a string to search. 
        ' The result of combining the characters LATIN SMALL LETTER A and COMBINING 
        ' RING ABOVE (U+0061, U+030a) is linguistically equivalent to the character 
        ' LATIN SMALL LETTER A WITH RING ABOVE (U+00e5).
        Dim xyzARing As String = "xyz" & "å"
        
        ' Clear the screen and display an introduction.
        Console.Clear()
        
        ' Display the string to search for and the string to search.
        Console.WriteLine(msg1, capitalARing, xyzARing)
        
        ' Search using English-United States culture.
        ci = New CultureInfo("en-US")
        Console.WriteLine(msg2, ci.DisplayName, ci.Name)
        
        Console.WriteLine("Case sensitive:")
        result = xyzARing.EndsWith(capitalARing, False, ci)
        Console.WriteLine(msg3, result)
        
        Console.WriteLine("Case insensitive:")
        result = xyzARing.EndsWith(capitalARing, True, ci)
        Console.WriteLine(msg3, result)
        Console.WriteLine()
        
        ' Search using Swedish-Sweden culture.
        ci = New CultureInfo("sv-SE")
        Console.WriteLine(msg2, ci.DisplayName, ci.Name)
        
        Console.WriteLine("Case sensitive:")
        result = xyzARing.EndsWith(capitalARing, False, ci)
        Console.WriteLine(msg3, result)
        
        Console.WriteLine("Case insensitive:")
        result = xyzARing.EndsWith(capitalARing, True, ci)
        Console.WriteLine(msg3, result)
    
    End Sub 'Main
End Class 'Sample

'
'Note: This code example was executed on a console whose user interface 
'culture is "en-US" (English-United States).
'
'This code example produces the following results:
'
'Search for the target string "Å" in the string "xyza°".
'
'Using the English (United States) - "en-US" culture:
'Case sensitive:
'  The string to search ends with the target string: False
'Case insensitive:
'  The string to search ends with the target string: True
'
'Using the Swedish (Sweden) - "sv-SE" culture:
'Case sensitive:
'  The string to search ends with the target string: False
'Case insensitive:
'  The string to search ends with the target string: False
'
'</snippet1>