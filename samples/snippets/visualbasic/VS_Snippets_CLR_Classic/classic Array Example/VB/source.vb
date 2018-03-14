' <Snippet1>
Public Class SamplesArray

    Public Shared Sub Main()

        ' Creates and initializes a new integer array and a new Object array.
        Dim myIntArray() As Integer = {1, 2, 3, 4, 5}
        Dim myObjArray() As Object = {26, 27, 28, 29, 30}

        ' Prints the initial values of both arrays.
        Console.WriteLine("Initially:")
        Console.Write("integer array:")
        PrintValues(myIntArray)
        Console.Write("Object array: ")
        PrintValues(myObjArray)

        ' Copies the first two elements from the integer array to the Object array.
        System.Array.Copy(myIntArray, myObjArray, 2)

        ' Prints the values of the modified arrays.
        Console.WriteLine(ControlChars.NewLine + "After copying the first two" _
           + " elements of the integer array to the Object array:")
        Console.Write("integer array:")
        PrintValues(myIntArray)
        Console.Write("Object array: ")
        PrintValues(myObjArray)

        ' Copies the last two elements from the Object array to the integer array.
        System.Array.Copy(myObjArray, myObjArray.GetUpperBound(0) - 1, myIntArray,
           myIntArray.GetUpperBound(0) - 1, 2)

        ' Prints the values of the modified arrays.
        Console.WriteLine(ControlChars.NewLine + "After copying the last two" _
           + " elements of the Object array to the integer array:")
        Console.Write("integer array:")
        PrintValues(myIntArray)
        Console.Write("Object array: ")
        PrintValues(myObjArray)
    End Sub

    Public Overloads Shared Sub PrintValues(myArr() As Object)
        Dim i As Object
        For Each i In myArr
            Console.Write(ControlChars.Tab + "{0}", i)
        Next i
        Console.WriteLine()
    End Sub

    Public Overloads Shared Sub PrintValues(myArr() As Integer)
        Dim i As Integer
        For Each i In myArr
            Console.Write(ControlChars.Tab + "{0}", i)
        Next i
        Console.WriteLine()
    End Sub
End Class

' This code produces the following output.
' 
' Initially:
' integer array:  1       2       3       4       5
' Object array:   26      27      28      29      30
' 
' After copying the first two elements of the integer array to the Object array:
' integer array:  1       2       3       4       5
' Object array:   1       2       28      29      30
' 
' After copying the last two elements of the Object array to the integer array:
' integer array:  1       2       3       29      30
' Object array:   1       2       28      29      30
' </Snippet1>