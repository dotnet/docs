' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Imports System.Collections
Imports System.Collections.Generic
Imports System.Globalization

Module Example4
    Public Sub Main()
        Dim strings() As String = {"coop", "co-op", "cooperative",
                                  "co" + ChrW(&HAD) + "operative",
                                  "cœur", "coeur"}

        ' Perform a word sort using the current (en-US) culture.
        Dim current(strings.Length - 1) As String
        strings.CopyTo(current, 0)
        Array.Sort(current, StringComparer.CurrentCulture)

        ' Perform a word sort using the invariant culture.
        Dim invariant(strings.Length - 1) As String
        strings.CopyTo(invariant, 0)
        Array.Sort(invariant, StringComparer.InvariantCulture)

        ' Perform an ordinal sort.
        Dim ordinal(strings.Length - 1) As String
        strings.CopyTo(ordinal, 0)
        Array.Sort(ordinal, StringComparer.Ordinal)

        ' Perform a string sort using the current culture.
        Dim stringSort(strings.Length - 1) As String
        strings.CopyTo(stringSort, 0)
        Array.Sort(stringSort, New SCompare())

        ' Display array values
        Console.WriteLine("{0,13} {1,13} {2,15} {3,13} {4,13}",
                        "Original", "Word Sort", "Invariant Word",
                        "Ordinal Sort", "String Sort")
        Console.WriteLine()

        For ctr As Integer = 0 To strings.Length - 1
            Console.WriteLine("{0,13} {1,13} {2,15} {3,13} {4,13}",
                           strings(ctr), current(ctr), invariant(ctr),
                           ordinal(ctr), stringSort(ctr))
        Next
    End Sub
End Module

' IComparer<String> implementation to perform string sort.
Friend Class SCompare : Implements IComparer(Of String)
   Public Function Compare(x As String, y As String) As Integer _
                   Implements IComparer(Of String).Compare
      Return CultureInfo.CurrentCulture.CompareInfo.Compare(x, y, CompareOptions.StringSort)
   End Function
End Class
' The example displays the following output:
'         Original     Word Sort  Invariant Word  Ordinal Sort   String Sort
'    
'             coop          cœur            cœur         co-op         co-op
'            co-op         coeur           coeur         coeur          cœur
'      cooperative          coop            coop          coop         coeur
'     co­operative         co-op           co-op   cooperative          coop
'             cœur   cooperative     cooperative  co­operative   cooperative
'            coeur  co­operative    co­operative          cœur  co­operative
' </Snippet12> 
       
