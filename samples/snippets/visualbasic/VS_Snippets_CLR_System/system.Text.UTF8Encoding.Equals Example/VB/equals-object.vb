' <Snippet1>
Imports System
Imports System.Text

Class UTF8EncodingExample
    
    Public Shared Sub Main()
        Dim utf8 As New UTF8Encoding()
        Dim utf8true As New UTF8Encoding(True)
        Dim utf8truetrue As New UTF8Encoding(True, True)
        Dim utf8falsetrue As New UTF8Encoding(False, True)
        
        DescribeEquivalence(utf8.Equals(utf8))
        DescribeEquivalence(utf8.Equals(utf8true))
        DescribeEquivalence(utf8.Equals(utf8truetrue))
        DescribeEquivalence(utf8.Equals(utf8falsetrue))
        
        DescribeEquivalence(utf8true.Equals(utf8))
        DescribeEquivalence(utf8true.Equals(utf8true))
        DescribeEquivalence(utf8true.Equals(utf8truetrue))
        DescribeEquivalence(utf8true.Equals(utf8falsetrue))
        
        DescribeEquivalence(utf8truetrue.Equals(utf8))
        DescribeEquivalence(utf8truetrue.Equals(utf8true))
        DescribeEquivalence(utf8truetrue.Equals(utf8truetrue))
        DescribeEquivalence(utf8truetrue.Equals(utf8falsetrue))
        
        DescribeEquivalence(utf8falsetrue.Equals(utf8))
        DescribeEquivalence(utf8falsetrue.Equals(utf8true))
        DescribeEquivalence(utf8falsetrue.Equals(utf8truetrue))
        DescribeEquivalence(utf8falsetrue.Equals(utf8falsetrue))
    End Sub 'Main
    
    
    Public Shared Sub DescribeEquivalence(isEquivalent As Boolean)
        Dim phrase as String
        If isEquivalent Then
            phrase = "An"
        Else
            phrase = "Not an"
        End If
        Console.WriteLine("{0} equivalent encoding.", phrase)
    End Sub 'DescribeEquivalence
End Class 'UTF8EncodingExample
' </Snippet1>
