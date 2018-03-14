' The following code example passes an ArraySegment to a method.

' <Snippet1>
Imports System

Public Class SamplesArray

    Public Shared Sub Main()

        ' Create and initialize a new string array.
        Dim myArr As String() =  {"The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog"}

        ' Display the initial contents of the array.
        Console.WriteLine("The original array initially contains:")
        PrintIndexAndValues(myArr)

        ' Define an array segment that contains the entire array.
        Dim myArrSegAll As New ArraySegment(Of String)(myArr)

        ' Display the contents of the ArraySegment.
        Console.WriteLine("The first array segment (with all the array's elements) contains:")
        PrintIndexAndValues(myArrSegAll)

        ' Define an array segment that contains the middle five values of the array.
        Dim myArrSegMid As New ArraySegment(Of String)(myArr, 2, 5)

        ' Display the contents of the ArraySegment.
        Console.WriteLine("The second array segment (with the middle five elements) contains:")
        PrintIndexAndValues(myArrSegMid)

        ' Modify the fourth element of the first array segment myArrSegAll.
        myArrSegAll.Array(3) = "LION"

        ' Display the contents of the second array segment myArrSegMid.
        ' Note that the value of its second element also changed.
        Console.WriteLine("After the first array segment is modified, the second array segment now contains:")
        PrintIndexAndValues(myArrSegMid)

    End Sub 'Main

    Public Shared Sub PrintIndexAndValues(arrSeg As ArraySegment(Of String))
        Dim i As Integer
        For i = arrSeg.Offset To (arrSeg.Offset + arrSeg.Count - 1)
            Console.WriteLine("   [{0}] : {1}", i, arrSeg.Array(i))
        Next i
        Console.WriteLine()
    End Sub 'PrintIndexAndValues 

    Public Shared Sub PrintIndexAndValues(myArr as String())
        Dim i As Integer
        For i = 0 To (myArr.Length - 1)
            Console.WriteLine("   [{0}] : {1}", i, myArr(i))
        Next i
        Console.WriteLine()
    End Sub 'PrintIndexAndValues 

End Class 'SamplesArray


'This code produces the following output.
'
'The original array initially contains:
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
'The first array segment (with all the array's elements) contains:
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
'The second array segment (with the middle five elements) contains:
'   [2] : brown
'   [3] : fox
'   [4] : jumps
'   [5] : over
'   [6] : the
'
'After the first array segment is modified, the second array segment now contains:
'   [2] : brown
'   [3] : LION
'   [4] : jumps
'   [5] : over
'   [6] : the

' </Snippet1>