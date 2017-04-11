'<snippet1>
' This example demonstrates the 
' System.String.Compare(String, String, StringComparison) method.

Imports System
Imports System.Threading

Class Sample
    Public Shared Sub Main() 
        Dim intro As String = "Compare three versions of the letter I using different " & _
                              "values of StringComparison."
        
        ' Define an array of strings where each element contains a version of the 
        ' letter I. (An array of strings is used so you can easily modify this 
        ' code example to test additional or different combinations of strings.)  
        Dim threeIs(2) As String
        ' LATIN SMALL LETTER I (U+0069)
        threeIs(0) = "i"
        ' LATIN SMALL LETTER DOTLESS I (U+0131)
        threeIs(1) = "ı"
        ' LATIN CAPITAL LETTER I (U+0049)
        threeIs(2) = "I"
        
        Dim unicodeNames As String() =  { _
                            "LATIN SMALL LETTER I (U+0069)", _
                            "LATIN SMALL LETTER DOTLESS I (U+0131)", _
                            "LATIN CAPITAL LETTER I (U+0049)" }
        
        Dim scValues As StringComparison() =  { _
                            StringComparison.CurrentCulture, _
                            StringComparison.CurrentCultureIgnoreCase, _
                            StringComparison.InvariantCulture, _
                            StringComparison.InvariantCultureIgnoreCase, _
                            StringComparison.Ordinal, _
                            StringComparison.OrdinalIgnoreCase }
        '
        Console.Clear()
        Console.WriteLine(intro)
        
        ' Display the current culture because the culture-specific comparisons
        ' can produce different results with different cultures.
        Console.WriteLine("The current culture is {0}." & vbCrLf, _
                           Thread.CurrentThread.CurrentCulture.Name)
        
        ' Determine the relative sort order of three versions of the letter I. 
        Dim sc As StringComparison
        For Each sc In  scValues
            Console.WriteLine("StringComparison.{0}:", sc)
            
            ' LATIN SMALL LETTER I (U+0069) : LATIN SMALL LETTER DOTLESS I (U+0131)
            Test(0, 1, sc, threeIs, unicodeNames)
            
            ' LATIN SMALL LETTER I (U+0069) : LATIN CAPITAL LETTER I (U+0049)
            Test(0, 2, sc, threeIs, unicodeNames)
            
            ' LATIN SMALL LETTER DOTLESS I (U+0131) : LATIN CAPITAL LETTER I (U+0049)
            Test(1, 2, sc, threeIs, unicodeNames)
            
            Console.WriteLine()
        Next sc
    
    End Sub 'Main
    
    Protected Shared Sub Test(ByVal x As Integer, ByVal y As Integer, _
                              ByVal comparison As StringComparison, _
                              ByVal testI() As String, ByVal testNames() As String) 
        Dim resultFmt As String = "{0} is {1} {2}"
        Dim result As String = "equal to"
        Dim cmpValue As Integer = 0
        '
        cmpValue = String.Compare(testI(x), testI(y), comparison)
        If cmpValue < 0 Then
            result = "less than"
        ElseIf cmpValue > 0 Then
            result = "greater than"
        End If
        Console.WriteLine(resultFmt, testNames(x), result, testNames(y))
    
    End Sub 'Test
End Class 'Sample

'
'This code example produces the following results:
'
'Compare three versions of the letter I using different values of StringComparison.
'The current culture is en-US.
'
'StringComparison.CurrentCulture:
'LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
'LATIN SMALL LETTER I (U+0069) is less than LATIN CAPITAL LETTER I (U+0049)
'LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)
'
'StringComparison.CurrentCultureIgnoreCase:
'LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
'LATIN SMALL LETTER I (U+0069) is equal to LATIN CAPITAL LETTER I (U+0049)
'LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)
'
'StringComparison.InvariantCulture:
'LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
'LATIN SMALL LETTER I (U+0069) is less than LATIN CAPITAL LETTER I (U+0049)
'LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)
'
'StringComparison.InvariantCultureIgnoreCase:
'LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
'LATIN SMALL LETTER I (U+0069) is equal to LATIN CAPITAL LETTER I (U+0049)
'LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)
'
'StringComparison.Ordinal:
'LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
'LATIN SMALL LETTER I (U+0069) is greater than LATIN CAPITAL LETTER I (U+0049)
'LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)
'
'StringComparison.OrdinalIgnoreCase:
'LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
'LATIN SMALL LETTER I (U+0069) is equal to LATIN CAPITAL LETTER I (U+0049)
'LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)
'
'</snippet1>