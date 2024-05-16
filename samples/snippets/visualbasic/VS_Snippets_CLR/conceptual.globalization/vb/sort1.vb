' Visual Basic .NET Document
Option Strict On

' <Snippet14>
Imports System.Globalization
Imports System.Threading

Module Example18
    Public Sub Main18()
        Dim values() As String = {"able", "ångström", "apple",
                                   "Æble", "Windows", "Visual Studio"}
        ' Change thread to en-US.
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        ' Sort the array and copy it to a new array to preserve the order.
        Array.Sort(values)
        Dim enValues() As String = CType(values.Clone(), String())

        ' Change culture to Swedish (Sweden).
        Thread.CurrentThread.CurrentCulture = New CultureInfo("sv-SE")
        Array.Sort(values)
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
' </Snippet14>
