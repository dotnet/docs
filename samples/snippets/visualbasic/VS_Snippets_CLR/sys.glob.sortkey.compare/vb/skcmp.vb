'<snippet1>
' This code example demonstrates the CompareInfo.Compare() and
' SortKey.Compare() methods.

Imports System
Imports System.Globalization

Class Sample
    Public Shared Sub Main() 
        Dim lowerABC As String = "abc"
        Dim upperABC As String = "ABC"
        Dim result As Integer = 0
        
    ' Create a CompareInfo object for the en-US culture.
        Console.WriteLine(vbCrLf & _
                          "Create a CompareInfo object for the en-US culture..." & _
                          vbCrLf)
        Dim cmpi As CompareInfo = CompareInfo.GetCompareInfo("en-US")
    ' Alternatively:
    '   Dim cmpi As CompareInfo = New CultureInfo("en-US").CompareInfo

    ' Create sort keys for lowercase and uppercase "abc", the en-US culture, and 
    ' ignore case. 
        Dim sk1LowerIgnCase As SortKey = cmpi.GetSortKey(lowerABC, CompareOptions.IgnoreCase)
        Dim sk2UpperIgnCase As SortKey = cmpi.GetSortKey(upperABC, CompareOptions.IgnoreCase)
        
    ' Create sort keys for lowercase and uppercase "abc", the en-US culture, and 
    ' use case. 
        Dim sk1LowerUseCase As SortKey = cmpi.GetSortKey(lowerABC, CompareOptions.None)
        Dim sk2UpperUseCase As SortKey = cmpi.GetSortKey(upperABC, CompareOptions.None)
        
    ' Compare lowercase and uppercase "abc", ignoring case and using CompareInfo.
        result = cmpi.Compare(lowerABC, upperABC, CompareOptions.IgnoreCase)
        Display(result, "CompareInfo, Ignore case", lowerABC, upperABC)
    ' Compare lowercase and uppercase "abc", ignoring case and using SortKey.
        result = SortKey.Compare(sk1LowerIgnCase, sk2UpperIgnCase)
        Display(result, "SortKey, Ignore case", lowerABC, upperABC)
        Console.WriteLine()
        
    ' Compare lowercase and uppercase "abc", using case and using CompareInfo.
        result = cmpi.Compare(lowerABC, upperABC, CompareOptions.None)
        Display(result, "CompareInfo, Use case", lowerABC, upperABC)
    ' Compare lowercase and uppercase "abc", using case and using SortKey.
        result = SortKey.Compare(sk1LowerUseCase, sk2UpperUseCase)
        Display(result, "SortKey, Use case", lowerABC, upperABC)
    End Sub 'Main
    
    ' Display the results of a comparison.
    Private Shared Sub Display(ByVal compareResult As Integer, _
                               ByVal title As String, _
                               ByVal lower As String, _
                               ByVal upper As String) 
        Dim lessThan As String = "less than "
        Dim equalTo As String = "equal to "
        Dim greaterThan As String = "greater than "
        Dim resultPhrase As String = Nothing
        Dim format As String = "{0}:" & vbCrLf & "    ""{1}"" is {2}""{3}""."
        
        If compareResult < 0 Then
            resultPhrase = lessThan
        ElseIf compareResult > 0 Then
            resultPhrase = greaterThan
        Else
            resultPhrase = equalTo
        End If
        Console.WriteLine(format, title, lower, resultPhrase, upper)
    End Sub 'Display
End Class 'Sample

'
'This code example produces the following results:
'
'Create a CompareInfo object for the en-US culture...
'
'CompareInfo, Ignore case:
'    "abc" is equal to "ABC".
'SortKey, Ignore case:
'    "abc" is equal to "ABC".
'
'CompareInfo, Use case:
'    "abc" is less than "ABC".
'SortKey, Use case:
'    "abc" is less than "ABC".
'
'</snippet1>