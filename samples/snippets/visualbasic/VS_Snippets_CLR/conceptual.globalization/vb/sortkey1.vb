' Visual Basic .NET Document
Option Strict On

' <Snippet15>
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Threading

Public Class SortKeyComparer : Implements IComparer(Of String)
    Public Function Compare(str1 As String, str2 As String) As Integer _
           Implements IComparer(Of String).Compare
        Dim sk1, sk2 As SortKey
        sk1 = CultureInfo.CurrentCulture.CompareInfo.GetSortKey(str1)
        sk2 = CultureInfo.CurrentCulture.CompareInfo.GetSortKey(str2)
        Return SortKey.Compare(sk1, sk2)
    End Function
End Class

Module Example19
    Public Sub Main19()
        Dim values() As String = {"able", "ångström", "apple",
                                   "Æble", "Windows", "Visual Studio"}
        Dim comparer As New SortKeyComparer()

        ' Change thread to en-US.
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        ' Sort the array and copy it to a new array to preserve the order.
        Array.Sort(values, comparer)
        Dim enValues() As String = CType(values.Clone(), String())

        ' Change culture to Swedish (Sweden).
        Thread.CurrentThread.CurrentCulture = New CultureInfo("sv-SE")
        Array.Sort(values, comparer)
        Dim svValues() As String = CType(values.Clone(), String())

        ' Compare the sorted arrays.
        Console.WriteLine("{0,-8} {1,-15} {2,-15}", "Position", "en-US", "sv-SE")
        Console.WriteLine()
        For ctr As Integer = 0 To values.GetUpperBound(0)
            Console.WriteLine("{0,-8} {1,-15} {2,-15}", ctr, enValues(ctr), svValues(ctr))
        Next
    End Sub
End Module
' The example displays the following output:
'       Position en-US           sv-SE
'       
'       0        able            able
'       1        Æble            Æble
'       2        ångström        apple
'       3        apple           Windows
'       4        Visual Studio   Visual Studio
'       5        Windows         ångström
' </Snippet15>
