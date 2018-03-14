' The following example shows how resizing affects the array.

' <Snippet1>
Imports System

Public Class SamplesArray

    Public Shared Sub Main()

        ' Create and initialize a new string array.
        Dim myArr As String() =  {"The", "quick", "brown", "fox", _
            "jumps", "over", "the", "lazy", "dog"}

        ' Display the values of the array.
        Console.WriteLine( _
            "The string array initially contains the following values:")
        PrintIndexAndValues(myArr)

        ' Resize the array to a bigger size (five elements larger).
        Array.Resize(myArr, myArr.Length + 5)

        ' Display the values of the array.
        Console.WriteLine("After resizing to a larger size, ")
        Console.WriteLine("the string array contains the following values:")
        PrintIndexAndValues(myArr)

        ' Resize the array to a smaller size (four elements).
        Array.Resize(myArr, 4)

        ' Display the values of the array.
        Console.WriteLine("After resizing to a smaller size, ")
        Console.WriteLine("the string array contains the following values:")
        PrintIndexAndValues(myArr)

    End Sub 'Main

    Public Shared Sub PrintIndexAndValues(myArr() As String)
        Dim i As Integer
        For i = 0 To myArr.Length - 1
            Console.WriteLine("   [{0}] : {1}", i, myArr(i))
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
'   [4] : jumps
'   [5] : over
'   [6] : the
'   [7] : lazy
'   [8] : dog
'
'After resizing to a larger size, 
'the string array contains the following values:
'   [0] : The
'   [1] : quick
'   [2] : brown
'   [3] : fox
'   [4] : jumps
'   [5] : over
'   [6] : the
'   [7] : lazy
'   [8] : dog
'   [9] :
'   [10] :
'   [11] :
'   [12] :
'   [13] :
'
'After resizing to a smaller size, 
'the string array contains the following values:
'   [0] : The
'   [1] : quick
'   [2] : brown
'   [3] : fox
' </Snippet1>
