' <Snippet21>
Imports System.Globalization
Imports System.Threading

Public Module Example6
    Public Sub Main()
        Dim str1 As String = "Apple"
        Dim str2 As String = "Æble"
        Dim str3 As String = "AEble"

        ' Set the current culture to Danish in Denmark.
        Thread.CurrentThread.CurrentCulture = New CultureInfo("da-DK")
        Console.WriteLine("Current culture: {0}",
                        CultureInfo.CurrentCulture.Name)
        Console.WriteLine("Comparison of {0} with {1}: {2}",
                        str1, str2, String.Compare(str1, str2))
        Console.WriteLine("Comparison of {0} with {1}: {2}",
                        str2, str3, String.Compare(str2, str3))
        Console.WriteLine()

        ' Set the current culture to English in the U.S.
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
        Console.WriteLine("Current culture: {0}",
                        CultureInfo.CurrentCulture.Name)
        Console.WriteLine("Comparison of {0} with {1}: {2}",
                        str1, str2, String.Compare(str1, str2))
        Console.WriteLine("Comparison of {0} with {1}: {2}",
                        str2, str3, String.Compare(str2, str3))
        Console.WriteLine()

        ' Perform an ordinal comparison.
        Console.WriteLine("Ordinal comparison")
        Console.WriteLine("Comparison of {0} with {1}: {2}",
                        str1, str2,
                        String.Compare(str1, str2, StringComparison.Ordinal))
        Console.WriteLine("Comparison of {0} with {1}: {2}",
                        str2, str3,
                        String.Compare(str2, str3, StringComparison.Ordinal))
    End Sub
End Module
' The example displays the following output:
'       Current culture: da-DK
'       Comparison of Apple with Æble: -1
'       Comparison of Æble with AEble: 1
'       
'       Current culture: en-US
'       Comparison of Apple with Æble: 1
'       Comparison of Æble with AEble: 0
'       
'       Ordinal comparison
'       Comparison of Apple with Æble: -133
'       Comparison of Æble with AEble: 133
' </Snippet21>
