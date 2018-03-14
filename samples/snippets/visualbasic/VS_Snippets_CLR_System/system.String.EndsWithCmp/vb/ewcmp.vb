'<snippet1>
' This example demonstrates the 
' System.String.EndsWith(String, StringComparison) method.

Imports System
Imports System.Threading

Class Sample
    Public Shared Sub Main() 
        Dim intro As String = "Determine whether a string ends with another string, " & _
                              "using" & vbCrLf & "  different values of StringComparison."
        
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

        ' Determine whether three versions of the letter I are equal to each other. 
        Dim sc As StringComparison
        For Each sc In  scValues
            Console.WriteLine("StringComparison.{0}:", sc)
            Test("abcXYZ", "XYZ", sc)
            Test("abcXYZ", "xyz", sc)
            Console.WriteLine()
        Next sc
    
    End Sub 'Main
    
    
    Protected Shared Sub Test(ByVal x As String, ByVal y As String, _
                              ByVal comparison As StringComparison) 
        Dim resultFmt As String = """{0}"" {1} with ""{2}""."
        Dim result As String = "does not end"
        '
        If x.EndsWith(y, comparison) Then
            result = "ends"
        End If
        Console.WriteLine(resultFmt, x, result, y)
    
    End Sub 'Test
End Class 'Sample

'
'This code example produces the following results:
'
'Determine whether a string ends with another string, using
'  different values of StringComparison.
'The current culture is en-US.
'
'StringComparison.CurrentCulture:
'"abcXYZ" ends with "XYZ".
'"abcXYZ" does not end with "xyz".
'
'StringComparison.CurrentCultureIgnoreCase:
'"abcXYZ" ends with "XYZ".
'"abcXYZ" ends with "xyz".
'
'StringComparison.InvariantCulture:
'"abcXYZ" ends with "XYZ".
'"abcXYZ" does not end with "xyz".
'
'StringComparison.InvariantCultureIgnoreCase:
'"abcXYZ" ends with "XYZ".
'"abcXYZ" ends with "xyz".
'
'StringComparison.Ordinal:
'"abcXYZ" ends with "XYZ".
'"abcXYZ" does not end with "xyz".
'
'StringComparison.OrdinalIgnoreCase:
'"abcXYZ" ends with "XYZ".
'"abcXYZ" ends with "xyz".
'
'</snippet1>