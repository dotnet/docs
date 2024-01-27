' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Imports System.Collections.Generic

Public Class Person9
    Public Sub New(fName As String, lName As String)
        FirstName = fName
        LastName = lName
    End Sub

    Public Property FirstName As String
    Public Property LastName As String
End Class

Module Example9
    Public Sub Main()
        Dim people As New List(Of Person9)()

        people.Add(New Person9("John", "Doe"))
        people.Add(New Person9("Jane", "Doe"))
        people.Sort()
        For Each person In people
            Console.WriteLine("{0} {1}", person.FirstName, person.LastName)
        Next
    End Sub
End Module
' The example displays the following output:
'    Unhandled Exception: System.InvalidOperationException: Failed to compare two elements in the array. ---> 
'       System.ArgumentException: At least one object must implement IComparable.
'       at System.Collections.Comparer.Compare(Object a, Object b)
'       at System.Collections.Generic.ArraySortHelper`1.SwapIfGreater(T[] keys, IComparer`1 comparer, Int32 a, Int32 b)
'       at System.Collections.Generic.ArraySortHelper`1.DepthLimitedQuickSort(T[] keys, Int32 left, Int32 right, IComparer`1 comparer, Int32 depthLimit)
'       at System.Collections.Generic.ArraySortHelper`1.Sort(T[] keys, Int32 index, Int32 length, IComparer`1 comparer)
'       --- End of inner exception stack trace ---
'       at System.Collections.Generic.ArraySortHelper`1.Sort(T[] keys, Int32 index, Int32 length, IComparer`1 comparer)
'       at System.Array.Sort[T](T[] array, Int32 index, Int32 length, IComparer`1 comparer)
'       at System.Collections.Generic.List`1.Sort(Int32 index, Int32 count, IComparer`1 comparer)
'       at Example.Main()
' </Snippet12>


