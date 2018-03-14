'<snippet1>
' This code example demonstrates the 
' System.String.IndexOf(String, ..., StringComparison) methods.

Imports System
Imports System.Threading
Imports System.Globalization

Class Sample
    Public Shared Sub Main() 
        Dim intro As String = "Find the first occurrence of a character using different " & _
                              "values of StringComparison."
        Dim resultFmt As String = "Comparison: {0,-28} Location: {1,3}"
        
        ' Define a string to search for.
        ' U+00c5 = LATIN CAPITAL LETTER A WITH RING ABOVE
        Dim CapitalAWithRing As String = "Å"
        
        ' Define a string to search. 
        ' The result of combining the characters LATIN SMALL LETTER A and COMBINING 
        ' RING ABOVE (U+0061, U+030a) is linguistically equivalent to the character 
        ' LATIN SMALL LETTER A WITH RING ABOVE (U+00e5).
        Dim cat As String = "A Cheshire c" & "å" & "t"
        
        Dim loc As Integer = 0
        Dim scValues As StringComparison() =  { _
                        StringComparison.CurrentCulture, _
                        StringComparison.CurrentCultureIgnoreCase, _
                        StringComparison.InvariantCulture, _
                        StringComparison.InvariantCultureIgnoreCase, _
                        StringComparison.Ordinal, _
                        StringComparison.OrdinalIgnoreCase }
        Dim sc As StringComparison
        
        ' Clear the screen and display an introduction.
        Console.Clear()
        Console.WriteLine(intro)
        
        ' Display the current culture because culture affects the result. For example, 
        ' try this code example with the "sv-SE" (Swedish-Sweden) culture.
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
        Console.WriteLine("The current culture is ""{0}"" - {1}.", _
                           Thread.CurrentThread.CurrentCulture.Name, _ 
                           Thread.CurrentThread.CurrentCulture.DisplayName)
        
        ' Display the string to search for and the string to search.
        Console.WriteLine("Search for the string ""{0}"" in the string ""{1}""", _
                           CapitalAWithRing, cat)
        Console.WriteLine()
        
        ' Note that in each of the following searches, we look for 
        ' LATIN CAPITAL LETTER A WITH RING ABOVE in a string that contains 
        ' LATIN SMALL LETTER A WITH RING ABOVE. A result value of -1 indicates 
        ' the string was not found.
        ' Search using different values of StringComparison. Specify the start 
        ' index and count.

        Console.WriteLine("Part 1: Start index and count are specified.")
        For Each sc In  scValues
            loc = cat.IndexOf(CapitalAWithRing, 0, cat.Length, sc)
            Console.WriteLine(resultFmt, sc, loc)
        Next sc
        
        ' Search using different values of StringComparison. Specify the 
        ' start index. 

        Console.WriteLine(vbCrLf & "Part 2: Start index is specified.")
        For Each sc In  scValues
            loc = cat.IndexOf(CapitalAWithRing, 0, sc)
            Console.WriteLine(resultFmt, sc, loc)
        Next sc
        
        ' Search using different values of StringComparison. 

        Console.WriteLine(vbCrLf & "Part 3: Neither start index nor count is specified.")
        For Each sc In  scValues
            loc = cat.IndexOf(CapitalAWithRing, sc)
            Console.WriteLine(resultFmt, sc, loc)
        Next sc
    
    End Sub 'Main
End Class 'Sample

'
'Note: This code example was executed on a console whose user interface 
'culture is "en-US" (English-United States).
'
'This code example produces the following results:
'
'Find the first occurrence of a character using different values of StringComparison.
'The current culture is "en-US" - English (United States).
'Search for the string "Å" in the string "A Cheshire ca°t"
'
'Part 1: Start index and count are specified.
'Comparison: CurrentCulture               Location:  -1
'Comparison: CurrentCultureIgnoreCase     Location:  12
'Comparison: InvariantCulture             Location:  -1
'Comparison: InvariantCultureIgnoreCase   Location:  12
'Comparison: Ordinal                      Location:  -1
'Comparison: OrdinalIgnoreCase            Location:  -1
'
'Part 2: Start index is specified.
'Comparison: CurrentCulture               Location:  -1
'Comparison: CurrentCultureIgnoreCase     Location:  12
'Comparison: InvariantCulture             Location:  -1
'Comparison: InvariantCultureIgnoreCase   Location:  12
'Comparison: Ordinal                      Location:  -1
'Comparison: OrdinalIgnoreCase            Location:  -1
'
'Part 3: Neither start index nor count is specified.
'Comparison: CurrentCulture               Location:  -1
'Comparison: CurrentCultureIgnoreCase     Location:  12
'Comparison: InvariantCulture             Location:  -1
'Comparison: InvariantCultureIgnoreCase   Location:  12
'Comparison: Ordinal                      Location:  -1
'Comparison: OrdinalIgnoreCase            Location:  -1
'
'</snippet1>