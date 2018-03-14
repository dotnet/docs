' <Snippet1>
Imports System
Imports System.Text

Class UnicodeEncodingExample
    
    Public Shared Sub Main()

        ' Create a UnicodeEncoding without parameters.
        Dim unicodeDefault As New UnicodeEncoding()

        ' Create a UnicodeEncoding to support little-endian byte ordering
        ' and include the Unicode byte order mark.        
        Dim unicodeLittleEndianBOM As New UnicodeEncoding(False, True)
        ' Compare this UnicodeEncoding to the UnicodeEncoding without parameters.
        DescribeEquivalence(unicodeDefault.Equals(unicodeLittleEndianBOM))
        
        ' Create a UnicodeEncoding to support little-endian byte ordering
        ' and not include the Unicode byte order mark.
        Dim unicodeLittleEndianNoBOM As New UnicodeEncoding(False, False)
        ' Compare this UnicodeEncoding to the UnicodeEncoding without parameters.
        DescribeEquivalence(unicodeDefault.Equals(unicodeLittleEndianNoBOM))
        
        ' Create a UnicodeEncoding to support big-endian byte ordering
        ' and include the Unicode byte order mark.
        Dim unicodeBigEndianBOM As New UnicodeEncoding(True, True)
        ' Compare this UnicodeEncoding to the UnicodeEncoding without parameters.
        DescribeEquivalence(unicodeDefault.Equals(unicodeBigEndianBOM))
        
        ' Create a UnicodeEncoding to support big-endian byte ordering
        ' and not include the Unicode byte order mark.
        Dim unicodeBigEndianNoBOM As New UnicodeEncoding(True, False)
        ' Compare this UnicodeEncoding to the UnicodeEncoding without parameters.
        DescribeEquivalence(unicodeDefault.Equals(unicodeBigEndianNoBOM))
    End Sub
    
    
    Public Shared Sub DescribeEquivalence(isEquivalent As Boolean)
        Dim phrase as String
        If isEquivalent Then
            phrase = "An"
        Else
            phrase = "Not an"
        End If
        Console.WriteLine("{0} equivalent encoding.", phrase)
    End Sub
End Class
' </Snippet1>
