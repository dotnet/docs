'<snippet1>
' This code example demonstrates the 
' GetSortKey() and ToString() methods, and the 
' OriginalString and KeyData properties of the 
' System.Globalization.SortKey class.

Imports System
Imports System.Globalization

Class Sample
    Public Shared Sub Main() 
        Dim cmpi As CompareInfo = Nothing
        Dim sk1 As SortKey = Nothing
        Dim sk2 As SortKey = Nothing
        Dim s As String = "ABC"
        Dim ignoreCase As String = "Ignore case"
        Dim useCase As String =    "Use case   "
        
        ' Get a CompareInfo object for the English-Great Britain culture.
        cmpi = CompareInfo.GetCompareInfo("en-GB")
        
        ' Get a sort key that ignores case for the specified string.
        sk1 = cmpi.GetSortKey(s, CompareOptions.IgnoreCase)
        ' Get a sort key with no compare option for the specified string.
        sk2 = cmpi.GetSortKey(s)
        
        ' Display the original string.
        Console.WriteLine("Original string: ""{0}""", sk1.OriginalString)
        Console.WriteLine()
        
        ' Display the the string equivalent of the two sort keys.
        Console.WriteLine("CompareInfo (culture) name: {0}", cmpi.Name)
        Console.WriteLine("ToString - {0}: ""{1}""", ignoreCase, sk1.ToString())
        Console.WriteLine("ToString - {0}: ""{1}""", useCase, sk2.ToString())
        Console.WriteLine()
        
        ' Display the key data of the two sort keys.
        DisplayKeyData(sk1, ignoreCase)
        DisplayKeyData(sk2, useCase)
    End Sub 'Main
    
    Public Shared Sub DisplayKeyData(ByVal sk As SortKey, ByVal title As String) 
        Console.Write("Key Data - {0}: ", title)
        Dim keyDatum As UInteger
        For Each keyDatum In sk.KeyData
            Console.Write("0x{0} ", CUInt(keyDatum))
        Next keyDatum
        Console.WriteLine()
    End Sub 'DisplayKeyData
End Class 'Sample

'
'This code example produces the following results:
'
'Original string: "ABC"
'
'CompareInfo (culture) name: en-GB
'ToString - Ignore case: "SortKey - 2057, IgnoreCase, ABC"
'ToString - Use case   : "SortKey - 2057, None, ABC"
'
'Key Data - Ignore case: 0x14 0x2 0x14 0x9 0x14 0x10 0x1 0x1 0x1 0x1 0x0
'Key Data - Use case   : 0x14 0x2 0x14 0x9 0x14 0x10 0x1 0x1 0x18 0x18 0x18 0x1 0x1 0x0
'
'</snippet1>