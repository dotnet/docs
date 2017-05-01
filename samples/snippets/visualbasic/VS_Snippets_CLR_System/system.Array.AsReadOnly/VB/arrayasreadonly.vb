' The following example wraps an array in a read-only IList.

' <Snippet1>
Imports System
Imports System.Collections.Generic

Public Class SamplesArray

    Public Shared Sub Main()

        ' Create and initialize a new string array.
        Dim myArr As String() =  {"The", "quick", "brown", "fox"}

        ' Display the values of the array.
        Console.WriteLine("The string array initially contains the following values:")
        PrintIndexAndValues(myArr)

        ' Create a read-only IList wrapper around the array.
        Dim myList As IList(Of String) = Array.AsReadOnly(myArr) '

        ' Display the values of the read-only IList.
        Console.WriteLine("The read-only IList contains the following values:")
        PrintIndexAndValues(myList)

        ' Attempt to change a value through the wrapper.
        Try
            myList(3) = "CAT"
        Catch e As NotSupportedException
            Console.WriteLine("{0} - {1}", e.GetType(), e.Message)
            Console.WriteLine()
        End Try

        ' Change a value in the original array.
        myArr(2) = "RED"

        ' Display the values of the array.
        Console.WriteLine("After changing the third element, the string array contains the following values:")
        PrintIndexAndValues(myArr)

        ' Display the values of the read-only IList.
        Console.WriteLine("After changing the third element, the read-only IList contains the following values:")
        PrintIndexAndValues(myList)

    End Sub 'Main

    Overloads Public Shared Sub PrintIndexAndValues(myArr() As String)
        Dim i As Integer
        For i = 0 To myArr.Length - 1
            Console.WriteLine("   [{0}] : {1}", i, myArr(i))
        Next i
        Console.WriteLine()
    End Sub 'PrintIndexAndValues

    Overloads Public Shared Sub PrintIndexAndValues(myList As IList(Of String))
        Dim i As Integer
        For i = 0 To myList.Count - 1
            Console.WriteLine("   [{0}] : {1}", i, myList(i))
        Next i
        Console.WriteLine()
    End Sub 'PrintIndexAndValues 

End Class 'SamplesArray


'This code produces the following output.
'
'The string array initially contains the following values:
'   [0] : The
'   [1] : quick
'   [2] : brown
'   [3] : fox
'
'The read-only IList contains the following values:
'   [0] : The
'   [1] : quick
'   [2] : brown
'   [3] : fox
'
'System.NotSupportedException - Collection is read-only.
'
'After changing the third element, the string array contains the following values:
'   [0] : The
'   [1] : quick
'   [2] : RED
'   [3] : fox
'
'After changing the third element, the read-only IList contains the following values:
'   [0] : The
'   [1] : quick
'   [2] : RED
'   [3] : fox

' </Snippet1>
